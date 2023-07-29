using System.Diagnostics;

namespace mazeBattle {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {

            // 2次元配列でマップを 1:下(x--) 2:右(y++)
            int[] map = {// --> y
             1, 1, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,// |
             0, 0, 0, 2, 0, 3, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0,// v
             0, 0, 0, 3, 1, 2, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0,// x
             0, 0, 0, 1, 3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            };

            bool noupdate = true;
            int startX = 0;
            int startY = 0;
            int goalX = 0;
            int goalY = 7;

            MainForm form = new MainForm();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            Task.Run(() => {
                Application.Run(form);
            });

            while (true) {

                astar aStar = new astar(map, 12);

                List<astar.Node>? path = aStar.FindPath(startX, startY, goalX, goalY);

                if (path != null) {
                    Debug.WriteLine("Path found:");
                    foreach (astar.Node node in path) {
                        Debug.WriteLine("({0}, {1})", node.X, node.Y);
                    }
                } else {
                    Debug.WriteLine("Path not found.");
                }

                form.View(map, 12);
                form.route(path);
                noupdate = true;

                while (noupdate) {
                    Thread.Sleep(1000);
                    noupdate = form.chkUpdate(map,ref startX,ref startY,ref goalX,ref goalY);
                }


            }
        }
    }
}