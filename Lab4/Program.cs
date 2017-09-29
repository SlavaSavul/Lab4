using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ConsoleApp1
{

    class Elem
    {
        int data;
        Elem next;


        public Elem(int i, Elem j)
        {
            data = i;
            next = j;
        }

        public int Data
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




        public void Push(int i)
        {
            head = new Elem(i, head);
            kol++;
        }
        public int Pop()
        {

            kol--;
            int ret = head.Data;
            head = head.Next;
            return ret;

        }


        public static Stack operator -(Stack stack, int el)
        {

            Stack InterimSteck = new Stack();
            int obj;


            while (stack.Head != null)
            {
                obj = stack.Pop();
              if (obj == el) continue;

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
            int obj = stack.Pop();
            stack.Push(obj);
            stack.Push(obj);
            return stack;
        }
        public static bool operator <(Stack stack1, Stack stack2)
        {
            int[] MasElem1 = new int[stack1.Kol];
            int[] MasElem2 = new int[stack2.Kol];

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
                   

                        
                            if (MasElem2[ii] == MasElem1[jj]) break;
                        
                       

                    
                    if (jj == MasElem1.Length - 1) stack1.Push(MasElem2[ii]);
                }
            }
            return true;
        }
        public static bool operator >(Stack stack2, Stack stack1)
        {
            int[] MasElem1 = new int[stack1.Kol];
            int[] MasElem2 = new int[stack2.Kol];

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



                    if (MasElem2[ii] == MasElem1[jj]) break;




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
                int value = obj.Pop();                
                B.Push((int)Math.Pow(value, 3));                            
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

                int value = obj.Pop();
                if ( value < 0)
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

                  int value = obj.Pop();
                  
                      Sum += value;
                      B.Push(value);
                  
                 
              }
              while (B.Head != null)
              {
                  obj.Push(B.Pop());
              }
              return Sum;
          }
          
        public static int ExclamatorySentences(this string str)
        {
            int kol = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '!')
                    kol++;
            }

            return kol;
        }


        public static bool NegativeElements(this Stack st)
        {

            Stack B = new Stack("", "");
            bool ret=false;
            while (st.Head!=null)
            {
                int i = st.Pop();
                if(i<0)
                {
                    ret = true;
                }
                B.Push(i);
            }


            while (B.Head != null)
            {
                st.Push(B.Pop());
            }
            return ret;
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
            A.Push(2);
            A.Push(-2);
            Stack B = new Stack("Slava", "BSTU");
            B.Push(6);
            B.Push(2);
            B.Push(10);

            Console.WriteLine("Counter '!'   "+MyMath.ExclamatorySentences("1s!wqsa!"));
            Console.WriteLine("Negative    " + MyMath.NegativeElements(A));

            //bool t=A < B;
            //A=A - 2;
            //A++;
            //MyMath.Cube(ref A);
            //MyMath.Null(ref A);
            // Console.WriteLine(MyMath.Sum(ref A));  Console.WriteLine();


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
