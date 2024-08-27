using System.Diagnostics;

namespace ProcessManipulatorDemo
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			while (true)
			{
				ListAllRunningProcesses();
				Br();

				int pid = -1;
				while (pid < 0)
				{
					Console.Write("Enter the PID: ");
					var input = Console.ReadLine();
					if (input == null)
					{
						Console.WriteLine("Invalid input. Enter valid PID.");
						continue;
					}

					pid = int.Parse(input);

					try
					{
						Process.GetProcessById(pid);
					}
					catch (Exception ex)
					{
						Console.WriteLine("None process mathes this PID. Try again.");
						continue;
					}
				}

				Br();
				Process.GetProcessById(pid).Display();
				Br();
				EnumThreadsForPid(pid);
				Br();

				Console.Write("Press any button to continue: ");
				Console.ReadKey();
				Console.Clear();
			}
		}

		/// <summary>
		/// Uses to display breaking line in console
		/// </summary>
		static void Br()
		{
			Console.WriteLine("\n******************   ******************   ******************\n");
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

		static void EnumThreadsForPid(int pid)
		{
			Process proc = null;

			try
			{
				proc = Process.GetProcessById(pid);
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine(ex.Message);
				return;
			}

			Console.WriteLine($"Here are the threads used by {proc.ProcessName}");
			var threads = proc.Threads;

			if (threads.Count == 0)
			{
				Console.WriteLine("No threads used by a process");
			}

			foreach (ProcessThread thread in threads)
			{
				string info = $"Id: {thread.Id}\t   Start time: {thread.StartTime}\t   Priority: {thread.PriorityLevel}";
				Console.WriteLine(info);
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