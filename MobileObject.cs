using System;

{
    //IComparable provides a method (CompareTo()) of comparing two objects
    abstract class MobileObject : IComparable
    {
        // Variable declaration
        public string Name;
        public int Id;
        public Position Pos;
        public int PositionCell;

        //Constructor for the base class
        public MobileObject(string Name, int Id, Position Pos)
        {
            this.Name = Name;
            this.Id = Id;
            this.Pos = Pos;
        }

        // Get and Set accessors for MobileObject variables.
        public void SetName(string desiredname)
        {
            Name = desiredname;
        }

        public string GetName()
        {
            return Name;
        }

        public void SetId(int desiredid)
        {
            Id = desiredid;
        }

        public int GetId()
        {
            return Id;
        }

        /* Declaring a virtual Print method to Allow
           Cat and Snake sub classes to override it*/
        public virtual string Print()
        {
            return Name + " " + Id;
        }

        /* Move method changes object position
        and calculates a new position*/
        public void Move(float dx, float dy, float dz)
        {
            Pos.setX(dx + Pos.getX());
            Pos.setY(dy + Pos.getY());
            Pos.setZ(dz + Pos.getZ());
        }
        //Get and Set accessors for PositionCell

        public void SetPositionCell(int DesiredPositionCell)
        {
            this.PositionCell = DesiredPositionCell;
        }

        public int GetPositionCell()
        {
            return PositionCell;
        }
     
        /* IComparable enables CompareTo method to
      compare objects (of type MobileObject) with their Z value */
        public int CompareTo(object obj)
        {
            if (obj is String)
            {
                return Convert.ToInt32(this.Pos.getZ() <= (obj as MobileObject).Pos.getZ());  // compare user names
            }
            throw new ArgumentException("Object is not a MobileObject");
        }

        public abstract string toString();
        public abstract string toStringS();

    }
}
