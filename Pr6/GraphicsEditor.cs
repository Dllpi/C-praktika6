namespace Pr6
{
    public partial class GraphicsEditor : Form
    {
        Pen pen = new Pen(Color.Black, 1);
        Bitmap buffer;
        Graphics gr;

        int tool = 1;

        public GraphicsEditor()
        {
            InitializeComponent();

            buffer = new Bitmap(picture.Width, picture.Height);
            gr = Graphics.FromImage(buffer);
            gr.Clear(Color.White);

            picture.Image = buffer;
        }

        private void picture_MouseMove(object sender, MouseEventArgs ev)
        {
            if (ev.Button != MouseButtons.Left)
            {
                return;
            }

            switch (tool)
            {
                case 1:
                    gr.DrawLine(pen, ev.X, ev.Y, picture.Width / 2, picture.Height / 2);
                    break;
                case 2:
                    gr.DrawRectangle(pen, ev.X - 20, ev.Y - 20, 40, 40);
                    break;
                case 3:
                    gr.DrawPolygon(pen, new Point[] { new Point(ev.X, ev.Y - 20), new Point(ev.X + 20, ev.Y + 20), new Point(ev.X - 20, ev.Y + 20) });
                    break;

            }

            picture.Image = buffer;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tool = 1;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            tool = 2;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            tool = 3;
        }

        private void ˆ‚ÂÚToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();

            pen.Color = colorDialog.Color;
        }

        private void picture_MouseClick(object sender, MouseEventArgs ev)
        {
            if (ev.Button == MouseButtons.Right) 
            {
                gr.Clear(Color.White);
                picture.Image = buffer;
            }
        }
    }
}