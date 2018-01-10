using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace triangleSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            triangle T = new triangle();

            //tests
            T.getSquare(3, 4, 5);               //nice
            T.getSquare(3.0, 4.0, 5.0);         //nice
            T.getSquare(3, 4, -5);              //catched
            T.getSquare(3, 4, 0);               //catched
            T.getSquare(3, 4, -0);              //catched
            T.getSquare(3, 4, 0.0);             //catched
            T.getSquare(1, 1, 1);               //catched
            T.getSquare(0.03, 0.04, 0.05);      //nice
            T.getSquare(3E-10, 4E-10, 5E-11);   //catched
            T.getSquare(3E-9, 4E-9, 4E-9);      //catched
            T.getSquare(3E-9, 4E-9, 5.1E-9);    //catched
            T.getSquare(3E-9, 4E-9, 5.01E-9);   //not catched, because difference square < 1E-18
            T.getSquare(3E10, 4E10, 5E11);      //catched
            T.getSquare(-3, -4, -5);            //catched
            T.getSquare(0.0, 0.0, 0.0);         //catched
            T.getSquare(5, 4, 3);               //nice
        }
    }

    class triangle
    {
        /// <summary>
        ///     Calculate right triangle square
        /// </summary>
        /// <param name="a">Cathetus</param>
        /// <param name="b">Cathetus</param>
        /// <param name="c">Hypotenuse</param>
        /// <returns>Square</returns>
        public double getSquare(double a, double b, double c)
        {
            try
            {
                if (a <= 0 || b <= 0 || c <= 0)
                    throw new ArgumentException(String.Format("Cathetus or hypotenus <= 0!"
                        + "a = {0}, b = {1}, c = {2}", a, b, c));
                if (a < 1E-9 || b < 1E-9 || c < 1E-9)
                    throw new ArgumentException(String.Format("Too small value a = {0}, b = {1}, c = {2}", a, b, c));
                findHypotenuse(ref a, ref b, ref c);
                checkTriangle(a, b, c);
                return 0.5 * a * b;
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
            
        }

        //Find hypotenuse,
        //like bubble sort
        private void findHypotenuse(ref double a, ref double b, ref double c)
        {
            if (a > b)
                swap(ref a, ref b);
            if (b > c)
                swap(ref b, ref c);
        }

        //Check triangle: a^2 + b^2 = c^2
        private void checkTriangle(double a, double b, double c)
        {
            double sq_c = c * c;
            double sq_ab = a * a + b * b;
            if (Math.Abs(sq_ab - sq_c) > 1E-18)
                throw new ArgumentException(String.Format("Right triangle not exist!"
                    + "a^2 + b^2 = {0}, c^2 = {1}", sq_ab, sq_c));
        }

        private void swap(ref double var1, ref double var2)
        {
            double exVar = var1;
            var1 = var2;
            var2 = exVar;
        }
    }
}
