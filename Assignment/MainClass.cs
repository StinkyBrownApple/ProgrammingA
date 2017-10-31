using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment
{
    class MainClass
    {
        static bool quit = false; //Create a variable that checks if we want to quit or not
        static void Main(string[] args)
        {
            SetSettings(); //Change some settings so the console looks better
            while (!quit) //Keep showing the main menu until we want to quit
            {
                MainMenu();
            }
        }

        private static void SetSettings()
        {
            Console.Title = "Text Analyser";
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
        }
        private static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Text Analyser\nMade by Steven Lacey");
            Console.WriteLine("\nWhat would you like to do?\n\n1. Analyse text\n2. Analyse tone of text\n3. Find and replace\n4. Quit");
            switch(InputManager.GetOption(4)) //Get which option they would like to do
            {
                case 1:
                    AnalyseText(); 
                    break;
                case 2:
                    AnalyseTextTone();
                    break;
                case 3:
                    FindAndReplace();
                    break;
                case 4:
                    quit = true; //If they pick 4, they want to quit, so we can stop looping the main menu so the program will close
                    break;
                default:
                    break;
            }
        }
        private static void AnalyseText()
        {
            Console.Clear();
            Console.WriteLine("How would you like to input the text?\n\n1. Keyboard\n2. .txt file\n3. Go back");
            switch (InputManager.GetOption(3)) //Find out whether they want keyboard or file input
            {
                case 1:
                    AnalyseKeyboardInput();
                    break;
                case 2:
                    AnalyseTextFileInput();
                    break;
                case 3:
                    return;
                default:
                    break;
            }
        }
        private static void AnalyseTextTone()
        {
            Console.Clear();
            Console.WriteLine("How would you like to input the text?\n\n1. Keyboard\n2. .txt file\n3. Go back");
            switch (InputManager.GetOption(3)) //Find out whether they want keyboard or file input
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Enter the text you would like to analyse");
                    TextAnalyser.AnalyseTone(Console.ReadLine());
                    break;
                case 2:
                    TextAnalyser.AnalyseTone(InputManager.GetFileInput());
                    break;
                case 3:
                    return;
                default:
                    break;
            }
        }
        private static void FindAndReplace()
        {
            Console.Clear();
            Console.WriteLine("How would you like to input the text?\n\n1. Keyboard\n2. .txt file\n3. Go back");
            switch (InputManager.GetOption(3)) //Do some stuff depending on whether they chose keyboard or file
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Enter the text to search through:"); //Get them to enter the text to look through
                    string keyboardInput = Console.ReadLine(); //store it here
                    while(keyboardInput == "")
                    {
                        keyboardInput = Console.ReadLine(); //If they just press enter, keep going until they actually enter something
                    }
                    string keyboardOutput = TextAnalyser.FindAndReplace(keyboardInput); //Find and replace and store the output in a string
                    Console.Clear();
                    Console.WriteLine("{0} \n\nhas been changed to\n\n{1}", keyboardInput, keyboardOutput); //Display the output
                    Console.WriteLine("\nPress enter to continue...");
                    Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Enter the path of the file to search through:");
                    string fileInput = InputManager.GetFileInput(); //Get the file path
                    string fileOutput = TextAnalyser.FindAndReplace(fileInput); //Find and replace using the input and store the ouput in a string
                    Console.Clear();
                    Console.WriteLine("{0} \n\nhas been changed to\n\n{1}", fileInput, fileOutput); //Show the ouput
                    Console.WriteLine("\nWould you like to:\n1. Save new text to file\n2. Continue");
                    while(InputManager.GetOption(2) == 1) //Ask if they want to store the ouput in a new file
                    {                                       //If they do
                        Console.Clear();
                        Console.WriteLine("Enter the path of the file you would like to save to:");
                        string path = Console.ReadLine(); //Get the path to save to
                        try
                        {
                            File.WriteAllText(path, fileOutput); //If the file was valid tell them and continue
                            Console.WriteLine("File written successfully. Press enter to continue...");
                            Console.ReadLine();
                            break;
                        }
                        catch //otherwise get them to try again
                        {
                            Console.WriteLine("The path you entered is invalid. Press enter to try again...");
                        }
                    }
                    break;
                case 3:
                    return; //If they chose option 3 then go back
                default:
                    break;
            }
        }

        private static void AnalyseKeyboardInput()
        {
            Console.Clear();
            Console.WriteLine("You have selected keyboard input\n\nYou may enter multiple entries to analyse\nTo do this, signal the end of an entry with an asterisk(*) as the last character\nYou will then be prompted for another entry\n\nEnter your text:");
            TextAnalyser.AnalyseKeyboardText(InputManager.GetKeyboardEntries()); //Analyse the text
        }
        private static void AnalyseTextFileInput()
        {
            TextAnalyser.AnalyseTextFileText(InputManager.GetFileInput()); //Analyse the text
        }

    }
}
