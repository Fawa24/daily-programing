﻿using System.Diagnostics;

namespace ProcessManipulator
{
	internal class Program
	{
		static void Main(string[] args)
		{
			ListCurrentProcesses();

			var pid = AskUserForValidPID();

			EnumThreadsForPID(pid);
			EnumModsForPid(pid);

			Console.ReadKey();

			StartAndKillProcess();
			UseapplicationVerbs();
		}

		public static void ListCurrentProcesses()
		{
			var runningProcesses =
				from proc
				in Process.GetProcesses()
				orderby proc.Id
				select proc;

			foreach (var proc in runningProcesses)
			{
				Console.WriteLine($"PID: {proc.Id}  \tName: {proc.ProcessName}");
			}
			Console.WriteLine("\n**************************************************\n");
		}

		public static int AskUserForValidPID()
		{
			int pid = 0;
			bool isOperationSucessfull = false;

			while (!isOperationSucessfull)
			{
				Console.Write("Enter the PID: ");
				string? input = Console.ReadLine();

				try
				{
					pid = int.Parse(input);
					Process.GetProcessById(pid);
					isOperationSucessfull = true;
				}
				catch (Exception ex)
				{
					Console.WriteLine("Invalid PID. Try again");
				}
			}

			return pid;
		}

		public static void EnumThreadsForPID(int pID)
		{
			Process proc = null;
			Console.WriteLine("Trying to get the process by PID...");
			try
			{
				proc = Process.GetProcessById(pID);
				Console.WriteLine("Process was found successfully\n");
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine(ex.Message);
				return;
			}

			Console.WriteLine($"Here are the threads used by {proc.ProcessName}\n");

			foreach (ProcessThread th in proc.Threads)
			{
				string info = $"Thread ID: {th.Id}  \tStart time: {th.StartTime.ToShortTimeString()} \tPriority: {th.PriorityLevel}";
				Console.WriteLine(info);
			}

			Console.WriteLine("\n**************************************************\n");
		}

		public static void EnumModsForPid(int pid)
		{
			Process proc = null;

			try
			{
				proc = Process.GetProcessById(pid);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return;
			}

			Console.WriteLine($"Here are the loaded modules for {proc.ProcessName}\n");

			foreach (ProcessModule module in proc.Modules)
			{
				Console.WriteLine($"Mod name: {module.ModuleName}");
			}

			Console.WriteLine("\n**************************************************\n");
		}

		public static void StartAndKillProcess()
		{
			Process proc = null;

			var startInfo = new ProcessStartInfo("MsEdge", "www.facebook.com")
			{
				UseShellExecute = true
			};

			try
			{
				proc = Process.Start(startInfo);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return;
			}

			Console.WriteLine($"--> Hit Entre to kill {proc.ProcessName}");
			Console.ReadKey();

			try
			{
				foreach (var p in Process.GetProcessesByName(proc.ProcessName))
				{
					p.Kill(true);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return;
			}

			Console.WriteLine("\n**************************************************\n");
		}

		public static void UseapplicationVerbs()
		{
			int i = 0;

			var startInfo = new ProcessStartInfo(@"C:\Users\ofegl\OneDrive\Документи\test.txt");

			foreach (var verb in startInfo.Verbs)
			{
				Console.WriteLine($" {i++}:\t{verb}");
			}

			startInfo.WindowStyle = ProcessWindowStyle.Maximized;
			startInfo.UseShellExecute = true;

			Process.Start(startInfo);

			Console.WriteLine("\n**************************************************\n");
		}
	}
}
