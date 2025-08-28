using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorTorneosFutbolSala.src.Application.Config
{
    public class EnvironmentLoader
    {
        public static void LoadEnvironmentFile(string filePath = ".env")
        {
            string projectRoot = GetProjectRoot();
            string envPath = Path.Combine(projectRoot, filePath);

            if (!File.Exists(envPath))
            {
                throw new FileNotFoundException($"Archivo .env no encontrado en: {envPath}");
            }

            foreach (var line in File.ReadAllLines(envPath))
            {
                var trimmedLine = line.Trim();

                if (string.IsNullOrEmpty(trimmedLine) || trimmedLine.StartsWith("#"))
                    continue;

                var parts = trimmedLine.Split(new char[] { '=' }, 2, StringSplitOptions.None);

                if (parts.Length != 2) continue;

                string key = parts[0].Trim();
                string value = parts[1].Trim();

                if (value.StartsWith("\"") && value.EndsWith("\""))
                {
                    value = value.Substring(1, value.Length - 2);
                }
                else if (value.StartsWith("'") && value.EndsWith("'"))
                {
                    value = value.Substring(1, value.Length - 2);
                }

                Environment.SetEnvironmentVariable(key, value);
            }
        }

        private static string GetProjectRoot()
        {
            string currentDir = Directory.GetCurrentDirectory();

            while (!string.IsNullOrEmpty(currentDir))
            {
                if (Directory.GetFiles(currentDir, "*.sln").Length > 0 ||
                    File.Exists(Path.Combine(currentDir, ".env")))
                {
                    return currentDir;
                }

                DirectoryInfo parent = Directory.GetParent(currentDir);
                if (parent == null) break;
                currentDir = parent.FullName;
            }

            return Directory.GetCurrentDirectory();
        }
    }
}
