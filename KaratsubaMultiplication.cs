using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack_Hackerank_1
{
    class KaratsubaMultiplication
    {
        public static void Main1(string[] args)
        {
            /*Basic formula of Karatsuba multiplication is 
             * if p = aX + b
             * and q = cX + d
             * then pq = acX^2 + ((a+b)(c+d)-ac-bd)X + db
             */

            while (true)
            {
                string firstInput = Console.ReadLine();
                string secondInput = Console.ReadLine();

                Console.WriteLine($"The product of given two numbers is : {normalProduct(firstInput, secondInput, firstInput.Length, secondInput.Length)}");
            }
        }

        private static string KaratsubaProduct(string firstInput, string secondInput, int firstNumberLength, int secondNumberLength)
        {
            if (firstNumberLength < secondNumberLength)
            {
                firstInput = appendZeros(firstInput, (secondNumberLength - firstNumberLength));
            }
            else if (secondNumberLength < firstNumberLength)
            {
                secondInput = appendZeros(secondInput, (firstNumberLength - secondNumberLength));
            }

            int[] finalProduct = new int[firstInput.Length];
            return KaratsubaProduct(firstInput, secondInput, firstInput.Length, finalProduct);
        }

        private static string KaratsubaProduct(string firstInput, string secondInput, int length, int[] finalProductArray)
        {
            if (length == 0)
            {
                return "0";
            }
            else if (length == 1)
            {
                return (Int32.Parse(firstInput) * Int32.Parse(secondInput)).ToString();
            }
            else
            {
                return "a";
            }
        }

        private static string appendZeros(string firstInput, int zerosToAdd)
        {
            string returnString = new string('0', zerosToAdd);

            return returnString + firstInput;
        }

        private static string normalProduct(string firstInput, string secondInput, int firstNumberLength, int secondNumberLength)
        {
            int[] finalProduct = new int[firstNumberLength + secondNumberLength];

            var firstInputArray = firstInput.ToCharArray();
            var secondInputArray = secondInput.ToCharArray();

            for (int i = firstInputArray.Length-1; i >=0 ; i--)
            {
                for (int j = secondInputArray.Length-1; j >=0 ; j--)
                {
                    int mul = Int16.Parse(firstInputArray[i].ToString()) * Int16.Parse(secondInputArray[j].ToString());
                    int sum = finalProduct[i + j + 1] + mul;
                    finalProduct[i + j] += sum / 10;
                    finalProduct[i + j + 1] = sum % 10;
                }
            }

            return String.Join("", finalProduct);
        }


        // A[] represents coefficients  
        // of first polynomial 
        // B[] represents coefficients  
        // of second polynomial 
        // m and n are sizes of A[]  
        // and B[] respectively 
        static int[] multiply(int[] A, int[] B,
                                int m, int n)
        {
            int[] prod = new int[m + n - 1];

            // Initialize the porduct polynomial 
            for (int i = 0; i < m + n - 1; i++)
            {
                prod[i] = 0;
            }

            // Multiply two polynomials term by term 
            // Take ever term of first polynomial 
            for (int i = 0; i < m; i++)
            {
                // Multiply the current term of first polynomial 
                // with every term of second polynomial. 
                for (int j = 0; j < n; j++)
                {
                    prod[i + j] += A[i] * B[j];
                }
            }

            return prod;
        }

        // A utility function to print a polynomial 
        static void printPoly(int[] poly, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(poly[i]);
                if (i != 0)
                {
                    Console.Write("x^" + i);
                }
                if (i != n - 1)
                {
                    Console.Write(" + ");
                }
            }
        }

        // Driver code 
        public static void Main8(String[] args)
        {

            // The following array represents  
            // polynomial 5 + 10x^2 + 6x^3 
            int[] A = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            // The following array represents 
            // polynomial 1 + 2x + 4x^2 
            int[] B = { 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int m = A.Length;
            int n = B.Length;

            Console.WriteLine("First polynomial is n");
            Console.WriteLine();
            printPoly(A, m);
            Console.WriteLine("nSecond polynomial is n");
            Console.WriteLine();
            printPoly(B, n);
            Console.WriteLine();
            int[] prod = multiply(A, B, m, n);

            Console.WriteLine("nProduct polynomial is n");
            Console.WriteLine();
            printPoly(prod, m + n - 1);

            Console.WriteLine($"my product will be : {normalProduct("1234567890987654321", "0987654321123456789", m, n)}");
        }
    }

}
