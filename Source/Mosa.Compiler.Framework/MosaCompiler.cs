// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Common.Configuration;
using Mosa.Compiler.Framework.API;
using Mosa.Compiler.Framework.Linker;
using Mosa.Compiler.Framework.Trace;
using Mosa.Compiler.MosaTypeSystem;
using System;

namespace Mosa.Compiler.Framework
{
	public sealed class MosaCompiler
	{
		public CompilerSettings CompilerSettings { get; }

		public TypeSystem TypeSystem { get; private set; }

		public MosaTypeLayout TypeLayout { get; private set; }

		public BaseArchitecture Platform { get; private set; }

		public MosaLinker Linker { get { return Compiler.Linker; } }

		public CompilerHook CompilerHook { get; }

		public int MaxThreads { get; }

		private enum CompileStage { Initial, Loaded, Initialized, Ready, Executing, Completed }

		private CompileStage Stage = CompileStage.Initial;

		private Compiler Compiler;

		private readonly object _lock = new object();

		public MosaCompiler(Settings settings, CompilerHook compilerHook = null, int maxThreads = 0)
		{
			CompilerSettings = new CompilerSettings(settings.Clone());

			CompilerHook = compilerHook ?? new CompilerHook();

			MaxThreads = (maxThreads == 0) ? Environment.ProcessorCount : maxThreads;
		}

		public void Load()
		{
			lock (_lock)
			{
				var moduleLoader = new MosaModuleLoader();

				moduleLoader.AddSearchPaths(CompilerSettings.SearchPaths);
				moduleLoader.LoadModuleFromFiles(CompilerSettings.SourceFiles);

				var typeSystem = TypeSystem.Load(moduleLoader.CreateMetadata());

				Load(typeSystem);
			}
		}

		public void Load(TypeSystem typeSystem)
		{
			lock (_lock)
			{
				TypeSystem = typeSystem;

				Platform = PlatformRegistry.GetPlatform(CompilerSettings.Platform);
				TypeLayout = new MosaTypeLayout(typeSystem, Platform.NativePointerSize, Platform.NativeAlignment);

				Compiler = null;

				Stage = CompileStage.Loaded;
			}
		}

		public void Initialize()
		{
			lock (_lock)
			{
				if (Stage != CompileStage.Loaded)
					return;

				Compiler = new Compiler(this);

				Stage = CompileStage.Initialized;
			}
		}

		public void Setup()
		{
			Initialize();

			lock (_lock)
			{
				if (Stage != CompileStage.Initialized)
					return;

				Compiler.Setup();

				Stage = CompileStage.Ready;
			}
		}

		public void Finalization()
		{
			lock (_lock)
			{
				if (Stage != CompileStage.Ready)
					return;

				Compiler.Finalization();

				Stage = CompileStage.Completed;
			}
		}

		public void ScheduleAll()
		{
			Setup();
			Compiler.MethodScheduler.ScheduleAll(TypeSystem);
		}

		public void Schedule(MosaType type)
		{
			Setup();
			Compiler.MethodScheduler.Schedule(type);
		}

		public void Schedule(MosaMethod method)
		{
			Setup();
			Compiler.MethodScheduler.Schedule(method);
		}

		public void Compile(bool skipFinalization = false)
		{
			Setup();

			if (!CompilerSettings.MethodScanner)
			{
				ScheduleAll();
			}

			lock (_lock)
			{
				if (Stage != CompileStage.Ready)
					return;

				Stage = CompileStage.Executing;
			}

			Compiler.ExecuteCompile();

			lock (_lock)
			{
				Stage = CompileStage.Ready;
			}

			if (!skipFinalization)
			{
				Finalization();
			}
		}

		public void ThreadedCompile(bool skipFinalization = false)
		{
			Setup();

			if (!CompilerSettings.MethodScanner)
			{
				ScheduleAll();
			}

			lock (_lock)
			{
				if (Stage != CompileStage.Ready)
					return;

				Stage = CompileStage.Executing;
			}

			Compiler.ExecuteThreadedCompile(MaxThreads);

			lock (_lock)
			{
				Stage = CompileStage.Ready;
			}

			if (!skipFinalization)
			{
				Finalization();
			}
		}

		public void CompileSingleMethod(MosaMethod method)
		{
			Setup();

			// Thread Safe
			Compiler.CompileMethod(method);
		}
	}
}
