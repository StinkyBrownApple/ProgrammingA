using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment
{
    static class TextAnalyser
    {
        //Declare some arrays of different catagories of characters that will help us analyse
        static char[] lowerCaseAlphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        static char[] upperCaseAlphabet = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        static char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        static char[] consonants = new char[] {'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z',
                                                'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Y', 'Z' };

        public static void AnalyseKeyboardText(string[] textEntries)
        {
            for (int i = 0; i < textEntries.Length; i++) //Loops through each entry, anaylises and ouputs to console
            {
                Console.Clear(); //Clear the console as we'll need quite a bit of space
                Console.WriteLine("Entry number {0}\n", i + 1); //Tell the user which entry we're analysing
                Console.WriteLine("\n{0}\n", textEntries[i]); //Output the actual entry we're analysing
                Console.WriteLine("Number of characters (with spaces): {0}", CharacterWithSpaceAnalysis(textEntries[i]));           //}
                Console.WriteLine("Number of characters (without spaces): {0}", CharacterWithoutSpaceAnalysis(textEntries[i]));     //}
                Console.WriteLine("Number of words: {0}", WordAnalysis(textEntries[i]));                                            //}
                Console.WriteLine("Number of sentences: {0}", SentenceAnalysis(textEntries[i]));                                     //Output the analysis we've done
                Console.WriteLine("Number of vowels: {0}", VowelAnalysis(textEntries[i]));                                          //}
                Console.WriteLine("Number of consonants: {0}", ConsonantsAnalysis(textEntries[i]));                                 //}
                Console.WriteLine("Number of upper case letters: {0}", UpperCaseAnalysis(textEntries[i]));                          //}
                Console.WriteLine("Number of lower case letters: {0}", LowerCaseAnalysis(textEntries[i]));                          //}
                OutputLongWords(textEntries[i]);
                Console.WriteLine("\nWould you like to:\n1. Check the amount of a certain character\n2. Continue");
                while (InputManager.GetOption(2) == 1) //Check if they want to count a character
                {
                    Console.Clear();
                    Console.WriteLine(textEntries[i]);
                    Console.WriteLine("\nEnter the character you would like to check for:");
                    char charInput;
                    while (true)
                    {
                        try
                        {
                            charInput = Console.ReadLine().First(); //Try and get an input
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("The entered an empty input. Try again:"); //If they entered an empty input, try again
                        }
                    }
                    Console.WriteLine("\nThere are {0} {1}'s in the text", CountChars(textEntries[i], charInput), charInput); //Output the results
                    Console.WriteLine("\nWould you like to:\n1. Check the amount of a certain character\n2. Continue"); //Check if they want to go again
                }
            }
        }

        public static void AnalyseTextFileText(string textEntry)
        {
            Console.Clear(); //Clear the console as we'll need quite a bit of space
            Console.WriteLine("\n{0}\n", textEntry); //Output the actual entry we're analysing
            Console.WriteLine("Number of characters (with spaces): {0}", CharacterWithSpaceAnalysis(textEntry));           //}
            Console.WriteLine("Number of characters (without spaces): {0}", CharacterWithoutSpaceAnalysis(textEntry));     //}
            Console.WriteLine("Number of words: {0}", WordAnalysis(textEntry));                                            //}
            Console.WriteLine("Number of sentences: {0}", SentenceAnalysis(textEntry));                                     //Output the analysis we've done
            Console.WriteLine("Number of lines: {0}", LineAnalysis(textEntry));
            Console.WriteLine("Number of vowels: {0}", VowelAnalysis(textEntry));                                          //}
            Console.WriteLine("Number of consonants: {0}", ConsonantsAnalysis(textEntry));                                 //}
            Console.WriteLine("Number of upper case letters: {0}", UpperCaseAnalysis(textEntry));                          //}
            Console.WriteLine("Number of lower case letters: {0}", LowerCaseAnalysis(textEntry));                          //}
            OutputLongWords(textEntry);
            Console.WriteLine("\nWould you like to:\n1. Check the amount of a certain character\n2. Continue");
            while (InputManager.GetOption(2) == 1)//Check if they want to count a character
            {
                Console.Clear();
                Console.WriteLine(textEntry);
                Console.WriteLine("\nEnter the character you would like to check for:");
                char charInput;
                while (true)
                {
                    try
                    {
                        charInput = Console.ReadLine().First(); //Try and get an input
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("The entered an empty input. Try again:"); //If they entered an empty input, try again
                    }
                }
                Console.WriteLine("\nThere are {0} {1}'s in the text", CountChars(textEntry, charInput), charInput); //Output the results
                Console.WriteLine("\nWould you like to:\n1. Check the amount of a certain character\n2. Continue"); //Check if they want to go again
            }
        }

        private static int CharacterWithSpaceAnalysis(string text)
        {
            string textWithoutNewLine = text.Replace("\r", ""); //Gets rid of any \r's that are in the string
            textWithoutNewLine = textWithoutNewLine.Replace("\n", ""); //Get's rid of any \n's that are in the string. We don't want these characters counting towards the character count
            return textWithoutNewLine.Length; //Returns the length of the string
        }

        private static int CharacterWithoutSpaceAnalysis(string text)
        {
            string textWithoutNewLineOrSpace = text.Replace("\r", ""); //Gets rid of any \r's that are in the string
            textWithoutNewLineOrSpace = textWithoutNewLineOrSpace.Replace("\n", ""); //Get's rid of any \n's that are in the string
            textWithoutNewLineOrSpace = textWithoutNewLineOrSpace.Replace(" ", ""); //Gets rid of any spaces in the string. We don't want these characters counting towards the character count
            return textWithoutNewLineOrSpace.Length; //Returns the length of the string
        }

        private static int WordAnalysis(string text)
        {
            //My definition for a word in this case is any time there is a character followed by a space or new line

            char[] textChars = text.ToCharArray(); //Convert the string into a char array so we can search through each character
            int noOfWords = 1; //There will always be at least one word, and this will also account for the word at the end of the text which wont have a space or new line after it
            for (int i = 0; i < textChars.Length; i++) //Here we go through all the characters in the string
            {
                if (textChars[i] == ' ' || textChars[i] == '\r') //find a space or new line
                {
                    if (textChars[i - 1] != ' ' && textChars[i - 1] != '\r' && textChars[i - 1] != '\n')//and see if there is a charcter behind it (that isn't a space or new line (so a long list of spaces or new lines don't get counted as a bunch of words))
                        noOfWords++; //Add one to number of words
                }
            }
            return noOfWords; //Return the total
        }

        private static int LineAnalysis(string text)
        {
            char[] textChars = text.ToCharArray(); //Convert the string into a char array so we can check each one
            int noOfReturnChars = 1; //Set to 1 by default because the input is always going to be at least 1 line long. (Can't be 0 lines)
            foreach (char character in textChars) //Go through all the characters in the text
            {
                if (character == '\n')
                {
                    noOfReturnChars++; //Add one to the total each time there's a new line character
                }
            }

            return noOfReturnChars; //Return the total
        }

        private static int SentenceAnalysis(string text)
        {
            //A sentence is essentially going to be equal to the number of full stops that are followed by a space or new line
            char[] textChars = text.ToCharArray(); //Convert the string into a char array so we can check each one
            int noOfSentences = 1; //Start at one because there will always be at least one sentence
            for (int i = 0; i < textChars.Length - 1; i++)
            {
                if (textChars[i] == '.' && (textChars[i + 1] == ' ' || textChars[i + 1] == '\r'))
                    noOfSentences++;
            }

            return noOfSentences; //Return the total
        }

        private static int VowelAnalysis(string text)
        {
            char[] textChars = text.ToCharArray(); //Convert the string into a char array so we can check each one
            int noOfVowels = 0;

            foreach (char character in textChars) //Take each character in the text
            {
                foreach (char vowel in vowels) //And go through each character in the vowels array
                {
                    if (character == vowel) //Comparing them each time
                    {
                        noOfVowels++; //If we found a match, add one to the running total
                        break; //and stop checking the rest of the vowels (a character can't be equal to 2 different vowels, so once we found a match there's no point looking through the rest)
                    }
                }
            }

            return noOfVowels;
        }

        private static int ConsonantsAnalysis(string text)
        {
            char[] textChars = text.ToCharArray(); //Convert the string into a char array so we can check each one
            int noOfConsonants = 0;

            foreach (char character in textChars) //Take each character in the text
            {
                foreach (char consonant in consonants) //And go through each character in the consonants array
                {
                    if (character == consonant) //Comparing them each time
                    {
                        noOfConsonants++; //If we found a match, add one to the running total
                        break; //and stop checking the rest of the consonants (a character can't be equal to 2 different consonants, so once we found a match there's no point looking through the rest)
                    }
                }
            }

            return noOfConsonants;
        }

        private static int UpperCaseAnalysis(string text)
        {
            char[] textChars = text.ToCharArray(); //Convert the string into a char array so we can check each one
            int noOfUpperCase = 0;

            foreach (char character in textChars) //Take each character in the text
            {
                foreach (char upperCase in upperCaseAlphabet) //And go through each character in the uppercase characters array
                {
                    if (character == upperCase) //Comparing them each time
                    {
                        noOfUpperCase++; //If we found a match, add one to the running total
                        break; //and stop checking the rest of the uppercase characters (a character can't be equal to 2 different uppercase characters, so once we found a match there's no point looking through the rest)
                    }
                }
            }

            return noOfUpperCase;
        }

        private static int LowerCaseAnalysis(string text)
        {
            char[] textChars = text.ToCharArray(); //Convert the string into a char array so we can check each one
            int noOfLowerCase = 0;

            foreach (char character in textChars) //Take each character in the text
            {
                foreach (char lowerCase in lowerCaseAlphabet) //And go through each character in the lowercase characters array
                {
                    if (character == lowerCase) //Comparing them each time
                    {
                        noOfLowerCase++; //If we found a match, add one to the running total
                        break; //and stop checking the rest of the lowercase characters (a character can't be equal to 2 different lowercase characters, so once we found a match there's no point looking through the rest)
                    }
                }
            }

            return noOfLowerCase;
        }

        private static void OutputLongWords(string text)
        {
            List<string> words = new List<string>(GetWordsInText(text)); //Create a list of words from the input
            List<string> wordsToWrite = new List<string>(); //create a new list to store words we need to write to a file
            foreach (string word in words) //go through each word in the input and check if its bigger than 7 chars
            {
                if (word.Length >= 7)
                    wordsToWrite.Add(word); //if it is, add it to the list to output
            }
            File.WriteAllLines("Long Words.txt", wordsToWrite); //Output the words to the file
        }

        public static void AnalyseTone(string input)
        {
            //We have a list of positive and negative words in 2 .txt files
            //The files have info at the top which we don't want to read
            //This info has ';' at the start of the lines
            //So we can use this to find which lines we need to get rid of

            List<string> positiveWords = new List<string>();
            List<string> negativeWords = new List<string>();
            bool canReadPositive = false;
            bool canReadNegative = false;
            while (!canReadPositive || !canReadNegative)
            {
                try
                {
                    positiveWords = new List<string>(File.ReadAllLines("positive-words.txt")); //Get the list of positive words and store in a list
                    canReadPositive = true;
                }
                catch
                {
                    Console.WriteLine("Unable to read from positive-words.txt, make sure the file is in the root of the application and try again\n\nPress Enter to retry...");
                    Console.ReadLine();
                    continue;
                }

                try
                {
                    negativeWords = new List<string>(File.ReadAllLines("negative-words.txt")); //Get the list of negative words and store in a list
                    canReadNegative = true;
                }
                catch
                {
                    Console.WriteLine("Unable to read from negative-words.txt, make sure the file is in the root of the application and try again\n\nPress Enter to retry...");
                    Console.ReadLine();
                }
            }

            List<string> linesToRemoveFromPositive = new List<string>(); //Create a list we can use to store what lines we need to remove from the positive words list
            List<string> linesToRemoveFromNegative = new List<string>(); //Create a list we can use to store what lines we need to remove from the negative words list

            positiveWords.Remove(""); //Get rid of the empty line in the positive words list
            negativeWords.Remove(""); //Get rid of the empty line in the negative words list
            string originalInput = input;
            input = input.ToLower(); //Make everything in the string lowercase, otherwise the words won't match up with the words in the positive/negative lists

            foreach (string line in positiveWords)  //Find the lines in the positive list that begin with ';' and add a copy to the remove list
            {
                if (line.First() == ';')
                {
                    linesToRemoveFromPositive.Add(line);
                }
            }

            foreach (string line in negativeWords) //Find the lines in the negative list that begin with ';' and add a copy to the remove list
            {
                if (line.First() == ';')
                {
                    linesToRemoveFromNegative.Add(line);
                }
            }

            foreach (string removeLine in linesToRemoveFromPositive) //Remove the lines that we know we need to get rid of
            {
                positiveWords.Remove(removeLine);
            }

            foreach (string removeLine in linesToRemoveFromNegative) //Remove the lines that we know we need to get rid of
            {
                negativeWords.Remove(removeLine);
            }

            List<string> wordsInInput = new List<string>(GetWordsInText(input));

            //I'm going to determine whether a sentence is positive or negative based on which number of words outweighs the other
            int noOfPositive = 0; //Create an int to track how many positive words are in the input
            int noOfNegative = 0; //Create an int to track how many negative words are in the input

            foreach (string word in wordsInInput) //Go through each word in the input
            {
                if (positiveWords.Contains(word))//And see if it is in the positive words list
                    noOfPositive++; //Increase the counter by one
            }

            foreach (string word in wordsInInput) //Go through each word in the input
            {
                if (negativeWords.Contains(word)) //And see if it is in the negative words list
                    noOfNegative++; //Increase the counter by one
            }

            int weight = noOfPositive - noOfNegative; //Find out whether there are more positive or negative words

            //Display the tone based on the weighting
            Console.Clear();
            Console.WriteLine(originalInput);
            Console.WriteLine();
            if (weight > 0)
                Console.WriteLine("The input has a positive tone");
            else if (weight == 0)
                Console.WriteLine("The input has a neutral tone");
            else
                Console.WriteLine("The input has a negative tone");
            Console.WriteLine("\nPress Enter to continue.");
            Console.ReadLine();
        }

        private static List<string> GetWordsInText(string input)
        {
            List<string> wordsInInput = new List<string>(); //Make a new list we can use to store words from the input
            char[] inputChars = input.ToCharArray(); //Turn the input into a char array

            string wordInInput = ""; //Create a variable we can use to create a word
            for (int i = 0; i < inputChars.Length; i++) //Go through the char array
            {
                if (inputChars[i] == ' ' || inputChars[i] == '\r' || inputChars[i] == '\n' || inputChars[i] == '.' || inputChars[i] == ',' || inputChars[i] == '?' || inputChars[i] == '!' || inputChars[i] == ';' || inputChars[i] == ':' || inputChars[i] == '/' || inputChars[i] == '\\' || inputChars[i] == '|') //Check if the char is a character used to determine the end of a word (Punctuation, spaces and new line)
                {
                    wordsInInput.Add(wordInInput); //Add the word we made to the list of words
                    wordInInput = ""; //Reset our word  so it's empty
                }
                else if (inputChars[i] == '"' || inputChars[i] == '\'' || inputChars[i] == '£' || inputChars[i] == '€' || inputChars[i] == '%' || inputChars[i] == '^' || inputChars[i] == '*' || inputChars[i] == '(' || inputChars[i] == ')' || inputChars[i] == '_' || inputChars[i] == '+' || inputChars[i] == '=' || inputChars[i] == '{' || inputChars[i] == '}' || inputChars[i] == '[' || inputChars[i] == ']' || inputChars[i] == '@' || inputChars[i] == '#' || inputChars[i] == '~' || inputChars[i] == '<' || inputChars[i] == '>' || inputChars[i] == '`' || inputChars[i] == '¬' || inputChars[i] == '¦') //Big long list of all the punctiation that we can ignore
                    continue;
                else
                    wordInInput += inputChars[i]; //Otherwise, add the char to the word we're making
            }
            wordsInInput.Add(wordInInput); //Add the last word we made becuase it won't be followed by anything else

            return wordsInInput;
        }

        private static int CountChars(string input, char character)
        {
            int noOfChar = 0; //Create a variable to count the characters
            foreach (char c in input) //Go through each character in the input
            {
                if (c == character)//Check if that character is equal to the char we're counting
                {
                    noOfChar++;//If it is, add one to the counter
                }
            }
            return noOfChar; //Return the total from the counter
        }

        public static string FindAndReplace(string input)
        {

            Console.Clear();
            Console.WriteLine(input);
            Console.WriteLine("\nEnter the text you would like to find:");
            string find = Console.ReadLine(); //Get the text to find
            while(find == "")
            {
                find = Console.ReadLine(); //keep going if the input is empty
            }
            Console.Clear();
            Console.WriteLine(input);
            Console.WriteLine("\nEnter the text you would like to replace this with:");
            string replace = Console.ReadLine(); //Get the text to replace
            while (replace == "")
            {
                replace = Console.ReadLine();//Keep going if the input is empty
            }

            List<char> inputCharList = new List<char>(input); //Create a list of chars from the input
            List<int> findPositions = new List<int>(); //Create a list to store the positions of the start of words we find
            for (int i = 0; i < (inputCharList.Count - find.Length) + 1; i++) //Loops through the input up to the place where a found word can fit
            {                                                               //(E.g. theres no point checking the second to last char if the word we're finding is 3 chars long)
                if (inputCharList[i] == find[0]) //Check if the character we're at matches the first char in the word
                { //If it is, we might have found a word
                    string tempWord = ""; //Create a temp word to see if it matches the 'find' word
                    for (int x = 0; x < find.Length; x++) //Go through the next few characters equal to the length of the 'find' word
                    {
                        tempWord += inputCharList[i + x]; //And add each char to the temp word
                    }
                    if (tempWord == find) //If the temp word we made is the same as the 'find' word then that means we found a word at position i
                    {
                        findPositions.Add(i); //So add position i to our list
                    }
                }
            }

            if (findPositions.Count != 0) //Only do this stuff if we actually found a word
            {
                int offset = replace.Length - find.Length; //If the 'find' word and 'replace' word aren't the same length, then when we remove the 'find' word and replace with the 'replace' word, the poistions in the positions list will be wrong, so we need to offset them
                List<int> tempList = new List<int>(findPositions); //create a temp list to store the offsetted positions
                for (int i = 0; i < findPositions.Count; i++) //Go through each position
                {
                    tempList[i] = findPositions[i] + (offset * i); //And change it based on the offest and what position in the list it is
                }

                findPositions = tempList; //set the positions to equal the temp list

                foreach (int i in findPositions) //Now go through each position
                {
                    inputCharList.RemoveRange(i, find.Length); //Remove the 'find' word
                    inputCharList.InsertRange(i, replace.ToCharArray()); //Add the 'replace' word
                }
            }

            string output = new string(inputCharList.ToArray<char>()); //convert the list to a string
            return output; //return the output string
        }
    }

}
