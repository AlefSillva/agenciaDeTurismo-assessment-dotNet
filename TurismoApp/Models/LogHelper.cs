using System;
using System.Collections.Generic;
using System.IO;

namespace TurismoApp.Models
{
    public static class LogHelper
    {
        public static List<string> LogMemory = new List<string>();

        public static void LogToConsole(string message)
        {
            Console.WriteLine($"[Console] {message}");
        }

        public static void LogToFile(string message)
        {
            File.AppendAllText("log.txt", $"[File] {message}{Environment.NewLine}");
        }

        public static void LogToMemory(string message)
        {
            LogMemory.Add($"[Memory] {message}");
        }
    }
}