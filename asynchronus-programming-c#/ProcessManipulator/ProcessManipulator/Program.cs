using System.Diagnostics;

namespace ProcessManipulator
{
	internal class Program
	{
		static void Main(string[] args)
		{
			ListCurrentProcesses();
			EnumThreadsForPID(1384);
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
	}
}
