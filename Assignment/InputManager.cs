using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment
{
    static class InputManager
    {
        public static string[] GetKeyboardEntries() //Function that will return an array of user inputed text entries
        {
            bool moreEntries = true;
            string[] textEntriesArray = new string[0];

            while (moreEntries)
            {
                string textInput = Console.ReadLine().Trim('\r', '\n', ' '); //Gets the entry and gets rid of spaces and new-lines at the start and end of the string
                if (textInput == "")
                    break;
                if (textInput.Last() != '*') //Checks the last character to see if we should expect another entry
                {
                    moreEntries = false; //Last char wasn't an * so no more loops
                }

                else
                {
                    textInput = textInput.Remove(textInput.Length - 1, 1); //We want another entry, but first we need to get rid of the * on the end of that string
                    Console.WriteLine("\nEnter your next entry:"); //Tell them we're expecting another entry
                }


                if (textEntriesArray == null) //Check to see if the array has anything in it yet
                {
                    textEntriesArray[0] = textInput; //If it doesn't, put the entry in the first position
                }
                else //otherwise...
                {
                    Array.Resize(ref textEntriesArray, textEntriesArray.Length + 1); //Make our array 1 element bigger
                    textEntriesArray[textEntriesArray.Length - 1] = textInput; //Add the newest entry to the array
                }

            }
            return textEntriesArray; //Once we're all done, return the string array
        }
        public static int GetOption(int numOfOptions) //Function that returns which option the user enters. Requires the number of options to check if they entered a valid option
        {
            bool validInput = false;
            int input = 0;
            while (!validInput)  //Keep asking for an input until they enter one that's valid
            {
                Console.WriteLine("");

                if (Int32.TryParse(Console.ReadLine(), out input)) //Make sure they input an integer
                {
                    if (input <= numOfOptions && input > 0) //Check the integer was actually one of the options
                    {
                        validInput = true; //They entered a valid input!
                    }
                    else
                    {
                        Console.WriteLine("{0} is not a valid option.\nEnter an option between 1 and {1}", input, numOfOptions); //They entered a number below 1 or a number thats too high. Tell them what numbers they can choose
                    }
                }
                else
                {
                    Console.WriteLine("Your input was invalid\nPlease enter a number representing the option you would like to choose"); //They didn't enter a number. Get them to try again.
                }
            }
            return input;
        }

        public static string GetFileInput()
        {
            Console.Clear(); //Clear the console
            Console.WriteLine("Enter the path of a .txt file to analyse: "); //Ask the user for the path of the text
            string text; //Declare a variable to store the text
            while (true) //Loop until we get a valid .txt file
            {
                string path = Console.ReadLine(); //Get the path
                try //Try and read the file
                {
                    text = File.ReadAllText(path); //If we can, store it in the string
                    break; //And break out the while loop
                }
                catch //If there's an error, catch it and tell the user whats wrong and loop again
                {
                    Console.WriteLine("Unable to open the file at:\n{0}\nMake sure you entered the correct path, it is a .txt file and it is not empty.", path);
                }
            }
            return text; //return the string from the .txt file
        } //Function that will return some text from a chosen file
    }
}
