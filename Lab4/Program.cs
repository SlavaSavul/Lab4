using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ConsoleApp1
{

    class Elem
    {
        object data;
        Elem next;


        public Elem(object i, Elem j)
        {
            data = i;
            next = j;
        }

        public object Data
        {
            get { return data; }
        }

        public Elem Next
        {
            get { return next; }

        }


    }
    class Stack
    {
        int kol;
        Elem head;

        Owner owner;
        DATE date;

        public Elem Head
        {
            get { return head; }
        }
        public int Kol
        {
            get { return kol; }
        }
        public string Name
        {
            get { return owner.name; }
        }
        public string Organization
        {
            get { return owner.organization; }
        }
        public int Id
        {
            get { return owner.id; }
        }
        public string Date
        {
            get { return date.thisDay.ToString("d"); }
        }



        Stack()
        {
            head = null;
            kol = 0;
        }
        public Stack(string name, string organization) : this()
        {
            owner = new Owner(name, organization);
            date = new DATE();
        }



        public class Owner
        {
            public readonly int id;
            public readonly string name;
            public readonly string organization;

            public Owner(string name, string organization)
            {
                id = (name + organization).GetHashCode();
                this.name = name;
                this.organization = organization;
            }
        }
        public class DATE
        {
            public readonly DateTime thisDay;
            public DATE()
            {
                thisDay = DateTime.Today;
            }
        }




        public void Push(object i)
        {
            head = new Elem(i, head);
            kol++;
        }
        public object Pop()
        {

            if (head == null) return null;
            kol--;
            object ret = head.Data;
            head = head.Next;
            return ret;

        }


        public static Stack operator -(Stack stack, object el)
        {

            Stack InterimSteck = new Stack();
            object obj;


            while (stack.Head != null)
            {
                obj = stack.Pop();
                if (obj.GetType() == el.GetType())
                {
                    if (el is int)
                    {
                        if ((int)obj == (int)el) continue;
                    }
                    else if (el is string)
                    {
                        if (String.Compare((string)obj, (string)el) == 0) continue;
                    }

                }
                InterimSteck.Push(obj);
            }

            while (InterimSteck.Head != null)
            {
                stack.Push(InterimSteck.Pop());
            }
            return stack;
        }
        public static Stack operator ++(Stack stack)
        {
            object obj = stack.Pop();
            stack.Push(obj);
            stack.Push(obj);
            return stack;
        }
        public static bool operator <(Stack stack1, Stack stack2)
        {
            object[] MasElem1 = new object[stack1.Kol];
            object[] MasElem2 = new object[stack2.Kol];

            int i = 0;
            int j = 0;


            while (stack2.Head != null)
            {
                MasElem2[i] = stack2.Pop();
                i++;
            }


            while (stack1.Head != null)
            {
                MasElem1[j] = stack1.Pop();
                j++;
            }

            j--;
            while (j >= 0)
            {
                stack1.Push(MasElem1[j]);
                j--;
            }
            i--;
            while (i >= 0)
            {
                stack2.Push(MasElem2[i]);
                i--;
            }
            for (int ii = 0; ii < MasElem2.Length; ii++)
            {
                for (int jj = 0; jj < MasElem1.Length; jj++)
                {
                    if (MasElem2[ii].GetType() == MasElem1[jj].GetType())
                    {

                        if (MasElem1[jj] is int)
                        {
                            if ((int)MasElem2[ii] == (int)MasElem1[jj]) break;
                        }
                        if (MasElem1[jj] is string)
                        {
                            if (String.Compare((string)MasElem2[ii], (string)MasElem1[jj]) == 0) break;
                        }

                    }
                    if (jj == MasElem1.Length - 1) stack1.Push(MasElem2[ii]);
                }
            }
            return true;
        }
        public static bool operator >(Stack stack2, Stack stack1)
        {
            object[] MasElem1 = new object[stack1.Kol];
            object[] MasElem2 = new object[stack2.Kol];

            int i = 0;
            int j = 0;


            while (stack2.Head != null)
            {
                MasElem2[i] = stack2.Pop();
                i++;
            }


            while (stack1.Head != null)
            {
                MasElem1[j] = stack1.Pop();
                j++;
            }

            j--;
            while (j >= 0)
            {
                stack1.Push(MasElem1[j]);
                j--;
            }
            i--;
            while (i >= 0)
            {
                stack2.Push(MasElem2[i]);
                i--;
            }
            for (int ii = 0; ii < MasElem2.Length; ii++)
            {
                for (int jj = 0; jj < MasElem1.Length; jj++)
                {
                    if (MasElem2[ii].GetType() == MasElem1[jj].GetType())
                    {

                        if (MasElem1[jj] is int)
                        {
                            if ((int)MasElem2[ii] == (int)MasElem1[jj]) break;
                        }
                        if (MasElem1[jj] is string)
                        {
                            if (String.Compare((string)MasElem2[ii], (string)MasElem1[jj]) == 0) break;
                        }

                    }
                    if (jj == MasElem1.Length - 1) stack1.Push(MasElem2[ii]);
                }
            }
            return true;
        }


    }

    static class MyMath
    {
        public static void Cube(ref Stack obj)
        {
            Stack B = new Stack("", "");

            while (obj.Head != null)
            {

                object value = obj.Pop();
                if (value is int)
                {
                    value = Math.Pow((int)value, 3);
                    B.Push(value);
                }
                else
                {
                    B.Push(value);
                }
            }
            while (B.Head != null)
            {
                obj.Push(B.Pop());
            }

        }
        public static void Null(ref Stack obj)
        {
            Stack B = new Stack("", "");

            while (obj.Head != null)
            {

                object value = obj.Pop();
                if (value is int && (int)value < 0)
                {
                    value = 0;
                    B.Push(value);
                }
                else
                {
                    B.Push(value);
                }
            }
            while (B.Head != null)
            {
                obj.Push(B.Pop());
            }
        }
        public static int Sum(ref Stack obj)
        {
            Stack B = new Stack("", "");
            int Sum = 0;
            while (obj.Head != null)
            {

                object value = obj.Pop();
                if (value is int)
                {
                    Sum += (int)value;
                    B.Push(value);
                }
                else
                {
                    B.Push(value);
                }
            }
            while (B.Head != null)
            {
                obj.Push(B.Pop());
            }
            return Sum;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Stack A = new Stack("Myname", "Myorganization");
            A.Push(1);
            A.Push(2);
            A.Push(-3);
            A.Push(4);
            A.Push("ff");
            A.Push(-2);



            while (A.Head != null)
            {
                Console.WriteLine(A.Pop());
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(A.Date);
            Console.WriteLine(A.Name);
            Console.WriteLine(A.Organization);





            Console.ReadKey();
        }



    }

}
