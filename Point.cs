using System.Drawing;

namespace KMeans
{
    class Point
    {
        private int pointX, pointY, pointZone;
        Color pointColour = Color.Black;
        public Point(int pointX, int pointY)
        {
            this.pointX = pointX;
            this.pointY = pointY;
        }
        public int getX()
        {
            return pointX;
        }
        public int getY()
        {
            return pointY;
        }
        public void setColour(Color colour)
        {
            pointColour = colour;
            if (colour == Color.Red) { pointColour = Color.DarkRed; }
            if (colour == Color.Blue) { pointColour = Color.DarkBlue; }
            if (colour == Color.Green) { pointColour = Color.DarkGreen; }
            if (colour == Color.Orange) { pointColour = Color.DarkOrange; }
            if (colour == Color.Yellow) { pointColour = Color.Orange; }
        }
        public Color getColour()
        {
            return pointColour;
        }
    }


}