using System.Collections.Generic;
using System.Drawing;

namespace KMeans
{
    class Centroid
    {
        private int centroidX, centroidY;
        private Color centroidColour;
        List<Point> pointsList = new List<Point>();
        public Centroid(int centroidX, int centroidY, Color centroidColour)
        {
            this.centroidX = centroidX;
            this.centroidY = centroidY;
            this.centroidColour = centroidColour;
        }
        public void addPointToCentroid(Point point)
        {
            pointsList.Add(point);
        }
        public void clearPointsList()
        {
            pointsList.Clear();
        }
        public List<Point> GetPointsList()
        {
            return pointsList;
        }
        public void setX(int X)
        {
            centroidX = X;
        }
        public void setY(int Y)
        {
            centroidY = Y;
        }
        public void setColour(Color colour)
        {
            centroidColour = colour;
        }
        public int getX()
        {
            return centroidX;
        }
        public int getY()
        {
            return centroidY;
        }
        public Color getColour()
        {
            return centroidColour;
        }
    }

}