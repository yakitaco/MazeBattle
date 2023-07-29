using System.Diagnostics;

namespace mazeBattle {
    public partial class MainForm : Form {

        Bitmap canvas;
        bool upchk = true;
        int[] map;

        public MainForm() {
            InitializeComponent();

            //描画先とするImageオブジェクトを作成する
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);

        }

        public void View(int[] _map, int size) {
            map = _map;
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            //描画先とするImageオブジェクトを作成する
            //Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(canvas);

            //Penオブジェクトの作成(幅1の黒色)
            //(この場合はPenを作成せずに、Pens.Blackを使っても良い)
            Pen p = new Pen(Color.Black, 1);
            Pen w = new Pen(Color.Red, 1);

            //位置(10, 20)に100x80の長方形を描く
            for (int i = 0; i < map.Length; i++) {
                g.DrawRectangle(p, (i & 0x0F) * 32, (i >> 4) * 32, 32, 32);
                if ((map[i] & 1) == 1) g.DrawRectangle(w, (i & 0x0F) * 32, (i >> 4) * 32 + 31, 32, 3);
                if ((map[i] & 2) == 2) g.DrawRectangle(w, (i & 0x0F) * 32 + 31, (i >> 4) * 32, 3, 32);
                //if ((map[i] & 1) == 1) g.DrawRectangle(w, (i & 0x0F) * 32, (i >> 4) * 32 - 1, 32, 3);
            }

            //リソースを解放する
            p.Dispose();
            g.Dispose();

            //PictureBox1に表示する
            pictureBox1.Image = canvas;

        }

        public void route(List<astar.Node>? path) {
            //描画先とするImageオブジェクトを作成する
            //Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(canvas);

            //Penオブジェクトの作成(幅1の黒色)
            //(この場合はPenを作成せずに、Pens.Blackを使っても良い)
            Pen w = new Pen(Color.Red, 3);
            if (path != null) {
                for (int i = 0; i < path.Count - 1; i++) {
                    //Debug.WriteLine("({0}, {1})", node.X, node.Y);


                    //位置(10, 20)に100x80の長方形を描く
                    g.DrawLine(w, path[i].Y * 32 + 15, path[i].X * 32 + 15, path[i + 1].Y * 32 + 15, path[i + 1].X * 32 + 15);
                    //g.DrawRectangle(w, (i & 0x0F) * 32, (i >> 4) * 32, 32, 32);
                    //g.DrawLine(w, 0 * 32 + 15, 0 * 32 + 15, 0 * 32 + 17, 0 * 32 + 17);
                    //if ((map[i] & 1) == 1) g.DrawRectangle(w, (i & 0x0F) * 32, (i >> 4) * 32 - 1, 32, 3);
                    //if ((map[i] & 2) == 2) g.DrawRectangle(w, (i & 0x0F) * 32 + 31, (i >> 4) * 32, 3, 32);
                    //if ((map[i] & 1) == 1) g.DrawRectangle(w, (i & 0x0F) * 32, (i >> 4) * 32 - 1, 32, 3);

                }
            }

            //リソースを解放する
            g.Dispose();

            //PictureBox1に表示する
            pictureBox1.Image = canvas;

            upchk = true;
        }

        // マウスクリック
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e) {
            Point getXY = e.Location;
            Debug.WriteLine((getXY.X).ToString() + "," + (getXY.Y).ToString());
            label1.Text = "(" + e.X/32 + "," + e.Y / 32 + ")";
            map[(e.X / 32) + (e.Y / 32)*16] ++;
            upchk = false;
        }

        public bool chkUpdate(int[] _map,ref int _startX, ref int _startY,ref int _goalX, ref int _goalY ) {
            _map = map;
            _startX = (int)StartX.Value;
            _startY = (int)StartY.Value;
            _goalX = (int)GoalX.Value;
            _goalY = (int)GoalY.Value;
            return upchk;
        }

        private void button1_Click(object sender, EventArgs e) {
            upchk = true;
        }
    }
}