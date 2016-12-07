using System;

namespace BattleShip.BLL.Requests
{
    public class Coordinate
    {
        public Coordinate(int x, int y)
        {
            XCoordinate = x;
            YCoordinate = y;
        }

        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }

        public override bool Equals(object obj)
        {
            Coordinate otherCoordinate = obj as Coordinate;

            if (otherCoordinate == null)
            {
                return false;
            }

            return otherCoordinate.XCoordinate == this.XCoordinate 
                && otherCoordinate.YCoordinate == this.YCoordinate;
        }
        
        public override int GetHashCode() 
        { 
            string uniqueHash = this.XCoordinate.ToString() + this.YCoordinate.ToString() + "00"; 
            return (Convert.ToInt32(uniqueHash)); 
        } 
    }
}
