//Sebastian Bruce
//December 5th 2023
//Text based prison escape game

using System;

class Program {
    static void Main() {

        //set up variables to be used later
        bool hasMoney = false;
        bool hasBrick = false;
        bool hasClip = false;
        bool hasShank = false;

        Console.WriteLine("You wake up inside of a cold prison cell...");

        // Game loop
        while (true) {
            //each time the loop is run, there is a 1 in 20 chance for a riot to happen
            if(RandomRiot() == 1) {
                Console.WriteLine("\nUh Oh! A riot has started outside of your cell.");
                Console.WriteLine("Suddenly all the cell doors fly open. What will you do?");
                Console.WriteLine("1. Leave your cell and attempt to escape in the commotion.");
                Console.WriteLine("2. Stay in your cell and avoid the commotion.");
                string riotChoice = Console.ReadLine(); //get user input
                
                if(riotChoice == "1") { //if user enters 1
                    Console.WriteLine("\nA guard notices you but you decide to pretend to be a guard yourself who got overrun by prisoners.");
                    Console.WriteLine("The guard is skeptical, but in an attempt to verify what you said, asks you a question.");
                    Console.WriteLine("'What is the criminal code for a riot in prison.'");
                    Console.WriteLine("1. '64 A'");
                    Console.WriteLine("2. 'Code Red'");
                    Console.WriteLine("3. 'General Emergency'");
                    string codeChoice = Console.ReadLine(); //get user input

                    if(codeChoice == "1") { //if user enters 1
                        youWin("You convince the guard");
                    }else if(codeChoice == "2" || codeChoice == "3") { //if user enters 2
                        youLose("The guard knows you're lying and takes you away to solitary confinement");
                    }

                }else if(riotChoice == "2") { //if user enters 2
                    Console.WriteLine("\nThe doors close and the prison settles down.");
                }
            }

            Console.WriteLine("\nMany ideas flood your head, what will you do?");
            Console.WriteLine("1. Look around the cell");
            Console.WriteLine("2. Talk to cellmate");
            Console.WriteLine("3. Attempt to pick the lock");
            string choice = Console.ReadLine(); //get user input

            switch (choice) {

                case "1": //if user enters 1
                    Console.WriteLine("\nYou look around the cell and find a loose brick in the wall.");
                    Console.WriteLine("1. Try to pry the loose brick open");
                    Console.WriteLine("2. Investigate the bed");
                    string lookChoice = Console.ReadLine(); //get user input

                    if (lookChoice == "1") { //if user enters 1
                        Console.WriteLine("\nBehind the brick is some money, you take both it and the brick. Maybe they will be useful later?");
                        hasMoney = true;
                        hasBrick = true;
                    }else if (lookChoice == "2") { //if user enters 2
                        Console.WriteLine("\nYou find a paperclip hidden under the bed. Maybe it will be useful later?");
                        hasClip = true;
                    }else { //if user enters anything else
                        Console.WriteLine("\nInvalid choice. Try again.");
                    }
                    break;

                case "2": //if user enters 2

                if(hasBrick == false) { //if user never found the brick
                    Console.WriteLine("\nYou talk your cellmate and he informs you about a loose brick in the cell.");
                    break;
                }else if(hasBrick == true) { //if user found the brick
                    Console.WriteLine("\nYou talk your cellmate and he tells you that he will give you a shank in exchange for some money.");
                    Console.WriteLine("Do you trade for the shank?");
                    Console.WriteLine("1. Yes, it could be useful to overpower someone.");
                    Console.WriteLine("2. No, the money could be better used another way.");
                    string talkChoice = Console.ReadLine(); //get user input

                    if (talkChoice == "1") { //if user enters 1
                        Console.WriteLine("\nYou make the trade.");
                        Console.WriteLine("You no longer have any money, but now you have a shank.");
                        hasMoney = false;
                        hasShank = true;
                    }else if (talkChoice == "2") { //if user enters 2
                        Console.WriteLine("\nYou don't make the trade.");
                        Console.WriteLine("You keep the money, but don't have the shank.");
                    }else { //if user enters anything else
                        Console.WriteLine("\nInvalid choice. Try again.");
                    }
                }
                break;

                case "3": //if user enters 3

                if(hasClip == true) { //if user found the paperclip
                    Console.WriteLine("\nYou attempt to pick the lock with the paperclip.");
                    Console.WriteLine("The lock breaks and you proceed through the door cautiously.");
                    Console.WriteLine("\nYou see a guard standing the hallway, what will you do?.");
                    Console.WriteLine("1. Attempt to bribe guard.");
                    Console.WriteLine("2. Attempt to overpower the guard.");
                    string guardChoice = Console.ReadLine(); //get user input

                    if (guardChoice == "1") { //if user enters 1
                        if(hasMoney == true) { //if user has the money
                            Console.WriteLine("\nYou approach the guard and offer him the money you found.");
                            youWin("The guard takes the money and sneakily escorts you outside");
                        }else if(hasMoney == false) { //if the user never found the money
                            Console.WriteLine("\nYou approach the guard but you don't have anything to offer him.");
                            Console.WriteLine("You have no choice but to fight.");
                            guardChoice = "2";
                        }
                    }

                    if (guardChoice == "2") { //if user enters 2
                        if(hasShank == true) { //if the user bought the shank
                            youWin("\nYou use your shank to overpower the guard and run outside.");
                        }else if(hasBrick == true) { //if the user didn't buy the shank but has the brick
                            //50/50 chance that you beat the guard with the brick
                            if(BeatGuard() == 1) {
                                youWin("\nYou use your brick to overpower the guard and run outside");
                            }else if(BeatGuard() == 2) {
                                youLose("\nYou attempt to use your brick to overpower the guard, but he beats you and takes you to solitary confinement");
                            }
                        }else if(hasShank == false && hasBrick == false) { //if user didn't find the brick or shank
                            youLose("\nYou attempt to overpower the guard with your bare hands, but he beats you and takes you to solitary confinement");
                        }
                    }

                }else if(hasClip == false) { //if the user didn't find the clip
                    Console.WriteLine("\nYou don't have any tools to pick the lock with.");
                    Console.WriteLine("You could try to break it with your bear hands, what will you do?");
                    Console.WriteLine("1. Try to break the lock.");
                    Console.WriteLine("2. Take a better look around the cell.");
                    string lockChoice = Console.ReadLine(); //get user input

                    if(lockChoice == "1") { //if user enters 1
                        youLose("\nA guard catches you trying to break the lock, and you are taken to solitary confinement");
                    }else if (lockChoice == "2") { //if user enters 2
                        break;
                    }else {
                        Console.WriteLine("\nInvalid choice. Try again.");
                    }
                }
                break;

                default: //if user enters anything else

                    Console.WriteLine("\nInvalid choice. Try again.");

                    break;
            }
        }
    }

//logic for when you use the brick to beat guard
    static int BeatGuard() {
        //picks random number between 1 and 2
        Random random = new Random();
        return random.Next(1, 3);
    }

//logic for the random riot
    static int RandomRiot() {
        //picks random number between 1 and 20
        Random random = new Random();
        return random.Next(1, 21);
    }

//called on when the user wins
    static void youWin(string ending) {
        Console.WriteLine($"\nCongratulations! {ending}. You have successfully escaped from prison!");
        Environment.Exit(0);
    }

//called on when the user loses
    static void youLose(string ending) {
        Console.WriteLine($"\nYou lose! {ending}. Better luck next time.");
        Environment.Exit(0);
    }
}