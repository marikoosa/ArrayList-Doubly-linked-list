using System;
{
    class Grid //creates the grid

    {
        // Variable declaration for the Grid class
        public const int size = 16;//this means the grid will be Size by Size (ex 10x10)
        public const int cell_size = 10;
        public const int BAD_ID = -1;
        // initialize an array list of array lists of type cell
        public ArrayList<ArrayList<Cell>> cells = new ArrayList<ArrayList<Cell>>(size);

        //constructor creates Grid by calling CreateGrid() method 
        public Grid()
        {
            CreateGrid();
        }

        //GenerateID() method generates and returns cell id
        public int GenerateID(int x, int y) 
        {
            return (x + y * size + 1000);
        }

        //CreateGrid() method creates grid using the 2 Dimensional array of cells.
        public void CreateGrid() //creates the grid using the 2D array
        {
            for (int i = 0; i < size; i++)
            {
                // create new row as a new array list of type cell with size = to size
                cells.SetItem(i, new ArrayList<Cell>(size));
                for (int j = 0; j < size; j++)
                {
                    int Id = GenerateID(i, j);
                    int x = i;
                    int y = j;
                    // set each item in the newly created row as the Cells.
                    cells.GetItem(i).SetItem(j, new Cell(Id, x, y));
                }
            }
        }

        public int GetMaxVal()//finds maximum so cells won't get off the grid
        {
            return (size * cell_size - 1);
        }

        public int GetCellID(Position position) //returns cell id where it is located based on the object's position
        {
            // Negative numbers are not useful.
            if (position.x < 0 || position.y < 0)
            {
                return BAD_ID;
            }

            int max_val = GetMaxVal();

            // Numbers greater than max_val are not useful.
            if (position.x > max_val || position.y > max_val)
            {
                return BAD_ID;
            }

            int x = (int)position.x / cell_size;
            int y = (int)position.y / cell_size;

            return GenerateID(x, y);
        }


        public void Print(DLinkedList mobile)//prints out the grid
        {

            Console.WriteLine("Grid:");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    // cells.GetItem(j) gets the row, then calling get item on it again gets the individual element
                    if (cells.GetItem(j).GetItem(i).objs.Count > 0)
                    {
                        //Printing the cells that hold mobile objects. 
                        Console.Write(string.Format("[{0,2}]\t", (cells.GetItem(j).GetItem(i).objs[0] as MobileObject).GetId()));
                    }
                    else
                    {
                        //if the cell does not contain an object it print an empty cell [ ], no id"
                        Console.Write("[  ]\t");
                    }

                }
                // Printing values 10 to 160 across X and Y "axis" 
                Console.WriteLine(cell_size * (i + 1));
            }

            for (int j = 0; j < size; j++)
            {
                Console.Write((j + 1) * cell_size + "\t");
            }
            Console.WriteLine("");

            //Printing which object is in which cell on the grid
            foreach (MobileObject mob in mobile)
            {
                Console.WriteLine(mob.GetName() + " is in cell with id: " + mob.GetPositionCell());
            }
        }
    }
}
