using System.Drawing.Drawing2D;

namespace mouse_event_paint
{
    public partial class Form1 : Form
    {
        Shape[] shapes = new Shape[100];        // зурсан дүрсүүдийн массив
        int count = 0;                          // массивт байгаа дүрсийн тоо
        Shape current;                          // одоо зурж буй дүрс
        string shapeType = "line";              // сонгосон дүрсийн төрөл
        Color penColor = Color.Black;
        float penWidth = 2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            toolStripComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripComboBox1.SelectedIndex = 1;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            switch (shapeType)
            {
                case "line": //дурсийг зурж эхлэх үед тухайн дүрсийн төрөлд тохирсон объект үүсгэнэ
                    current = new LineDraw(penColor, penWidth, e.Location);
                    break;
                case "rect":
                    current = new RectDraw(penColor, penWidth, e.Location);
                    break;
                    // шинэ дүрсүүдийг энд нэмнэ
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (current != null)
            {
                current.End = e.Location;
                this.Invalidate();      // Paint үзэгдлийг дуудна
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (current != null)
            {
                current.End = e.Location;
                if (count < shapes.Length)
                    shapes[count++] = current;   // массивд нэмнэ
                current = null;
                this.Invalidate();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            for (int i = 0; i < count; i++)
                shapes[i].Draw(e.Graphics);
            if (current != null)
                current.Draw(e.Graphics);
        }

        // Tools → Шулуун
        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeType = "line";
        }

        // Tools → Тэгш өнцөгт
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeType = "rect";
        }

        // Tools → Өнгө
        private void өнгөToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                penColor = colorDialog1.Color;
        }

        // Өргөн
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            penWidth = Convert.ToInt32(toolStripComboBox1.SelectedItem);
        }
    }
}
