using System;
{
    //Inherits from MobileObject
    class Cat : MobileObject
    {
        // Variable declaration.
        public float LegLength;
        public float TorsoLength;
        public float HeadLength;
        public float TailLength;
        public float Mass;

        /*Constructor for Cat class
        (name, Id, and pos variables are inherited from MobileObject class)*/
        public Cat(string name, int Id, Position pos, float legLength, float torsoLength, float HeadLength, float tailLength, float mass)
                : base(name, Id, pos)
        {
            this.LegLength = legLength;
            this.TorsoLength = torsoLength;
            this.HeadLength = HeadLength;
            this.TailLength = tailLength;
            this.Mass = mass;
        }

        //Get and Set accessors for Cat class variables. 
        public float getLegLength()
        {
            return LegLength;
        }
        //Setting Leg Length variable to be greater than zero.
        public void setLegLength(float value)
        {
            if (value > 0) LegLength = value;
        }

        public float getTorsoLength()
        {
            return TorsoLength;
        }

        //Setting Torso Length variable to be greater than zero.
        public void setTorsoLength(float value)
        {
            if (value > 0) TorsoLength = value;
        }

        public float getHeadLength()
        {
            return HeadLength;
        }

        //Setting Head Length variable to be greater than zero.
        public void SetHeadLength(float value)
        {
            if (value > 0) HeadLength = value;
        }

        public float getTailLength()
        {
            return TailLength;
        }

        //Setting Tail Length variable to be greater than zero.
        public void setTailLength(float value)
        {
            if (value > 0) TailLength = value;
        }

        public float getMass()
        {
            return Mass;
        }

        //Setting Mass variable to be greater than zero.
        public void setMass(float value)
        {
            if (value > 0) Mass = value;
        }


        //TotalLength() method calculates total length of a Cat.
        private float TotalLength()
        {
            return LegLength + TorsoLength + HeadLength;
        }

        //Print method that overrrides virtual string Print() in the base class. 
        public override string Print()
        {
            return "Name: " + Name + " ID: " + Id + " Positions: " + Pos.getX() + " "
                   + Pos.getY() + " " + Pos.getZ() + " Leg length: " + LegLength +
                   " Torso Height: " + TorsoLength + " Head Height: " + HeadLength +
                   " Tail Length " + TailLength + " Mass " + Mass + " Total Height: " + TotalLength();
        }

        public override string toString()
        {
            return "Name: " + Name + " ID: " + Id + " Positions: " + Pos.getX() + " "
                 + Pos.getY() + " " + Pos.getZ() + " Leg length: " + LegLength +
                 " Torso Height: " + TorsoLength + " Head Height: " + HeadLength +
                 " Tail Length " + TailLength + " Mass " + Mass + " Total Height: " + TotalLength();
        }

        public override string toStringS()
        {
            return "Name: " + Name + " ID: " + Id;
        }
    }
}
