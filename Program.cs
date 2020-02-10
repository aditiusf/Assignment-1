using System;

namespace Assignment1_Spring2020
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            Console.WriteLine("The pattern is:");
            PrintPattern(n);

            int n2 = 6;
            PrintSeries(n2);

            string s = "09:15:35PM";
            string t = UsfTime(s);
            Console.WriteLine(t);

            int n3 = 110;
            int k = 11;
            UsfNumbers(n3, k);

            string[] words = new string[] { "abcd", "dcba", "lls", "s", "sssll" };
            PalindromePairs(words);

            Console.WriteLine();
            Console.WriteLine("Enter the number of stones");
            int st = Convert.ToInt32(Console.ReadLine());
            if (st <= 0)
                Console.WriteLine("Enter valid number");
            else
                Stones(st);
        }

    private static void PrintPattern(int n)
        {
            try
            {
                if (n <= 0)
                    return;
                for (int i = n; i > 0; i--)
                {
                    Console.Write(i + " "); //Print numbers in a row
                }
                Console.WriteLine();
                PrintPattern(n - 1); //Call function again to print numbers in next row
            }
            catch
            {
                Console.WriteLine("Exception Occured while computing printPattern");
            }
        }
        private static void PrintSeries(int n2)
        {
            try
            {
                Console.WriteLine("The series is:");
                int a = 1;
                for (int i = 2; i <= n2 + 1; i++) //Loop to print n2 numbers 
                {
                    Console.Write(a + " ");
                    a = a + i;
                }
            }
            catch
            {
                Console.WriteLine("Exception Occured while computing printSeries");
            }
        }
        public static string UsfTime(string s)
        {
            try
            {
                Console.WriteLine();
                int hh = Convert.ToInt32(s.Substring(0, 2)); //Extract hours, minutes and seconds   
                int mm = Convert.ToInt32(s.Substring(3, 2));
                int ss = Convert.ToInt32(s.Substring(6, 2));
                String zone = (s.Substring(8, 2));
                if (zone == "PM") //Add 12 hours if it is PM
                {
                    hh += 12;
                }
                if (hh <= 24 && mm <= 60 && ss <= 60)
                {
                    int seconds = (hh * 60 * 60 + mm * 60 + ss); //Total seconds
                    int secondsPerhour = 60 * 45;
                    int temp1 = seconds % secondsPerhour;
                    int USFhours = (seconds - temp1) / secondsPerhour;
                    int USFseconds = temp1 % 60;
                    int USFminutes = (temp1 - USFseconds) / 45;
                    Console.WriteLine("Converted time in USF Clock format UU:SS:FF is:");
                    return (USFhours + ":" + USFminutes + ":" + USFseconds);
                }
                else
                    Console.WriteLine("Time format is not valid");
            }
            catch
            {
                Console.WriteLine("Exception Occured while computing UsfTime");
            }
            return null;
        }
        public static void UsfNumbers(int n3, int k)
        {
            try
            {
                Console.WriteLine("USF numbers are:");
                for (int i = 1; i < n3; i++)
                {
                    if (i % k == 1) // Print K numbers per line
                    {
                        Console.WriteLine();
                    }
                    String str = "";
                    if (i % 3 == 0) // Concatenate string if multiple of 3 or 5 or 7
                    {
                        str += "U";
                    }
                    if (i % 5 == 0)
                    {
                        str += "S";
                    }
                    if (i % 7 == 0)
                    {
                        str += "F";
                    }
                    if (str.Equals("")) // Print number if not multiple of 3 or 5 or 7
                    {
                        str += i;
                    }
                    Console.Write(str + " ");
                }

            }
            catch
            {
                Console.WriteLine("Exception occured while computing UsfNumbers()");
            }
        }
        public static void PalindromePairs(string[] words)
        {
            try
            {
                Console.WriteLine();
                Console.Write("The palindrome indices are: ");
                for (int i = 0; i < words.Length - 1; i++)
                {
                    for (int j = 0; j < words.Length; j++)
                    {
                        if (words[i] != words[j])
                        {
                            String check_str = words[i] + words[j]; //Concatenate the Words
                            int len = check_str.Length;
                            int isPallendrome = 0;
                            for (int k = 0; k < len / 2; k++)
                            {
                                if (check_str[k] == check_str[len - k - 1]) //Check if the concatenated String is a Pallendrome
                                    isPallendrome = 1;
                                else
                                {
                                    isPallendrome = 0;
                                    break;
                                }
                            }
                            if (isPallendrome == 1)
                            {
                                Console.Write("[" + i + "," + j + "]"); //Print the indices of the matched Words
                            }
                        }
                    }
                }

            }
            catch
            {
                Console.WriteLine("Exception occured while computing     PalindromePairs()");
            }
        }
         public static void Stones(int n4)
        {
            try
            {
                if (n4 % 4 == 0) //Lost if no. of stones is multiple of 4
                    Console.WriteLine("false: You lost");
                else
                {
                    Console.Write("You win by picking stones: ");
                    while (n4 > 3) //For 2nd player to play, no. of stones should be more than 3
                    {
                        int pick = 1;
                        int nmod4 = n4 % 4;
                        if (nmod4 > 0)
                        {
                            pick = nmod4; //Stones left for 2nd player are multiple of 4
                        }
                        Console.Write(pick + ",");
                        n4 = n4 - pick;
                    }
                    Console.Write(n4); //1st player wins if no. of stones are 1 or 2 or 3 
                }

            }
            catch
            {
                Console.WriteLine("Exception occured while computing Stones()");
            }
        }

    }
}
