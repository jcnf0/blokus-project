using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Blokus
{
    public static class MathOperation
    {
        public static Vector2 AngleToVector(float angle)
        {
            return new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
        }
        public static bool Collision(Vector2 Pos1, Vector2 Pos2, float decallageX, float decallageY)
        {
            if (Pos1.X >= Pos2.X - decallageX &&
                Pos1.X <= Pos2.X + decallageX &&
                Pos1.Y >= Pos2.Y - decallageY &&
                Pos1.Y <= Pos2.Y + decallageY)
                return true;
            else
                return false;
        }
        public static bool RectCollision(Rectangle rect1, Rectangle rect2)
        {
            if (rect1.Right >= rect2.Left &&
                rect1.Left <= rect2.Right &&
                rect1.Top <= rect2.Bottom &&
                rect1.Bottom >= rect2.Top)
                return true;
            else
                return false;
        }
        public static bool RectCollisionAgrandis(Rectangle rect1, Rectangle rect2, int decallage)
        {
            rect1.X -= decallage;
            rect1.Y -= decallage;
            rect1.Width += decallage * 2;
            rect1.Height += decallage * 2;

            rect2.X -= decallage;
            rect2.Y -= decallage;
            rect2.Width += decallage * 2;
            rect2.Height += decallage * 2;

            if (rect1.Right >= rect2.Left &&
                rect1.Left <= rect2.Right &&
                rect1.Top <= rect2.Bottom &&
                rect1.Bottom >= rect2.Top)
                return true;
            else
                return false;
        }
        public static int Norme(Vector2 vecteur)
        {
            int norme = Convert.ToInt32(Math.Sqrt(Math.Pow(vecteur.X, 2) + Math.Pow(vecteur.Y, 2)));
            return norme;
        }
        public static int DistanceBetween(Vector2 vecteur1, Vector2 vecteur2)
        {
            Vector2 vecteur = vecteur2 - vecteur1;
            int norme = (int)Math.Sqrt(Math.Pow(vecteur.X, 2) + Math.Pow(vecteur.Y, 2));
            return norme;
        }
        public static Vector2 GetDirection(Vector2 orientation, double angle, Vector2 Pos1, Vector2 Pos2)
        {
            Vector2 direction = new Vector2();
            angle = Math.Atan((orientation.Y) / (orientation.X));
            direction = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
            if (angle >= 0 && Pos1.X >= Pos2.X)
                direction = -direction;
            if (angle <= 0 && Pos1.Y <= Pos2.Y)
                direction = -direction;
            return direction;
        }
        public static float VectorToAngle(Vector2 Pos2, Vector2 Pos1)
        {
            Vector2 orientation = Pos2 - Pos1;
            float angle = (float)Math.Atan((orientation.Y) / (orientation.X));
            if (angle >= 0 && Pos1.X >= Pos2.X)
                angle += (float)Math.PI;
            if (angle < 0 && Pos1.Y <= Pos2.Y)
                angle += (float)Math.PI;
            if (angle == (float)Math.PI * 3 / 2)
                angle += (float)Math.PI;
            return angle;
        }
        public static Vector2 GetDirection(Vector2 Pos2, Vector2 Pos1)
        {
            Vector2 orientation = Pos2 - Pos1;
            float angle = (float)Math.Atan((orientation.Y) / (orientation.X));
            if (angle >= 0 && Pos1.X >= Pos2.X)
                angle += (float)Math.PI;
            if (angle < 0 && Pos1.Y <= Pos2.Y)
                angle += (float)Math.PI;
            if (angle == (float)Math.PI * 3 / 2)
                angle += (float)Math.PI;
            return AngleToVector(angle);
        }

        public static float NearestVector2(List<Vector2> list, Vector2 cible)
        {
            Vector2 nearest = Vector2.Zero;
            foreach (var vector in list)
            {
                if (nearest == Vector2.Zero)
                    nearest = vector;
                if (DistanceBetween(nearest, cible) >= DistanceBetween(cible, vector))
                    nearest = vector;
            }
            float distance = DistanceBetween(nearest, cible);
            return distance;
        }

        public static Vector2 RandomDirection()
        {
            Vector2 retour = new Vector2();
            switch (Game1.aleatoire.Next(2))
            {
                case 0:
                    retour.X = (float)Game1.aleatoire.Next(0, 10) / 10;
                    break;
                case 1:
                    retour.X = -(float)Game1.aleatoire.Next(0, 10) / 10;
                    break;
            }
            switch (Game1.aleatoire.Next(2))
            {
                case 0:
                    retour.Y = (float)Game1.aleatoire.Next(0, 10) / 10;
                    break;
                case 1:
                    retour.Y = -(float)Game1.aleatoire.Next(0, 10) / 10;
                    break;
            }
            return retour;
        }
    }
}