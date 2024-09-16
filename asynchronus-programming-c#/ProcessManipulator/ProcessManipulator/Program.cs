﻿using System.Diagnostics;

namespace ProcessManipulator
{
	internal class Program
	{
		static void Main(string[] args)
		{
			ListCurrentProcesses();
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
				Console.WriteLine($"PID: {proc.Id}\tName: {proc.ProcessName}");
			}
		}
	}
}