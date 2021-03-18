using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;

namespace readwriteapp
{
    class Class1
    {
        
        static void Main(string[] args)
        {
            string text;
            /*@"ds";*/
            Console.WriteLine("Welcome to greek to greeklish converter");
            Console.WriteLine("Type a text in greek to turn it to greeklish");
            Console.WriteLine();
            do
            {
                Console.WriteLine("Type only greek letters please");
                text = Console.ReadLine();

            } while (!IsGreek(text));
            Console.WriteLine($"Your text in greeklish: {ConvertToGlish(text)}");
            Console.WriteLine();
            Console.WriteLine("Do yoy want to export the text in a text file? Y/N\n");
            ExportQuestion(text);
          

        }

        private static void ExportQuestion(string text)
        {
            string answer = Console.ReadLine();

            if (answer.ToLower() == "y")
            {
                Console.WriteLine("Type path");

                Validation(text);
            }
            else if (answer.ToLower() == "n")
            {
                Console.WriteLine("Thank you!");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Type Y or N");
                ExportQuestion(text);
            }
        }

        private static void Validation(string text)
        {
            string path = Console.ReadLine();
            if (!IsValidPath(path))
            {
                Console.WriteLine("Error, try again.");
                Validation(text);
            }
            else if (IsValidPath(path))
            {
                FileMan(text, path);
            }
        }

        private static void FileMan(string text, string path)
        {
            bool success = true;
            Random rnd = new Random();
            if (File.Exists(path))
            {
                Console.WriteLine("This file allready exist");
                Console.WriteLine("Do you want to override this file? Y/N");
                string answer2 = Console.ReadLine();
                if (answer2 == "Y")
                {
                    try
                    {
                        File.WriteAllText(path, String.Empty);
                        StreamWriter sw = new StreamWriter(path, true, Encoding.UTF8);
                        sw.WriteLine($"Original text: {text}");
                        sw.WriteLine($"Your text in greeklish: {ConvertToGlish(text)}");
                        sw.Close();
                    }
                    catch (Exception e)
                    {
                        success = false;
                        Console.WriteLine("Exception: " + e.Message);
                        Console.WriteLine("Change path");
                        Validation(text);
                    }
                    if(success == true)
                    {
                        Console.WriteLine("Your file is ready!");
                        Console.WriteLine("Thank you!");
                        Environment.Exit(0);
                    }
                }
                if (answer2 == "N")
                {
                    try
                    {
                        
                        using (StreamWriter sw = File.CreateText(path.Replace(".", rnd.Next(1, 100).ToString() + ".")))
                        {
                            sw.WriteLine($"Original text: {text}");
                            sw.WriteLine($"Your text in greeklish: {ConvertToGlish(text)}");
                            sw.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        success = false;
                        Console.WriteLine("Exception: " + e.Message);
                        Console.WriteLine("Change path");
                        Validation(text);
                    }
                    if (success == true)
                    {
                        Console.WriteLine("Your file is ready!");
                        Console.WriteLine(path.Replace(".", rnd.Next(1, 100).ToString() + "."));
                        Console.WriteLine("Thank you!");
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Console.WriteLine("Try again!");
                    FileMan(text, path);
                }
            }
            else
            {
                try
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine($"Original text: {text}");
                        sw.WriteLine($"Your text in greeklish: {ConvertToGlish(text)}");
                        sw.Close();
                    }
                }
                catch (Exception e)
                {
                    success = false;
                    Console.WriteLine("Exception: " + e.Message);
                    Console.WriteLine("Change path");
                    Validation(text);
                }
                if(success == true)
                {
                    Console.WriteLine("Your file is ready!");
                    Console.WriteLine("Thank you!");
                    Environment.Exit(0);
                }

            }
        }

        public static bool IsGreek(string text)
        {
            return text.Any(c => c >= 0x0370 && c <= 0x03FF);
        }

        public static bool IsValidPath(string path)
        {
            Regex driveCheck = new Regex(@"^[a-zA-Z]:\\$");
            if (!driveCheck.IsMatch(path.Substring(0, 3))) return false;
            string strTheseAreInvalidFileNameChars = new string(Path.GetInvalidPathChars());
            strTheseAreInvalidFileNameChars += @":/?*" + "\"";
            Regex containsABadCharacter = new Regex("[" + Regex.Escape(strTheseAreInvalidFileNameChars) + "]");
            if (containsABadCharacter.IsMatch(path.Substring(3, path.Length - 3)))
                return false;
            else
                return true;
            
        }

        public static string ConvertToGlish(string text)
        {
            char[] arr = text.ToLower().ToCharArray();
            List<char> list = new List<char>();
            for (int y = 0; y < arr.Length; y++)
            {
                if (arr[y] >= 0x0370 && arr[y] <= 0x03FF)
                {
                    switch (arr[y])
                    {
                        case 'α':
                        case 'ά':
                            list.Add('a');
                            break;
                        case 'β':
                            list.Add('b');
                            break;
                        case 'γ':
                            list.Add('g');
                            break;
                        case 'δ':
                            list.Add('d');
                            break;
                        case 'ε':
                        case 'έ':
                            list.Add('e');
                            break;
                        case 'ζ':
                            list.Add('z');
                            break;
                        case 'η':
                        case 'ή':
                            list.Add('i');
                            break;
                        case 'θ':
                            list.Add('8');
                            break;
                        case 'ι':
                        case 'ί':
                        case 'ϊ':
                            list.Add('i');
                            break;
                        case 'κ':
                            list.Add('k');
                            break;
                        case 'λ':
                            list.Add('l');
                            break;
                        case 'μ':
                            list.Add('m');
                            break;
                        case 'ν':
                            list.Add('n');
                            break;
                        case 'ξ':
                            list.Add('3');
                            break;
                        case 'ο':
                        case 'ό':
                            list.Add('o');
                            break;
                        case 'π':
                            list.Add('p');
                            break;
                        case 'ρ':
                            list.Add('r');
                            break;
                        case 'σ':
                        case 'ς':
                            list.Add('s');
                            break;
                        case 'τ':
                            list.Add('t');
                            break;
                        case 'υ':
                        case 'ύ':
                            list.Add('y');
                            break;
                        case 'φ':
                            list.Add('f');
                            break;
                        case 'χ':
                            list.Add('h');
                            break;
                        case 'ψ':
                            list.Add('p');
                            list.Add('s');

                            break;
                        case 'ω':
                        case 'ώ':
                            list.Add('w');
                            break;
                        case ' ':
                            list.Add(' ');
                            break;
                        case '!':
                            list.Add('!');
                            break;
                        case '?':
                            list.Add('?');
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    list.Add(arr[y]);
                }
            }
            text = string.Join("", list);
            return text;
        }

    }
}