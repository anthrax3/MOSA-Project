﻿/*
 * (c) 2008 MOSA - The Managed Operating System Alliance
 *
 * Licensed under the terms of the New BSD License.
 *
 * Authors:
 *  Phil Garcia (tgiphil) <phil@thinkedge.com> 
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Mosa.Test.CodeDomCompiler
{
	public class Compiler
	{
		#region Data members

		/// <summary>
		/// A cache of CodeDom providers.
		/// </summary>
		private static Dictionary<string, CodeDomProvider> providerCache = new Dictionary<string, CodeDomProvider>();

		/// <summary>
		/// 
		/// </summary>
		private static string tempDirectory;

		/// <summary>
		/// Holds the temporary files collection.
		/// </summary>
		private static TempFileCollection temps = new TempFileCollection(TempDirectory, false);

		#endregion // Data members

		#region Construction

		/// <summary>
		/// Initializes a new instance of the <see cref="Compiler"/> class.
		/// </summary>
		public Compiler()
		{
		}

		#endregion // Construction

		#region Properties

		private static string TempDirectory
		{
			get
			{
				if (tempDirectory == null)
				{
					tempDirectory = Path.Combine(Path.GetTempPath(), "mosa");
					if (!Directory.Exists(tempDirectory))
					{
						Directory.CreateDirectory(tempDirectory);
					}
				}
				return tempDirectory;
			}
		}

		#endregion Properties

		public string Compile(CompilerSettings settings)
		{
			Console.WriteLine("Executing {0} compiler...", settings.Language);

			CodeDomProvider provider;
			if (!providerCache.TryGetValue(settings.Language, out provider))
			{
				provider = CodeDomProvider.CreateProvider(settings.Language);
				if (provider == null)
					throw new NotSupportedException("The language '" + settings.Language + "' is not supported on this machine.");
				providerCache.Add(settings.Language, provider);
			}

			string filename = Path.Combine(TempDirectory, Path.ChangeExtension(Path.GetRandomFileName(), "dll"));
			temps.AddFile(filename, false);

			string[] references = new string[settings.References.Count];
			settings.References.CopyTo(references, 0);

			CompilerResults compileResults;
			CompilerParameters parameters = new CompilerParameters(references, filename, false);
			parameters.CompilerOptions = "/optimize-";

			if (settings.UnsafeCode)
			{
				if (settings.Language == "C#")
					parameters.CompilerOptions = parameters.CompilerOptions + " /unsafe+";
				else
					throw new NotSupportedException();
			}

			if (settings.DoNotReferenceMscorlib)
			{
				if (settings.Language == "C#")
					parameters.CompilerOptions = parameters.CompilerOptions + " /nostdlib";
				else
					throw new NotSupportedException();
			}

			parameters.GenerateInMemory = false;

			if (settings.CodeSource != null)
			{
				//Console.WriteLine("Code: {0}", settings.CodeSource + settings.AdditionalSource);
				compileResults = provider.CompileAssemblyFromSource(parameters, settings.CodeSource + settings.AdditionalSource);
			}
			else
				throw new NotSupportedException();

			if (compileResults.Errors.HasErrors)
			{
				StringBuilder sb = new StringBuilder();
				sb.AppendLine("Code compile errors:");
				foreach (CompilerError error in compileResults.Errors)
				{
					sb.AppendLine(error.ToString());
				}
				throw new Exception(sb.ToString());
			}

			return compileResults.PathToAssembly;
		}


	}
}
