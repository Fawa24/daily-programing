using System.Diagnostics;

namespace ProcessManipulatorDemo
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			ListAllRunningProcesses();
			Br();
			Process.GetProcessById(4736).Display();
		}

		/// <summary>
		/// Uses to display breaking line in console
		/// </summary>
		static void Br()
		{
			Console.WriteLine("******************   ******************   ******************");
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
		/// <summary>
		/// Uses for displaying formatted info about target process
		/// </summary>
		/// <param name="process"></param>
		public static void Display(this Process process)
		{
			Console.WriteLine($"PID: {process.Id}\t Name :{process.ProcessName} ");
		}
	}
}