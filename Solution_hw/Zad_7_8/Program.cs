using System;
using System.Threading.Tasks;

namespace Zad_7_8
{
    class Program
    {
        static void Main(string[] args)
        {
            // Main method is the only method that
            // can ’t be marked with async .
            // What we are doing here is just a way for us to simulate
            // async - friendly environment you usually have with
            // other .NET application types ( like web apps , win apps etc .)
            // Ignore main method , you can just focus on LetsSayUserClickedAButtonOnGuiMethod() as a
            // first method in call hierarchy .
            var t = Task.Run(() => LetsSayUserClickedAButtonOnGuiMethod());
            Console.Read();
        }

        private static async void LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result = await GetTheMagicNumber();
            Console.WriteLine(result);
        }
        private static async Task<int> GetTheMagicNumber()        {
            return await IKnowIGuyWhoKnowsAGuy();
        }
        private static async Task<int> IKnowIGuyWhoKnowsAGuy()
        {
            return await IKnowWhoKnowsThis(10) + await IKnowWhoKnowsThis(5);
        }
        private static async Task<int> IKnowWhoKnowsThis(int n)
        {
            return await FactorialDigitSum(n);
        }



        //  7. ZADATAK
        private static async Task<int> FactorialDigitSum(int n)
        {
            int fact = await Task.Run(() => Factorial(n));
            return await Task.Run(() => DigitSum(fact));
        }

        private static int Factorial(int n)
        {
            int fact = 1;
            for (int i = 2; i <= n; i++)
            {
                fact *= i;
            }
            return fact;
        }

        private static int DigitSum(int n)
        {
            int sum = 0;
            foreach (char c in n.ToString().ToCharArray())
            {
                sum += (int)char.GetNumericValue(c);
            }
            return sum;
        }
    }
}
