
// shortcut for print
using System.Runtime.CompilerServices;

void print(string text)
{
    Console.WriteLine(text); 
}

int timeLimit = 0; //int for a time limit if the user wants to play with it
int rangeOfNumber = 10; //The range of the random number
bool hasUserGuessedNumber = false; //Has the user entered the correct number?
int userInput = 0; //int for the User Input
Random random = new Random(); //New random int
int randomNumberNumber = 11; //The range of the random number
int numberPC = random.Next(randomNumberNumber); //setting the random number with the range of the int above
int amountOfWrongInputs = 0; //int for the amounts of wrong inputs the user has made
string userContinueText; //string for if the user wants to continue playing the game
int userTries = 0; // the amount of tries the user has made
int tryagainnumberblyat = 0; //used in a controll structure to generate a new number 
string addTimeLimit;

print("Welcome to the number guesser game!" + Environment.NewLine);
Thread.Sleep(1000);
print($"The number is between 1 and {rangeOfNumber} BUT if your guess is wrong 3 times the range will increase by 1, from 10 to 11 to 12 etc and a new number will be selected!" + Environment.NewLine);
Thread.Sleep(1000);
print("Click Enter to continue");
Console.ReadLine();
bool timelimitinput = false;


bool timeLimitSet = false;
do
{
    print("Do you want to add an time limit? [y][n]");
    addTimeLimit = Console.ReadLine();
    switch (addTimeLimit)
    {
        case "yes":
        case "Yes":
        case "Y":
        case "y":
            {

                do
                {
                    try
                    {
                        Console.Write("Okay, how many seconds? ");
                        addTimeLimit = Console.ReadLine();
                        timeLimit = Convert.ToInt32(addTimeLimit);
                        print($"Okay, time limit set to {timeLimit} seconds!" + Environment.NewLine);
                        timeLimitSet = true;
                        timelimitinput = true;
                    }
                    catch
                    {
                        print("That isn't a nunber, please try again" + Environment.NewLine);
                    }
                }
                while (!timeLimitSet);
                break;

            }
            break;
        case "n":
        case "N":
        case "No":
        case "no":
            {
                print("Okay, no limit has been set" + Environment.NewLine);
                timelimitinput = true;
            }
            break;
        default: continue;
    }
} while (!timelimitinput);




print("Ready");
Thread.Sleep(500);
print("Set");
Thread.Sleep(500);
Console.Write("Guess!");
print(Environment.NewLine);



do
{
    
        
        /*
            timeLimit--;
            Thread.Sleep(1000);
            if (timeLimit == 0)
            {
                print("Oh, looks like the time ran out!");
                Environment.Exit(0);
            }
        */
    
    try
    {
        
        
        
        if (tryagainnumberblyat == 1)
        {
            randomNumberNumber = 11;
            numberPC = random.Next(randomNumberNumber);
            tryagainnumberblyat = 0;
            

        }


        Console.Write(Environment.NewLine + "My Guess is: "); //User Input
        userInput = Convert.ToInt32(Console.ReadLine()); 
        

        if (userInput == numberPC) //If the user input matches the random generated number, the user wins
        {
            
            print("LETS GO YOU GUESSED IT!");
            print("Play again? [y][n]");
            string playAgain = Console.ReadLine();
            switch (playAgain)
            {
                case "Y":
                case "y":
                    tryagainnumberblyat++;
                    rangeOfNumber = 10;
                    print("Welcome to the number guesser game!" + Environment.NewLine);
                    Thread.Sleep(1000);
                    print($"The number is between 1 and {rangeOfNumber} BUT if your guess is wrong 3 times the range will increase by 1, from 10 to 11 to 12 etc and a new number will be selected!" + Environment.NewLine);
                    Thread.Sleep(1000);
                    print("Click Enter to continue");
                    Console.ReadLine();

                    print("Ready");
                    Thread.Sleep(500);
                    print("Set");
                    Thread.Sleep(500);
                    Console.Write("Guess!");
                    print(Environment.NewLine);
                    continue;
                
                case "n":
                    print("You tried {userTries} time(s) and you've guessed it!");
                    hasUserGuessedNumber = true;
                    break;
                
                default:
                    print("Please enter y or n");
                    break;
            }
            
        }
        else //if not, then amountOfWrongInputs gets +1 and if the amountOfWrongInputs has reached 3, the random numbers range will increase and a new number will be generated. amountOfWronginputs will be set to 0 so the cycle can repeat indefinitly
        {
            amountOfWrongInputs++;
            userTries++;
            

            bool tryagain = false;

            do
            {
                print($"Wrong, remember, the range is from 1 to {rangeOfNumber}" + Environment.NewLine);
                tryagain = true;

            }
            while (!tryagain);
            bool negma = true;
            do
            {
                if (amountOfWrongInputs == 3)
                {
                    Console.Write("Continue? [y][n] ");
                    userContinueText = Console.ReadLine();

                    switch (userContinueText)
                    {
                        case "n":
                            print($"Okay, the random number was {numberPC}. You tried {userTries} time(s) but unfortunatly couln't guess it!");
                            Environment.Exit(0);
                            break;
                        case "y":

                            negma = true;
                            break;
                        default:
                            print("Please enter y or n");
                            break;
                    }
                }
                rangeOfNumber++;
                print(Environment.NewLine + "Oh no! You've guessed wrong 3 times! It has just gotten harder! :)))" + Environment.NewLine + $"New range = 1 to {rangeOfNumber}" + Environment.NewLine);
                randomNumberNumber++;
                numberPC = random.Next(randomNumberNumber);
                amountOfWrongInputs = 0;
            } while (negma) ;
        continue;
        }
        

    }
    catch //if the user enters a text or something else unwanted
    {
        print("That isn't a number! Try again!" + Environment.NewLine);
        continue;
    }
}
while (!hasUserGuessedNumber); //boolean for if the user has guessed the number
 