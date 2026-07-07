// Program.cs
// Application entry point — standard WinForms bootstrap.

using System;
using System.Windows.Forms;

namespace PersonalFinanceTracker
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Enable visual styles and text rendering for a modern look.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Launch the main form.
            Application.Run(new Form1());
        }
    }
}
