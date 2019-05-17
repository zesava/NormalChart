using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace NormalChart
{
    static class Program
	{

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
		static void Main ()
		{
                Process current = Process.GetCurrentProcess();
                foreach (Process process in Process.GetProcessesByName(current.ProcessName))
                {
                    if (process.Id != current.Id)
                    {
                        process.Kill();
                    }
                }

            Application.EnableVisualStyles ();
			Application.SetCompatibleTextRenderingDefault (false);
			Application.Run (new MainForm ());
         }
	}
}