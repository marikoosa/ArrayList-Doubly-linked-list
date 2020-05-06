using System;
{
    class Position
    {
        //Variable declaration for Position class.
        public float x, y, z;

        //Constructor for Position class that takes 3 arguments
        public Position(float x, float y, float z)

        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        // Constructor for position class that only takes one argument.
        public Position(int maxsize)
        {
            Random random = new Random();
            this.x = random.Next(0, maxsize);
            this.y = random.Next(0, maxsize);
            this.z = 0;
        }

        // Gettters and setters.
        public void setX(float valX)
        {
            this.x = valX;
        }

        public float getX()
        {
            return this.x;
        }

        public void setY(float valY)
        {
            this.y = valY;
        }

        public float getY()
        {
            return this.y;
        }

        public void setZ(float valZ)
        {
            this.z = valZ;
        }

        public float getZ()
        {
            return this.z;
        }
    }
}
