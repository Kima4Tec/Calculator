
namespace Calculator
{
    internal class Program
    {
        public static double num1;
        public static double num2;


        static void Main(string[] args)
        {
            //setting up the calculator
            Data.Banner(10, 2);
            Data.BannerText(13, 3);
            Data.NumLockKeys(10, 5);
            Console.CursorVisible = true;
            //starting the program
            GetInput();
        }
        /// <summary>
        /// getting input from user and putting it into the claculator
        /// </summary>
        static void GetInput()
        {
            Data.Pos(11, 21, "Tast ENTER efter hvert tal");
            Console.SetCursorPosition(13, 6);
            string num1a = Console.ReadLine();
            Console.SetCursorPosition(13, 7);
            num1 = double.Parse(num1a);

            char input = Console.ReadKey().KeyChar;

            Console.SetCursorPosition(13, 8);
            string num2a = Console.ReadLine();
            num2 = double.Parse(num2a);

                GetChoice(input);
            Console.SetCursorPosition(0, 26);

        }

        /// <summary>
        /// Switch checking operator
        /// </summary>
        /// <param name="choice"></param>
        static void GetChoice(char choice)
        {
            switch (choice)
            {
                case '+':
                    PerformAddition();
                    break;
                case '-':
                    PerformSubtraction();
                    break;
                case '*':
                    PerformMultiplication();
                    break;
                case '/':
                    PerformDivision();
                    break;
                default:
                    Data.Pos(11, 21, "Du skal taste et gyldigt tegn");
                    break;
            }
        }

        /// <summary>
        /// Performing addition
        /// </summary>
        static void PerformAddition()
        {

            double result = num1 + num2;
        static double GetNumberInput()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (double.TryParse(input, out double number))
                {
                    return number;
                }
                else
                {
                    Data.Pos(11, 21, "Du skal taste et gyldigt tal");
                }
            }
        }
            Data.Pos(13, 9, $"= {result}");
        }

        /// <summary>
        /// Performing subtraction
        /// </summary>
        static void PerformSubtraction()
        {
            double result = num1 - num2;
            Data.Pos(13, 9, $"= {result}");
        }

        static void PerformMultiplication()
        {
            double result = num1 * num2;
            Data.Pos(13, 9, $"= {result}");
        }

        /// <summary>
        /// Performing division
        /// </summary>
        static void PerformDivision()
        {
            if (num2 != 0)
            {
                double result = num1 / num2;
                Data.Pos(13, 9, $" = {result}");
            }
            else
            {
                Data.Pos(11, 21, "Error: Man kan ikke dividere med 0.");
            }
        }
    }
}
