namespace mouse_event_paint
{
    // Бүх дүрсийн суурь класс
    public abstract class Shape
    {
        public Color Color;     // үзгийн өнгө
        public float Width;     // үзгийн зузаан
        public Point Start;     // хулганы товч дарсан цэг
        public Point End;       // хулганы заагчийн одоогийн цэг

        public Shape(Color color, float width, Point start)
        {
            Color = color;
            Width = width;
            Start = start;
            End = start;
        }

        // Удамшсан класс бүр өөрийнхөөрөө зурна
        public abstract void Draw(Graphics g);
    }
}
