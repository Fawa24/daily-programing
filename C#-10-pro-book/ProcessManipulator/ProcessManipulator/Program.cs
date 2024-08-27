using System.Diagnostics;

namespace ProcessManipulatorDemo
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			ListAllRunningProcesses();
		}

		/// <summary>
		/// Writes all the curently running processes into the console
		/// </summary>
		static void ListAllRunningProcesses()
		{
			// First, get all the running processes ordered by PID

			var runningProcesses = Process.GetProcesses();

			foreach (var process in runningProcesses)
			{
				process.Display();
			}
		}
	}

	public static class ProcessExtension
	{
		public static void Display(this Process process)
		{
			Console.WriteLine($"PID: {process.Id}\t Name :{process.ProcessName} ");
		}
	}
}