
using System;
using System.Drawing;
using System.Security.Cryptography;

namespace Calculator
{
    internal class Program
    {
        public static string? numText;
        public static double num1;
        public static double num2;
        public static char[] keyInput = new char[20];
        public static char operatorInput;

        static void Main()
        {
            //setting up the calculator
            Console.Clear();
            Data.Banner(10, 2);
            Data.BannerText(13, 3);
            Data.NumLockKeys(10, 5);
            Console.CursorVisible = false;
            //starting the program
            GetInput1();
        }
        /// <summary>
        /// getting input from user and putting it into the calculator.
        /// When an operator key is entered it calls GetInput2()
        /// </summary>

        static void TimerCallback(object state)
        {
            Main();
        }

        static void GetInput1()
        {
            int currentIndex = 0;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                //Max input is 18 digits
                if (currentIndex < 19)
                {

                    //Get first number. ReadKey with 'true' hides the pressed key
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    //Add key input to a char variable
                    char pressedKey = keyInfo.KeyChar;

                    // If the pressed key is a digit, store it in a char array
                    if (char.IsDigit(pressedKey))
                    {
                        keyInput[currentIndex] = pressedKey;
                        currentIndex++;
                    }
                    //Check for input of operators
                    if (GetOperatorInput(pressedKey, keyInfo))
                    {
                        // Exit the loop if operator is pushed
                        break;
                    }
                    //Convert input to a string for positioning
                    numText = new string(keyInput, 0, currentIndex);

                    //Erase former display and insert new
                    Data.Pos(11, 6, "                       ");
                }
                else
                {
                    Data.Pos(12, 6, "Fejl: For mange cifre");
                    numText = "";
                    currentIndex = 0;
                    Timer timer = new Timer(TimerCallback, null, 500, Timeout.Infinite);
                    timer.Dispose();
                }
                Data.Pos(32 - numText.Length, 6, numText);
            }
            //Convert the number to an integer
            num1 = Convert.ToInt64(Program.numText);
            currentIndex = 0;
            numText = "";

            GetInput2(currentIndex);

        }

        /// <summary>
        /// Getting second number and when pressing equal or ENTER,
        /// the numbers are calculated and shown as result. Pressing
        /// the key c, clears the screen.
        /// </summary>
        /// <param name="currentIndex"></param>
        private static void GetInput2(int currentIndex)
        {
            while (true)
            {
                //Max input is 18 digits
                if (currentIndex < 19)
                {
                // ReadKey with 'true' hides the pressed key
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                char pressedKey = keyInfo.KeyChar;

                Console.SetCursorPosition(13, 6);

                    // If the pressed key is a digit, store it in a char array
                    if (char.IsDigit(pressedKey))
                    {
                        keyInput[currentIndex] = pressedKey;
                        currentIndex++;
                    }

                //Checking for pressing equal or enter
                if (MarkEqualButton(pressedKey, keyInfo))
                {
                    // Exit the loop
                    break;
                }

                //Convert input to a string for positioning
                Program.numText = new string(keyInput, 0, currentIndex);
                Data.Pos(11, 6, "                       ");
                Data.Pos(32 - numText.Length, 6, numText);

                }
                else 
                {
                    Data.Pos(12, 6, "Fejl: For mange cifre");
                    numText = "";
                    currentIndex = 0;
                    Timer timer = new Timer(TimerCallback, null, 500, Timeout.Infinite);
                    timer.Dispose();

                }
            }
            num2 = Convert.ToInt64(Program.numText);
            //get operator
            char input = operatorInput;

            GetChoice(input);
            Console.SetCursorPosition(0, 26);

            while (input != 'c')
            {
                //Data.Pos(11, 21, "Tast c for at cleare skærmen              ");
                Console.SetCursorPosition(11, 22);
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                input = char.ToLower(keyInfo.KeyChar);
                ClearScreen(input);
            }
        }

        /// <summary>
        /// Resetting operator input and marking Equal button
        /// </summary>
        /// <param name="pressedKey"></param>
        /// <returns></returns>
        static bool MarkEqualButton(char pressedKey, ConsoleKeyInfo keyInfo)
        {
            if (pressedKey == '=' || keyInfo.Key == ConsoleKey.Enter)
            {
                //resetting the operator buttons
                Data.Pos(30, 14, " + ", ConsoleColor.Yellow);
                Data.Pos(30, 12, " - ", ConsoleColor.Yellow);
                Data.Pos(30, 10, " / ", ConsoleColor.Yellow);
                Data.Pos(30, 8, " * ", ConsoleColor.Yellow);
                Data.Pos(24, 14, "[=]", ConsoleColor.Blue);
                return true;
            }
            else { return false; }
        }

        static bool GetOperatorInput(char pressedKey, ConsoleKeyInfo keyInfo)
        {
            //Checking for operator input
            if (pressedKey == '/' || pressedKey == '*' || pressedKey == '-' || pressedKey == '+')
            {
                switch (pressedKey)
                {
                    case '+':
                        Data.Pos(30, 14, "[+]", ConsoleColor.Blue);
                        break;
                    case '-':
                        Data.Pos(30, 12, "[-]", ConsoleColor.Blue);
                        break;
                    case '*':
                        Data.Pos(30, 8, "[*]", ConsoleColor.Blue);
                        break;
                    case '/':
                        Data.Pos(30, 10, "[/]", ConsoleColor.Blue);
                        break;
                    default:
                        Data.Pos(11, 21, "Du skal taste et gyldigt tegn");
                        break;
                }
                Console.ForegroundColor = ConsoleColor.White;

                //Adding operator choice to a field
                operatorInput = keyInfo.KeyChar;

                return true;

            }
            else
            {
                return false;
            }
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
            string resultText = result.ToString();
            Data.Pos(11, 6, "                       ");
            Data.Pos(32 - resultText.Length, 6, resultText);
        }

        /// <summary>
        /// Performing subtraction
        /// </summary>
        static void PerformSubtraction()
        {
            double result = num1 - num2;
            string resultText = result.ToString();
            Data.Pos(11, 6, "                       ");
            Data.Pos(32 - resultText.Length, 6, resultText);
        }
        /// <summary>
        /// Performing multiplication
        /// </summary>
        static void PerformMultiplication()
        {
            double result = num1 * num2;
            string resultText = result.ToString();
            Data.Pos(11, 6, "                       ");
            Data.Pos(32 - resultText.Length, 6, resultText);
        }

        /// <summary>
        /// Performing division
        /// </summary>
        static void PerformDivision()
        {
            if (num2 != 0)
            {
                double result = num1 / num2;
                string resultText = result.ToString();
                Data.Pos(11, 6, "                       ");
                Data.Pos(32 - resultText.Length, 6, resultText);
            }
            else
            {
                Data.Pos(13, 6, "Fejl: Division med 0", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Clearing screen
        /// </summary>
        /// <param name="clearing"></param>
        static void ClearScreen(char clearing)
        {

            switch (clearing)
            {
                case 'c':
                    Main(); ;
                    break;
            }
        }
    }
}
