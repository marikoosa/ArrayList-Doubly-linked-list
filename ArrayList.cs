using System;
using System.Collections.Generic;
namespace Assign2
{
    class ArrayList<T>
    {
        // Merges lists A and B into the list C
        public static ArrayList<T> Merge(ArrayList<T> A, ArrayList<T> B)

        {   //Defining the size of the list C as the sum of A&B list sizes.
            ArrayList<T> C = new ArrayList<T>(A.count + B.count);

            // Putting the contents of List A in the list C
            for (int i = 0; i < A.count; i++)
            {
                C.Append(A.GetItem(i));
            }
            // Putting the contents of List B in the list C
            for (int i = 0; i < B.count; i++)
            {
                C.Append(B.GetItem(i));
            }

            return C;
            }

        public T[] arraylist;
        public int count;

        //initialize the size of the array
        public ArrayList(int size)
        {
            arraylist = new T[size + 1]; 
            count = 0;
        }

        //get and set accessors 
        public T GetItem(int index)
        {
            return arraylist[index];
        }

        public void SetItem(int index, T value)
        {
            while (index >= arraylist.GetLength(0)) 
                Grow();

            arraylist[index] = value;
            count++;
        }

        //Growing the arraylist
        private void Grow()
        {
            //puting arraylist items in the new arraylist  - arraylist2  
            T[] arraylist2 = new T[arraylist.Length * 2]; 
            for (int i = 0; i <= arraylist2.Length; i++)
                arraylist2[i] = arraylist[i];
            arraylist = arraylist2;
        }

        public void Append(T value)
        {
            SetItem(count, value);
            count++;
        }

        // Sorting the arralist 
        public void InPlaceSort()
        {
            Array.Sort(arraylist);
        }

        public void Swap(int index1, int index2) 
        {
            //storing arralist item - index1 in temp variable 
            T temp = arraylist[index1];
            arraylist[index1] = arraylist[index2];
            arraylist[index2] = temp;
        }

        //Deleting the last item of the arraylist 
        public void DeleteLast(int index)
        {
            //Decreasing the count of the arraylist 
            arraylist[count--] = default;
        }
        //print all elements in array starting from 0 to end
        public string StringPrintAllForward()
        {
            string ret = "";
            for (int i = 0; i < arraylist.Length; i++)
            {
                ret += arraylist[i] + "\n";//
            }
            return ret;

        }
        //print all elements in array starting from end to 0
        public string StringPrintAllReverse()
        {
            string ret = "";
            for (int i = arraylist.Length - 1; i >= 0; i--)
            {
                ret += arraylist[i] + "\n";//
            }
            return ret;
        }
        //Makes the arraylist empty
        public void DeleteAll()
        {
            arraylist = new T[arraylist.GetLength(0)];//
            Console.WriteLine("Arraylist is empty");
        }
    }
}
