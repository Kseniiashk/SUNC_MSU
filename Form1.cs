using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
    public partial class Form1 : Form {
        public Form1() { InitializeComponent(); }
        private void Form1_Load(object sender, EventArgs e) { }
        static Graphics Graphic;
        Pen pen = new Pen(Color.Pink, 1);
        public struct Triangle {
            public PointF p1, p2, p3;
            public Triangle(PointF p1, PointF p2, PointF p3) {
                this.p1 = p1; this.p2 = p2; this.p3 = p3;
            }
        }

        List<Triangle> triangles;
        int d = 0;

        void pr(PointF p1, PointF p2, PointF p3) {
            PointF p4 = new PointF((p2.X + 2 * p1.X) / 3, (p2.Y + 2 * p1.Y) / 3);
            PointF p5 = new PointF((2 * p2.X + p1.X) / 3, (p1.Y + 2 * p2.Y) / 3);
            PointF p6 = new PointF((2 * (p1.X + p2.X) - p3.X) / 3, (2 * (p1.Y + p2.Y) - p3.Y) / 3);
            Graphic.DrawLine(new Pen(Color.White, 1), p4, p5);
            Graphic.DrawLine(pen, p4, p6);
            Graphic.DrawLine(pen, p5, p6);
            triangles.Add(new Triangle(p4, p5, p6));
            triangles.Add(new Triangle(p1, p4, new PointF((2 * p1.X + p3.X) / 3, (2 * p1.Y + p3.Y) / 3)));
            triangles.Add(new Triangle(p5, p2, new PointF((2 * p2.X + p3.X) / 3, (2 * p2.Y + p3.Y) / 3)));
        }

        private void init(object sender, EventArgs e) {
            if (Graphic != null) Graphic.Clear(Color.White);
            triangles = new List<Triangle>();
            Graphic = Snowflake.CreateGraphics();
            Graphic.Clear(Color.White);
            float width = 500, height = 500;
            PointF p1 = new PointF(width / 2  -130, height / 2 - 90);
            PointF p2 = new PointF(width / 2, height / 2 + 90);
            PointF p3 = new PointF(width / 2 + 130, height / 2 - 90);
            triangles.Add(new Triangle(p1, p2, p3));
            Graphic.DrawLine(pen, p1, p2);
            Graphic.DrawLine(pen, p2, p3);
            Graphic.DrawLine(pen, p3, p1);
            d = 1;
            Out.Text = "1";
        }

        private void next_depth(object sender, EventArgs e)
        {
            int sz = triangles.Count;
            for (int i = 0; i < sz; ++i)
            {
                if (i % 3 == 0)
                {
                    pr(triangles[i].p1, triangles[i].p3, triangles[i].p2);
                    pr(triangles[i].p3, triangles[i].p2, triangles[i].p1);
                }
                if (i % 3 != 0 || i + 1 == sz)
                   pr(triangles[i].p1, triangles[i].p2, triangles[i].p3);
            }
            d++;
            triangles.RemoveRange(0, sz);
            Out.Text = Convert.ToString(d);
        }

        private void Out_Click(object sender, EventArgs e) {}
    }
}