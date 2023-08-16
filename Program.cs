

using System.Runtime.InteropServices;

namespace Rule34XXXGUI
{
    internal static class Program
    {
        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();

        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //AllocConsole();


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            
            ApplicationConfiguration.Initialize();
            Application.Run(new R34GUI());

            

            }
        
    }
}