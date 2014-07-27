﻿// Program.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/07/13 15:53
// ©Bertware, visit http://bertware.net

using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.Core;
using Net.Bertware.Bukkitgui2.UI;
using Net.Bertware.Get;

namespace Net.Bertware.Bukkitgui2
{
	internal static class Program
	{
		/// <summary>
		///     The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main(string[] argStrings)
		{
			// Load embedded DLLs
			AppDomain.CurrentDomain.AssemblyResolve += LoadDll;

			Thread t = new Thread(CheckForUpdates) {IsBackground = true, Name = "update_check"};
			t.Start();

			// Load app
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}

		public static Assembly LoadDll(object sender, ResolveEventArgs args)
		{
			//Load embedded DLLs

			String resourceName = "Net.Bertware.Bukkitgui2." + new AssemblyName(args.Name).Name + ".dll";
			using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
			{
				if (stream == null || stream.Length < 1)
				{
					return null;
				}
				Byte[] assemblyData = new Byte[stream.Length];
				stream.Read(assemblyData, 0, assemblyData.Length);
				return Assembly.Load(assemblyData);
			}
		}

		public static void CheckForUpdates()
		{
			api.RunUpdateCheck(true);
		}
	}
}