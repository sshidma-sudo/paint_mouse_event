namespace mouse_event_paint
{
    // Шулуун зурах класс
    public class LineDraw : Shape
    {
        public LineDraw(Color color, float width, Point start)
            : base(color, width, start) { }

        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(Color, Width))
            {
                g.DrawLine(pen, Start, End);
            }
        }
    }
}