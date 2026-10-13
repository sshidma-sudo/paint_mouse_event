using System.Drawing.Drawing2D;

namespace mouse_event_paint
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen p;
        bool draw;       // хулганы товч дарагдсан эсэх
        int x0, y0;      // заагчийн өмнөх байрлал
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.SmoothingMode = SmoothingMode.AntiAlias;   // ирмэгийг зөөллөнө
            p = new Pen(Color.Black, 2);
            p.StartCap = LineCap.Round;                  // зураас тасархай харагдахаас сэргийлнэ
            p.EndCap = LineCap.Round;
            draw = false;
            //for (int i = 1; i <= 10; i++)
            //  toolStripComboBox1.Items.Add(i);      // эхлээд нэмнэ
            toolStripComboBox1.SelectedIndex = 0;      // дараа нь сонгоно
            toolStripComboBox1.DropDownStyle = ComboBoxStyle.DropDownList; // гараар бичихийг хаана
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                draw = true;
                x0 = e.X;
                y0 = e.Y;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (draw)
            {
                g.DrawLine(p, x0, y0, e.X, e.Y);
                x0 = e.X;
                y0 = e.Y;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (draw) { draw = false; }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void өнгөToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                p.Color = colorDialog1.Color;

        }

        private void toolStripComboBox1_Click_1(object sender, EventArgs e)
        {
            p.Width = Convert.ToInt32(toolStripComboBox1.SelectedItem);
        }
    }
}
