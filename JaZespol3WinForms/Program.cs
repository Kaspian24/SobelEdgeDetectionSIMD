using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace JaZespol3WinForms
{
    internal static class Program
    {
        [DllImport("JAAsm.dll")]
        public static extern int SobelAsm(byte[] rgbValues, byte[] grayValues, int width, int height, int scanWidth, int detectionLevel);
        [DllImport("JACpp.dll")]
        public static extern int SobelCpp(byte[] rgbValues, byte[] grayValues, int width, int height, int scanWidth, int detectionLevel);

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}