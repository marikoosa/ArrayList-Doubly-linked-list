using System;
{
    //Snake class Inherites from MobileObject
    class Snake : MobileObject
    {
        // Variable declaration.
        float Length;
        float Radius;
        float Mass;
        int Vertebrae;

        /*Constructor for the Snake class
        (name, Id, and pos variables are inherited from MobileObject class)*/
        public Snake(string name, int Id, Position pos, float length, float radius, float mass, int vertebrae)
                : base(name, Id, pos)
        {
            this.Length = length;
            this.Radius = radius;
            this.Mass = mass;
            this.Vertebrae = vertebrae;

        }

        //Get and Set accessors for Snake class variables. 
        public float getLength()
        {
            return Length;
        }

        //Setting Length variable to be greater than zero.
        public void setLength(float value)
        {
            if (value > 0) Length = value;
        }

        public float getRadius()
        {
            return Radius;
        }
        //Setting Radius variable to be greater than zero.
        public void setRadius(float value)
        {
            if (value > 0) Radius = value;
        }

        public int getVertebrae()
        {
            return Vertebrae;
        }
        public void setVertebrae(int value)

        {
            if (value >= 200 && value <= 300) Vertebrae = value;
        }

        public float getMass()
        {
            return Mass;
        }
        public void setMass(float value)
        {
            if (value > 0) Mass = value;
        }

        //BoundingVolume() Calculates the Volume
        private float BoundingVolume()
        {
            return (float)(Length * Math.Pow(Radius, 2) * Math.PI);
        }

        //Overrrides virtual string Print() in the base class. 
        public override string toString()
        {
            return "Name: " + Name
                   + " ID: " + Id + " Positions: " + Pos.getX() + " " + Pos.getY() + " " + Pos.getZ()
                   + " Length: " + Length + " Height: " + Radius + " Width: " + Vertebrae
                   + " Volume: " + BoundingVolume();
        }

        public override string toStringS()
        {
            return "Name: " + Name + " ID: " + Id;
        }

    }
}
