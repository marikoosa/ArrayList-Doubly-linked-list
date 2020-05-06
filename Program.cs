using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

{
    class Program
    {
        static void Main(string[] args)
        {

            // Reading in cat and snake name files 
            string[] catnames = File.ReadAllLines(@"Assignment 1 catnames.txt");
            string[] snakenames = File.ReadAllLines(@"Assignment 1 snakenames.txt");
            Random random = new Random(); //Creating "random" algorithm to hold randomly generated values 

            Grid grid = new Grid();// creating a Grid by calling Grid() consructor 

            //Creates a linked list of moblie objects.
            DLinkedList mobile = new DLinkedList();

            //Using regular expression to eliminate the numbering of the cat names from the file that we read in. 
            Regex regex = new Regex(@"\d*\.\s*(\w*)");
            Match match;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 5; j++)
                {

                    if (i == 0)
                    {
                        match = regex.Match(catnames[random.Next(0, catnames.Length)]);
                        string randomcatname = match.Groups[1].Value;

                        /*adding mobile objects to a linked list and 
                            determinig the the value range of cat attributes*/
                        mobile.AddLast(new Cat(randomcatname,
                                               mobile.GetCount(),
                                               new Position(grid.GetMaxVal()),
                                               /*To make Cat attribute values a float I used (float)
                                                 keyword, devided the values by 2 and added a floating point number.*/
                                               (float)((random.NextDouble() / 2) + 0.5), //leglength
                                               (float)((random.NextDouble() / 2) + 0.5), // torsoheight
                                               (float)((random.NextDouble() / 2) + 0.5),//headheight
                                               (float)((random.NextDouble() / 2) + 0.5),//taillength
                                               (float)((random.NextDouble() / 2) + 0.5)));//mass
                    }

                    else

                    {  /*adding mobile objects to a linked list and 
                            determinig the the value range of snake attributes*/
                        mobile.AddLast(new Snake(snakenames[random.Next(0, snakenames.Length)],
                                                 mobile.GetCount(),
                                                 new Position(grid.GetMaxVal()),
                                                 (float)((random.NextDouble() / 2) + 0.5), //length
                                                 (float)((random.NextDouble() / 10) + 0.05), // radius
                                                 (float)((random.NextDouble() * 100) + 1),//mass kg
                                                 random.Next(200, 301)));//vertabrae

                    }
                    (mobile.tail.element as MobileObject).SetPositionCell(grid.GetCellID((mobile.tail.element as MobileObject).Pos));
                    Move((mobile.tail.element as MobileObject), 0, 0, 0, true);
                    int index = (i * 5) + j;
                }
            }

            //The method lets users create a new object.
            void CreateObject()
            {   //The user can choose which type of object they want to create. 
                Console.Write("Choose the type of object you want to create \n1. Create a Cat \n2. Create a Snake\nChoice: ");
                string objType = Console.ReadLine();//Storing the user input in objType variable

                //If the user makes an incorrect choice they are prompted to try again 
                if (objType != "1" && objType != "2")
                {
                    Console.WriteLine("Stop testing my program, please.");
                    return;
                }
                else
                { /*If the user makes a correct choice for the first question they are asked 
                        to enter the attributes that cats and snakes share*/

                    Console.Write("Enter name. \nChoice: ");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter position.");
                    Console.Write("Pos x: ");
                    string posx = Console.ReadLine();
                    Console.Write("Pos y: ");
                    string posy = Console.ReadLine();
                    Console.Write("Pos z: ");
                    string posz = Console.ReadLine();

                    /*If the user has selected the cat in the first question 
                        they are asked to enter the cat attributes attributes*/
                    if (objType == "1")
                    {

                        Console.Write("Enter leg length. \nChoice: ");
                        string leg = Console.ReadLine(); //Storing user input in the leg variable

                        Console.Write("Enter torso length \nChoice: ");
                        string torso = Console.ReadLine();

                        Console.Write("Enter head size. \nChoice: ");
                        string head = Console.ReadLine();

                        Console.Write("Enter tail length. \nChoice: ");
                        string tail = Console.ReadLine();

                        Console.Write("Enter mass. \nChoice: ");
                        string mass = Console.ReadLine();


                        try
                        {
                           //Ensuring that object creation fails if the user enters a negative value for the properties

                            if (float.Parse(leg) <= 0 || float.Parse(torso) <= 0 || float.Parse(head) <= 0
                                || float.Parse(tail) <= 0 || float.Parse(mass) <= 0)
                            {
                                Console.WriteLine("Can't have negative value for properties.");
                                return;
                            }
                            //Adding the new cat object to the list 
                            mobile.AddLast(new Cat(name,
                                                   mobile.GetCount(),
                                                   new Position(float.Parse(posx), float.Parse(posy), float.Parse(posz)),
                                                   float.Parse(leg),
                                                   float.Parse(torso),
                                                   float.Parse(head),
                                                   float.Parse(tail),
                                                   float.Parse(mass)));
                        }
                        catch
                        {   //Prints if the object creation fails due to the user entering invalid input 
                            Console.WriteLine("Invalid selection on one of the traits.");
                        }


                    }
                    /*If the user has selected to create a snake in the first question 
                      they are asked to enter the snake attributes*/
                    else if (objType == "2")
                    {

                        Console.Write("Enter length. \nChoice: ");
                        string length = Console.ReadLine();//Storing user input in the length variable 

                        Console.Write("Enter radius \nChoice: ");
                        string radius = Console.ReadLine();

                        Console.Write("Enter mass. \nChoice: ");
                        string mass = Console.ReadLine();

                        Console.Write("Enter vertebrae. \nChoice: ");
                        string vertebrae = Console.ReadLine();
                        try
                        {
                            //Ensuring that object creation fails if the user enters a negative value 
                            if (float.Parse(length) <= 0 || float.Parse(radius) <= 0 || float.Parse(mass) <= 0 || float.Parse(vertebrae) <= 0)
                            {
                                Console.WriteLine("Can't have negative value for properties.");
                                return;
                            }
                            //Adding the new Snake object to the list 
                            mobile.AddLast(new Snake(name,
                                                     mobile.GetCount(),
                                                     new Position(float.Parse(posx), float.Parse(posy), float.Parse(posz)),
                                                     float.Parse(length),
                                                     float.Parse(radius),
                                                     float.Parse(mass),
                                                     int.Parse(vertebrae)));

                        }
                        catch
                        {
                            // Prints if the object creation fails due to the user entering invalid input
                            Console.WriteLine("Invalid selection on one of the traits.");

                        }
                    }
                        // update new objects positioncellid
                        (mobile.tail.element as MobileObject).SetPositionCell(grid.GetCellID((mobile.tail.element as MobileObject).Pos));
                    Move((mobile.tail.element as MobileObject), 0, 0, 0, true);
                }
            }

            /* Move() method is called by MoveObject(). MoveObject() asks the user
                which object they want to move and to which cell. Move() moves the object.*/

            void Move(MobileObject obj, float dx, float dy, float dz, bool flag = false)
            {
                int currentcellid = obj.GetPositionCell();
                obj.Move(dx, dy, dz);
                int newcellid = grid.GetCellID(obj.Pos);

                // 0,0,0 move is used for updating
                // flag is for initial placement
                // checking dz != 0 is incase the moved object has a new z value
                // thats higher than the z value of another object in the cell

                if (currentcellid != newcellid || flag || dz!= 0)
                {
                    int size = Grid.size;
                    obj.SetPositionCell(newcellid);
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            // for each cell, check if the id == currentcellid
                            // if it does, remove the object from the cell
                            if (grid.cells.GetItem(j).GetItem(i).GetCellId() == currentcellid &&
                                grid.cells.GetItem(j).GetItem(i).objs.Contains(obj))

                            {
                                grid.cells.GetItem(j).GetItem(i).removeObj(obj);
                                // Console.WriteLine("removed Object");
                            }
                            // for each cell, check if the id == newcellid
                            //  if it does, add the object to the cell
                            if (grid.cells.GetItem(j).GetItem(i).GetCellId() == newcellid)
                            {
                              
                                grid.cells.GetItem(j).GetItem(i).addObj(obj);
                            }
                        }
                    }
                }
            }

            /* MoveObject() asks the user which position they want to move
                the object from and where to place them. */

            void MoveObject()

            {   //making sure that we catch whe the user enters invalid id 
                Console.Write("Enter object Id: ");
                int Id = -1;

                try
                {
                    Id = Int32.Parse(Console.ReadLine());//if the id = -1 = user input 
                }
                catch
                {
                    Console.WriteLine("Id must be an integer.");//letting the user know that it is an invalid id 
                    return;
                }

                foreach (MobileObject obj in mobile)
                {
                    if (obj.GetId() == Id)
                    {
                        float dx, dy, dz;

                        try
                        {
                            Console.Write("Input dx: ");
                            dx = float.Parse(Console.ReadLine());// Reading in the user input for dx
                            Console.Write("Input dy: ");
                            dy = float.Parse(Console.ReadLine());
                            Console.Write("Input dz: ");
                            dz = float.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Invalid entry, values must be floats.");
                            return;
                        }
                        Move(obj, dx, dy, dz);

                    }
                }
            }

            void printObjects()
            {
                foreach (MobileObject mob in mobile)
                {
                    Console.WriteLine(mob.Print());
                }
            }
            /******************************************************************************************************************/

            //Moves all objects and updates the grid. 
            void MoveAndUpdate()
            {
                foreach (MobileObject mob in mobile)
                {   //Calling move method and passing updated x,y,z parameters 
                    Move(mob, (float)((random.NextDouble() * 10) + 0.1), (float)((random.NextDouble() * 10) + 0.1), (float)((random.NextDouble() * 2) + 0.1));
                }
            }
            
            void MoveOrigin()
            {
                Console.WriteLine("Change Origin.");
                float dx, dy, dz;
                try
                {
                    Console.Write("Input dx: ");
                    dx = float.Parse(Console.ReadLine());
                    Console.Write("Input dy: ");
                    dy = float.Parse(Console.ReadLine());
                    Console.Write("Input dz: ");
                    dz = float.Parse(Console.ReadLine());
                }
                catch
                {   //catches invalid entries 
                    Console.WriteLine("Invalid entry, values must be floats.");
                    return;
                }

                foreach (MobileObject mob in mobile)
                {
                    Move(mob, -dx, -dy, -dz);
                }
            }
            void FindWithinDistance()
            {
                float distance;
                try
                {
                    Console.Write("Input distance: ");
                    distance = float.Parse(Console.ReadLine());
                }
                catch
                {   
                    Console.WriteLine("Invalid entry, values must be floats.");
                    return;
                }

                foreach (MobileObject mob in mobile)
                {
                    float mobdist = (float)Math.Sqrt(Math.Pow(mob.Pos.getX(), 2) + Math.Pow(mob.Pos.getY(), 2) + Math.Pow(mob.Pos.getZ(), 2));
                    if (mobdist <= distance)
                    {
                        Console.WriteLine(mob.Print());
                    }
                }
            }
            bool continueflag = true;
            while (continueflag)
            {
                //using switch statements to implement a menu 
                Console.Write("Menu\n1. Create Object\n2. Move Object\n3. Print Grid\n4. Print all objects\n5. Move and Update\n6. Move Origin\n7. Find Within Distance\nQ. Quit\nInput: ");
                string userinput = Console.ReadLine();
                switch (userinput)
                {
                    case "1":
                        CreateObject();
                        break;

                    case "2":
                        MoveObject();
                        break;

                    case "3":
                        grid.Print(mobile);
                        break;

                    case "4":
                        printObjects();
                        break;

                    case "5":
                        MoveAndUpdate();
                        break;

                    case "6":
                        MoveOrigin();
                        break;

                    case "7":
                        FindWithinDistance();
                        break;

                    case "Q":
                        continueflag = false;
                        break;

                    default:
                        Console.WriteLine("Unknown input");
                        break;

                }
            }
        }
    }
}
