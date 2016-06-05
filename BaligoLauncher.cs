using System;

namespace Baligo
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class BaligoLauncher
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            BaligoEngine mainEngine = new BaligoEngine();
            mainEngine.Run();
        }
    }
#endif
}