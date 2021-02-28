using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;


namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control - Menu Starter
    // Description:  Starting Solution for BirdBrain Technologies Finch - Talent Show 
    // Application Type: Console
    // Author: Jackilynn Millard
    // Dated Created: 2/21/2021
    //
    // **************************************************

    class Program
    {
        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }

        /// <summary>
        /// setup the console theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch finchRobot = new Finch();

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.WriteLine();
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();
                Console.WriteLine();
                Console.WriteLine();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "b":
                        TalentShowDisplayMenuScreen(finchRobot);
                        break;

                    case "c":
                        DataRecorderDisplayMenuScreen(finchRobot);
                        break;

                    case "d":

                        break;

                    case "e":

                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(finchRobot);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice >>  ");
                        DisplayContinuePrompt();
                        Console.WriteLine();
                        Console.WriteLine();
                        break;
                }

            } while (!quitApplication);
        }

        #region TALENT SHOW

        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show Menu                          *
        /// *****************************************************************
        /// </summary>
        static void TalentShowDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) Dance");
                Console.WriteLine("\tc) Mix It Up");
                Console.WriteLine("\tq) Main Menu");
                Console.WriteLine();
                Console.Write("\t\tPlease enter a letter for the menu choice >>  ");
                menuChoice = Console.ReadLine().ToLower();
                Console.WriteLine();
                Console.WriteLine();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        TalentShowDisplayLightAndSound(finchRobot);
                        break;

                    case "b":
                        TalentShowDisplayDance(finchRobot);
                        break;

                    case "c":
                        TalentShowDisplayMixItUp(finchRobot);
                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice >>  ");
                        DisplayContinuePrompt();
                        Console.WriteLine();
                        Console.WriteLine();
                        break;
                }

            } while (!quitTalentShowMenu);
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Light and Sound                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void TalentShowDisplayLightAndSound(Finch finchRobot)
        {

            Console.CursorVisible = false;

            DisplayScreenHeader("Light and Sound");

            for (int lightSoundLevel = 0; lightSoundLevel < 255; lightSoundLevel++)
            {
                finchRobot.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
                finchRobot.noteOn(lightSoundLevel * 100);
            }



            Console.WriteLine("\tThe Finch robot will now show off its glowing talent!");
            DisplayContinuePrompt();


            // red LED
            finchRobot.setLED(250, 0, 0);
            finchRobot.wait(800);
            finchRobot.setLED(0, 0, 0);
            finchRobot.wait(500);

            // green LED
            finchRobot.setLED(0, 250, 0);
            finchRobot.wait(800);
            finchRobot.setLED(0, 0, 0);
            finchRobot.wait(500);

            // turn on blue LED
            finchRobot.setLED(0, 0, 250);
            finchRobot.wait(800);
            finchRobot.setLED(0, 0, 0);
            finchRobot.wait(500);

            //flash lights
            for (int numberofFlashes = 0; numberofFlashes < 7; numberofFlashes++)
            {
                finchRobot.setLED(250, 0, 0);
                finchRobot.wait(300);
                finchRobot.setLED(0, 0, 250);
                finchRobot.wait(500);
            }
            for (int numberofFlashes = 0; numberofFlashes < 10; numberofFlashes++)
            {
                finchRobot.setLED(0, 250, 0);
                finchRobot.wait(175);
                finchRobot.setLED(0, 0, 250);
                finchRobot.wait(175);
                finchRobot.setLED(250, 0, 0);
            }

            DisplayMenuPrompt("Talent Show Menu");
        }


        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Dance                             *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>

        static void TalentShowDisplayDance(Finch finchRobot)
        {


            string UserInput;

            Console.CursorVisible = false;

            DisplayScreenHeader("Dancing Finch");

            Console.WriteLine(" ");
            Console.WriteLine("\tChoose a Dance.");
            Console.WriteLine("\ta) Dance in Circles");
            Console.WriteLine("\tb) Dance the Box Step");
            Console.WriteLine("\tc) Sway to the Music");
            Console.WriteLine("\tq) Return to menu.");
            Console.WriteLine(" ");
            Console.Write("\t\tPlease enter a letter for the menu choice >>  ");
            UserInput = Console.ReadLine();
            Console.WriteLine(" ");
            Console.WriteLine(" ");


            switch (UserInput)
            {
                case "a":
                    Console.WriteLine("Finch will Dance in Circles.");
                    DisplayContinuePrompt();
                    for (int i = 0; i < 4; i++)
                    {
                        finchRobot.setMotors(255, 50);
                        finchRobot.wait(1000);
                    }
                    break;

                case "b":
                    Console.WriteLine("Finch will Dance the Box Step.");
                    DisplayContinuePrompt();
                    for (int i = 0; i < 1; i++)
                    {
                        finchRobot.setMotors(255, 255);
                        finchRobot.wait(500);
                        finchRobot.setMotors(255, 50);
                        finchRobot.wait(550);
                        finchRobot.setMotors(255, 255);
                        finchRobot.wait(500);
                        finchRobot.setMotors(255, 50);
                        finchRobot.wait(550);
                        finchRobot.setMotors(255, 255);
                        finchRobot.wait(500);
                        finchRobot.setMotors(255, 50);
                        finchRobot.wait(550);
                        finchRobot.setMotors(255, 255);
                        finchRobot.wait(500);
                        finchRobot.setMotors(255, 50);
                        finchRobot.wait(550);
                    }
                    break;

                case "c":
                    Console.WriteLine("Finch will Sway to the Music.");
                    DisplayContinuePrompt();
                    for (int i = 0; i < 1; i++)
                    {
                        finchRobot.setMotors(255, 50);
                        finchRobot.wait(500);
                        finchRobot.setMotors(50, 255);
                        finchRobot.wait(500);
                        finchRobot.setMotors(255, 50);
                        finchRobot.wait(500);
                        finchRobot.setMotors(50, 255);
                        finchRobot.wait(500);
                        finchRobot.setMotors(255, 50);
                        finchRobot.wait(500);
                        finchRobot.setMotors(50, 255);
                        finchRobot.wait(500);
                        finchRobot.setMotors(255, 50);
                        finchRobot.wait(500);
                        finchRobot.setMotors(50, 255);
                        finchRobot.wait(500);
                    }
                    break;

                case "q":

                    break;


                default:
                    Console.WriteLine(" ");
                    Console.WriteLine("Please enter a letter for the menu choice >>  ");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    break;
            }

            finchRobot.setMotors(0, 0);

            DisplayMenuPrompt("Talent Show Menu");
        }


        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Mix It Up                         *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>

        private static void TalentShowDisplayMixItUp(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Mix It Up");

            Console.WriteLine(" ");
            Console.WriteLine();

            Console.WriteLine("\tFinch will now display all his talents.");
            DisplayContinuePrompt();


            for (int i = 0; i < 1; i++)
            {

                // Song "Beautiful Dreamer" by Stephen Foster
                finchRobot.setLED(255, 0, 0);
                finchRobot.noteOn(698);
                finchRobot.wait(500);
                finchRobot.noteOn(659);
                finchRobot.wait(500);
                finchRobot.noteOn(698);
                finchRobot.wait(500);
                finchRobot.noteOn(523);
                finchRobot.wait(1000);
                finchRobot.noteOn(440);
                finchRobot.wait(750);
                finchRobot.setLED(0, 255, 0);
                finchRobot.noteOn(0);
                finchRobot.wait(500);
                finchRobot.setMotors(255, 50);
                finchRobot.wait(250);
                finchRobot.setMotors(0, 0);
                finchRobot.noteOn(392);
                finchRobot.wait(500);
                finchRobot.noteOn(370);
                finchRobot.wait(500);
                finchRobot.noteOn(392);
                finchRobot.wait(500);
                finchRobot.noteOn(587);
                finchRobot.wait(1000);
                finchRobot.setLED(0, 0, 255);
                finchRobot.setMotors(50, 255);
                finchRobot.wait(250);
                finchRobot.setMotors(0, 0);
                finchRobot.noteOn(0);
                finchRobot.wait(500);
                finchRobot.noteOn(523);
                finchRobot.wait(500);
                finchRobot.noteOn(659);
                finchRobot.wait(500);
                finchRobot.noteOn(587);
                finchRobot.wait(500);
                finchRobot.noteOn(587);
                finchRobot.wait(500);
                finchRobot.noteOn(523);
                finchRobot.wait(500);
                finchRobot.noteOn(493);
                finchRobot.wait(500);
                finchRobot.noteOn(493);
                finchRobot.wait(500);
                finchRobot.noteOn(440);
                finchRobot.wait(500);
                finchRobot.noteOn(329);
                finchRobot.wait(500);
                finchRobot.noteOn(440);
                finchRobot.wait(1500);
                finchRobot.noteOn(349);
                finchRobot.wait(1000);
                finchRobot.setLED(255, 255, 255);
                finchRobot.setMotors(255, 50);
                finchRobot.wait(250);
                finchRobot.setMotors(0, 0);
                finchRobot.noteOn(0);
                finchRobot.wait(500);
                finchRobot.noteOn(523);
                finchRobot.wait(500);
                finchRobot.noteOn(493);
                finchRobot.wait(500);
                finchRobot.noteOn(392);
                finchRobot.wait(500);
                finchRobot.noteOn(329);
                finchRobot.wait(750);
                finchRobot.noteOn(587);
                finchRobot.wait(750);
                finchRobot.noteOn(587);
                finchRobot.wait(500);
                finchRobot.noteOn(523);
                finchRobot.wait(500);
                finchRobot.noteOn(440);
                finchRobot.wait(500);
                finchRobot.noteOn(349);
                finchRobot.wait(750);
                finchRobot.setLED(255, 0, 255);
                finchRobot.setMotors(50, 255);
                finchRobot.wait(250);
                finchRobot.setMotors(0, 0);
                finchRobot.noteOn(0);
                finchRobot.wait(1000);
                finchRobot.noteOn(698);
                finchRobot.wait(500);
                finchRobot.noteOn(659);
                finchRobot.wait(500);
                finchRobot.noteOn(698);
                finchRobot.wait(500);
                finchRobot.noteOn(587);
                finchRobot.wait(500);
                finchRobot.setLED(0, 255, 255);
                finchRobot.setMotors(255, 50);
                finchRobot.wait(250);
                finchRobot.setMotors(0, 0);
                finchRobot.noteOn(0);
                finchRobot.wait(500);
                finchRobot.noteOn(784);
                finchRobot.wait(500);
                finchRobot.noteOn(698);
                finchRobot.wait(500);
                finchRobot.noteOn(659);
                finchRobot.wait(500);
                finchRobot.noteOn(698);
                finchRobot.wait(500);
                finchRobot.noteOn(587);
                finchRobot.wait(500);
                finchRobot.noteOn(523);
                finchRobot.wait(750);
                finchRobot.setLED(255, 255, 0);
                finchRobot.setMotors(50, 255);
                finchRobot.wait(250);
                finchRobot.setMotors(0, 0);
                finchRobot.noteOn(0);
                finchRobot.wait(500);
                finchRobot.noteOn(698);
                finchRobot.wait(500);
                finchRobot.noteOn(659);
                finchRobot.wait(500);
                finchRobot.noteOn(698);
                finchRobot.wait(500);
                finchRobot.noteOn(523);
                finchRobot.wait(750);
                finchRobot.noteOn(440);
                finchRobot.wait(750);
                finchRobot.setLED(255, 0, 0);
                finchRobot.setMotors(255, 50);
                finchRobot.wait(250);
                finchRobot.setMotors(0, 0);
                finchRobot.noteOn(0);
                finchRobot.wait(500);
                finchRobot.noteOn(392);
                finchRobot.wait(500);
                finchRobot.noteOn(370);
                finchRobot.wait(500);
                finchRobot.noteOn(392);
                finchRobot.wait(500);
                finchRobot.noteOn(587);
                finchRobot.wait(750);
                finchRobot.setLED(0, 255, 0);
                finchRobot.setMotors(50, 255);
                finchRobot.wait(250);
                finchRobot.setMotors(0, 0);
                finchRobot.noteOn(0);
                finchRobot.wait(1500);
                finchRobot.noteOn(523);
                finchRobot.wait(500);
                finchRobot.noteOn(659);
                finchRobot.wait(500);
                finchRobot.noteOn(587);
                finchRobot.wait(500);
                finchRobot.noteOn(587);
                finchRobot.wait(500);
                finchRobot.noteOn(523);
                finchRobot.wait(500);
                finchRobot.noteOn(493);
                finchRobot.wait(500);
                finchRobot.noteOn(493);
                finchRobot.wait(500);
                finchRobot.noteOn(440);
                finchRobot.wait(500);
                finchRobot.noteOn(392);
                finchRobot.wait(500);
                finchRobot.noteOn(440);
                finchRobot.wait(1000);
                finchRobot.setLED(0, 0, 255);
                finchRobot.setMotors(255, 50);
                finchRobot.wait(250);
                finchRobot.setMotors(0, 0);
                finchRobot.noteOn(0);
                finchRobot.wait(500);
                finchRobot.noteOn(587);
                finchRobot.wait(500);
                finchRobot.noteOn(659);
                finchRobot.wait(500);
                finchRobot.noteOn(698);
                finchRobot.wait(500);
                finchRobot.noteOn(698);
                finchRobot.wait(500);
                finchRobot.noteOn(523);
                finchRobot.wait(500);
                finchRobot.noteOn(440);
                finchRobot.wait(500);
                finchRobot.noteOn(493);
                finchRobot.wait(500);
                finchRobot.noteOn(440);
                finchRobot.wait(500);
                finchRobot.noteOn(392);
                finchRobot.wait(500);
                finchRobot.noteOn(349);
                finchRobot.wait(500);
                finchRobot.setLED(255, 255, 255);
                finchRobot.noteOff();
                finchRobot.setMotors(255, 255);
                finchRobot.wait(2000);
                finchRobot.setMotors(-255, -255);
                finchRobot.wait(200);
                finchRobot.setMotors(255, 50);
                finchRobot.wait(200);
                finchRobot.setMotors(50, 255);
                finchRobot.wait(200);
            }
            finchRobot.setMotors(0, 0);
            finchRobot.setLED(0, 0, 0);

            DisplayMenuPrompt("Talent Show Menu");
        }


        #endregion

        #region data recorder

        /// <summary>
        /// *****************************************************************
        /// *                     Data Recorder Menu                        *
        /// *****************************************************************
        /// </summary>

        static void DataRecorderDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;

            string menuChoice;

            int NumberOfDataPoints = 0;
            double DataPointFrequency = 0;
            double[] Temperatures = null;

            bool quitDataRecorderMenu = false;

            do
            {
                DisplayScreenHeader("Data Recorder Menu");

                //
                // get user menu choice
                //

                Console.WriteLine("\ta) Number of Data Points");
                Console.WriteLine("\tb) Frequency of Data Points");
                Console.WriteLine("\tc) Get Data");
                Console.WriteLine("\td) Show Data");
                Console.WriteLine("\tq) Return to Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //

                switch (menuChoice)
                {
                    case "a":
                        NumberOfDataPoints = DataRecorderDisplayNumberOfDataPoints();
                        break;

                    case "b":
                        DataPointFrequency = DataRecorderDisplayDataPointFrequency();
                        break;

                    case "c":
                        Temperatures = DataRecorderDisplayGetData(NumberOfDataPoints, DataPointFrequency, finchRobot);
                        break;

                    case "d":
                        DataRecorderDisplayData(Temperatures);
                        break;

                    case "q":
                        quitDataRecorderMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice >>  ");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitDataRecorderMenu);

        }

        /// <summary>
        /// *****************************************************************
        /// *               Data Recorder > Number of Data Points           *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>

        static int DataRecorderDisplayNumberOfDataPoints()
        {
            int NumberOfDataPoints;
            bool ValidInput;
            string UserInput;

            do
            {
                DisplayScreenHeader("Get Number of Data Points");
                Console.WriteLine("Number of Data Points: ");
                UserInput = Console.ReadLine();


                ValidInput = int.TryParse(UserInput, out NumberOfDataPoints);

                if (!ValidInput)
                {
                    Console.WriteLine("Please Enter the Number of Data Points You Would Like to Collect: ");
                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine("Finch will collect {0} Data Points.", NumberOfDataPoints);

            } while (!ValidInput);

            DisplayContinuePrompt();

            return NumberOfDataPoints;

        }

        /// <summary>
        /// *****************************************************************
        /// *               Data Recorder > Data Point Frequency            *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>

        static double DataRecorderDisplayDataPointFrequency()
        {
            int DataPointFrequency;
            bool ValidInput;
            string UserInput;

            do
            {
                DisplayScreenHeader("Get Data Point Frequency");

                Console.WriteLine("Data Point Frequency");

                UserInput = Console.ReadLine();


                ValidInput = int.TryParse(UserInput, out DataPointFrequency);

                if (!ValidInput)
                {
                    Console.Write("Please Enter the number of seconds for the Data Point Frequency >>  ");
                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine("Finch will  collect data every {0} seconds.", DataPointFrequency);
            } while (!ValidInput);


            DisplayContinuePrompt();

            return DataPointFrequency;

        }

        /// <summary>
        /// *****************************************************************
        /// *               Data Recorder > Display Get Data                *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>

        static double[] DataRecorderDisplayGetData(int NumberOfDataPoints, double DataPointFrequency, Finch finchRobot)
        {
            double[] Temperatures = new double[NumberOfDataPoints];
            int FrequencyInSeconds;

            DisplayScreenHeader("Getting The Data");

            // Echo the Number of Data Points to the User.

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Finch will record the Tempurature {0} times every {1} seconds.", NumberOfDataPoints, DataPointFrequency);
            DisplayContinuePrompt();
            Console.WriteLine();

            for (int index = 0; index < NumberOfDataPoints; index++)
            {
                Temperatures[index] = finchRobot.getTemperature();
                Console.WriteLine("Data Point #{0}    {1}° F", (index + 1), (Temperatures[index] * 9 / 5 + 32));
                FrequencyInSeconds = (int)(DataPointFrequency * 500);
                finchRobot.wait(FrequencyInSeconds);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Finch has completed the data collection");
            Console.WriteLine();   

            DisplayContinuePrompt();

            return Temperatures;
        }

        /// <summary>
        /// *****************************************************************
        /// *               Data Recorder > Display Data                    *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>

        static void DataRecorderDisplayDataTable(double[] Temperatures)
        {
            //
            // display for data table
            //
            Console.WriteLine(" Data Point           Temperatures");

            Console.WriteLine("____________         ______________");

            //
            // the table data
            //
            for (int index = 0; index < Temperatures.Length; index++)
            {
                Console.WriteLine("      {0}                 {1}° F", (index + 1).ToString(), (Temperatures[index] * 9 / 5 + 32).ToString("n2"));

            }
        }

        static void DataRecorderDisplayData(double[] Temperatures)
        {
            DisplayScreenHeader("Display Data");

            DataRecorderDisplayDataTable(Temperatures);

            DisplayContinuePrompt();
        }

        #endregion

        #region FINCH ROBOT MANAGEMENT

        /// <summary>
        /// *****************************************************************
        /// *               Disconnect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from the Finch robot.");
            DisplayContinuePrompt();

            finchRobot.disConnect();

            Console.WriteLine("\tThe Finch robot is now disconnect.");

            DisplayMenuPrompt("Main Menu");
        }


        /// <summary>
        /// *****************************************************************
        /// *                  Connect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// <returns>notify if the robot is connected</returns>
        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tAbout to connect to Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
            DisplayContinuePrompt();

            robotConnected = finchRobot.connect();

            // TODO test connection and provide user feedback - text, lights, sounds

            DisplayMenuPrompt("Main Menu");

            //
            // reset finch robot
            //
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();

            return robotConnected;
        }

        #endregion

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
        #endregion
    }
}
