using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace GestorTorneosFutbolSala.utils
{
    public class LoadFonts
    {
        private PrivateFontCollection fontCollection = new PrivateFontCollection();

        public FontFamily[] FontFamilies => fontCollection.Families;

        public LoadFonts()
        {
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resources", "fonts");


            if (Directory.Exists(folderPath))
            {
                foreach (string file in Directory.GetFiles(folderPath, "*.ttf"))
                {
                    byte[] fontData = File.ReadAllBytes(file);

                    IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
                    Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
                    fontCollection.AddMemoryFont(fontPtr, fontData.Length);
                    Marshal.FreeCoTaskMem(fontPtr);
                }
            }
            else
            {
                throw new DirectoryNotFoundException($"No se encontró el directorio: {folderPath}");
            }
        }

        public Font GetFont(string familyName, float size, FontStyle style = FontStyle.Regular)
        {
            var family = Array.Find(fontCollection.Families, f => f.Name == familyName);
            if (family != null)
            {
                return new Font(family, size, style);
            }

            throw new ArgumentException($"La fuente '{familyName}' no está cargada.");
        }

        public Font SetDefaultFont(float size, FontStyle style = FontStyle.Regular)
        {
            return new Font(fontCollection.Families[0], size, style);
        }
    }
}
