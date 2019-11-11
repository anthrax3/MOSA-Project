﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Common;
using Mosa.Compiler.Common.Configuration;
using Mosa.Compiler.Framework;
using Mosa.Compiler.Framework.Linker;
using Mosa.Compiler.Framework.Trace;
using Mosa.Compiler.MosaTypeSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mosa.Utility.Compiler
{
	public static class MapCompilerOptions
	{
		public static void Set(Settings settings, CompilerOptions compilerOptions)
		{
			compilerOptions.TraceLevel = settings.GetValueAsInteger("Compiler.TraceLevel", compilerOptions.TraceLevel);
			compilerOptions.EmitBinary = settings.GetValueAsBoolean("Compiler.EmitBinary", compilerOptions.EmitBinary);
			compilerOptions.MethodScanner = settings.GetValueAsBoolean("Compiler.MethodScanner", compilerOptions.MethodScanner);

			//compilerOptions.EnableThreading = settings.GetValueAsBoolean("Compiler.Multithreading", compilerOptions.EnableThreading);

			compilerOptions.SSA = settings.GetValueAsBoolean("Optimizations.SSA", compilerOptions.SSA);
			compilerOptions.BasicOptimizations = settings.GetValueAsBoolean("Optimizations.Basic", compilerOptions.BasicOptimizations);
			compilerOptions.ValueNumbering = settings.GetValueAsBoolean("Optimizations.ValueNumbering", compilerOptions.ValueNumbering);
			compilerOptions.SparseConditionalConstantPropagation = settings.GetValueAsBoolean("Optimizations.SCCP", compilerOptions.SparseConditionalConstantPropagation);
			compilerOptions.BitTracker = settings.GetValueAsBoolean("Optimizations.BitTracker", compilerOptions.BitTracker);
			compilerOptions.LoopInvariantCodeMotion = settings.GetValueAsBoolean("Optimizations.LoopInvariantCodeMotion", compilerOptions.LoopInvariantCodeMotion);
			compilerOptions.TwoPass = settings.GetValueAsBoolean("Optimizations.TwoPass", compilerOptions.TwoPass);
			compilerOptions.LongExpansion = settings.GetValueAsBoolean("Optimizations.LongExpansion", compilerOptions.LongExpansion);
			compilerOptions.PlatformOptimizations = settings.GetValueAsBoolean("Optimizations.Platform", compilerOptions.PlatformOptimizations);
			compilerOptions.InlineMethods = settings.GetValueAsBoolean("Optimizations.Inline", compilerOptions.InlineMethods);
			compilerOptions.InlineMaximum = settings.GetValueAsInteger("Optimizations.Inline.Maximum", compilerOptions.InlineMaximum);
			compilerOptions.InlineAggressiveMaximum = settings.GetValueAsInteger("Optimizations.Inline.AggressiveMaximum", compilerOptions.InlineAggressiveMaximum);
			compilerOptions.InlineExplicitOnly = settings.GetValueAsBoolean("Optimizations.Inline.ExplicitOnly", compilerOptions.InlineExplicitOnly);

			var platform = settings.GetValue("Compiler.Platform");
			if (platform != null)
				compilerOptions.Platform = GetPlatform(platform);

			compilerOptions.SourceFiles.Clear();
			compilerOptions.AddSourceFiles(settings.GetList("SourceFiles"));

			compilerOptions.SearchPaths.Clear();
			compilerOptions.AddSearchPaths(settings.GetList("SearchPaths"));
		}

		private static BaseArchitecture GetPlatform(string platform)
		{
			switch (platform.ToLower())
			{
				case "x86": return Platform.x86.Architecture.CreateArchitecture(Platform.x86.ArchitectureFeatureFlags.AutoDetect);
				case "x64": return Platform.x64.Architecture.CreateArchitecture(Platform.x64.ArchitectureFeatureFlags.AutoDetect);
				case "armv8a32": return Platform.ARMv8A32.Architecture.CreateArchitecture(Platform.ARMv8A32.ArchitectureFeatureFlags.AutoDetect);
				default: return null;
			}
		}
	}
}
