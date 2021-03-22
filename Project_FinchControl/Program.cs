using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;



namespace Project_FinchControl
{

    // **************************************************************************
    // **************************************************************************
    // Title: Finch Control - Menu Starter
    // Description:  Starting Solution for BirdBrain Technologies Finch - Tuples
    // Application Type: Console
    // Author: Jackilynn Millard
    // Dated 03/21/2021
    // **************************************************************************
    // **************************************************************************


    /// 
    /// *****************************************************************
    /// *                     User Commands                             *
    /// *****************************************************************
    ///

    public enum Commands
        {
            None,
            MoveForward,
            MoveBackward,
            StopMotors,
            Wait,
            TurnRight,
            TurnLeft,
            LEDOn,
            LEDOff,
            GetTemperature,
            Done
        }

   
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
                        AlarmSystemDisplayMenuScreen(finchRobot);
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


        #region DATA RECORDER

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
            Console.WriteLine("Finch will record the Temperature {0} times every {1} seconds.", NumberOfDataPoints, DataPointFrequency);
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
            Console.WriteLine("Finch has completed the data collection.");
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

            //
            // average temperature
            //

            double TotalTemps = 0;
            double AverageTemp;


            for (int num = 0; num < Temperatures.Length; num++)
            {
                TotalTemps += Temperatures[num];
            }
            AverageTemp = TotalTemps / Temperatures.Length;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("The Average Temperature is {0}° F ", (AverageTemp * 9 / 5 + 32).ToString("n2"));
            Console.WriteLine();
            Console.ReadKey();
        }

        static void DataRecorderDisplayData(double[] Temperatures)
        {
            DisplayScreenHeader("Display Data");

            DataRecorderDisplayDataTable(Temperatures);

            DisplayContinuePrompt();
        }

        #endregion


        #region ALARM SYSTEM

        /// <summary>
        /// *****************************************************************
        /// *                     Alarm System Menu                         *
        /// *****************************************************************
        /// </summary>
      
        static void AlarmSystemDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool quitAlarmSystemMenu = false;
            string menuChoice;

            string SensorToMonitor = "";
            string RangeType = "";
            int MinMaxLightThresholdValue = 0;
            double MinMaxTemperatureThresholdValue = 0.0;
            int TimeToMonitor = 0;

            do
            {
                DisplayScreenHeader("Alarm System Menu");

                //
                // get user menu choice
                //

                Console.WriteLine("\ta) Set Sensors to Monitor");
                Console.WriteLine("\tb) Set Range Type");
                Console.WriteLine("\tc) Set Min/Max Light Threshold Value");
                Console.WriteLine("\td) Set Min/Max Temperature Threshold Value");
                Console.WriteLine("\te) Set Time to Monitor");
                Console.WriteLine("\tf) Set Alarm");
                Console.WriteLine("\tq) Main Menu");
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
                        SensorToMonitor = AlarmSystemSetSensorsToMonitor();
                        break;

                    case "b":
                        RangeType = AlarmSystemSetRangeType();
                        break;

                    case "c":
                        MinMaxLightThresholdValue = AlarmSystemSetLightThresholdValue(finchRobot, RangeType);
                        break;

                    case "d":
                        MinMaxTemperatureThresholdValue = AlarmSystemSetTemperatureValue(finchRobot, RangeType);
                        break;

                    case "e":
                        TimeToMonitor = AlarmSystemSetTimetoMonitor();
                        break;

                    case "f":
                        if (SensorToMonitor == "" || RangeType == "" || MinMaxLightThresholdValue == 0 || MinMaxTemperatureThresholdValue == 0.0 || TimeToMonitor == 0)
                        {
                            Console.WriteLine("Please enter values for each parameter.");
                            DisplayContinuePrompt();
                        }
                        else
                        {
                            AlarmSystemSetAlarm(finchRobot, SensorToMonitor, RangeType, MinMaxLightThresholdValue, MinMaxTemperatureThresholdValue, TimeToMonitor);
                        }
                        break;


                    case "q":
                        quitAlarmSystemMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitAlarmSystemMenu);
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Set Alarm                                 *
        /// *****************************************************************
        /// </summary>
        
        static void AlarmSystemSetAlarm(Finch finchRobot, string SensorToMonitor, string RangeType, int MinMaxLightThresholdValue, double MinMaxTemperatureThresholdValue, int TimeToMonitor)
        {
           
            DisplayScreenHeader("Set Finch's Alarm");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Based on your selections, Finch will monitor your environment based on the following parameters:");
            Console.WriteLine();

            Console.WriteLine("Sensors to Monitor: {0}", SensorToMonitor);
            Console.WriteLine("Range Type: {0}", RangeType);
            Console.WriteLine("Min/Max Light Threshold Value: {0}", MinMaxLightThresholdValue);
            Console.WriteLine("Min/Max Temperature Threshold Value: {0}", MinMaxTemperatureThresholdValue);
            Console.WriteLine("Time to Monitor: {0}", TimeToMonitor);

            Console.WriteLine();
            Console.WriteLine(); 
            Console.WriteLine("Press any key to set Finch's alarm.");
            Console.CursorVisible = false;
            Console.ReadKey();
            Console.CursorVisible = true;
            Console.WriteLine();




            bool LightThresholdAlarm;
            bool TemperatureThresholdAlarm;

            do
            {

                LightThresholdAlarm = AlarmSystemLightThresholdAlarm(finchRobot, SensorToMonitor, RangeType, MinMaxLightThresholdValue);
                TemperatureThresholdAlarm = AlarmSystemTemperatureThresholdAlarm(finchRobot, SensorToMonitor, RangeType, MinMaxTemperatureThresholdValue);
                finchRobot.wait(500);
                

            } while (!(LightThresholdAlarm || TemperatureThresholdAlarm));

            if (LightThresholdAlarm)
            {
                Console.WriteLine("\tWARNING!! Finch has detected Light Levels outside your chosen parameters");
                finchRobot.noteOn(300);
                finchRobot.wait(2000);
                finchRobot.noteOff();

            }

            else if (TemperatureThresholdAlarm)
            {
                Console.WriteLine("\tWARNING!! Finch has detected Temperature Levels outside your chosen parameters");
                finchRobot.noteOn(300);
                finchRobot.wait(2000);
                finchRobot.noteOff();
            }

            else
            {
                Console.WriteLine("\tFinch senses all is well.");
                finchRobot.noteOff();
            }

            DisplayMenuPrompt("Alarm System");
        }




/// <summary>
/// *****************************************************************
/// *                     Light Threshold                           *
/// *****************************************************************
/// </summary>

static bool AlarmSystemLightThresholdAlarm(Finch finchRobot, string SensorToMonitor, string RangeType, int MinMaxLightThresholdValue)
        {
            int CurrentRightLightSensorValue = finchRobot.getRightLightSensor();
            int CurrentLeftLightSensorValue = finchRobot.getLeftLightSensor();

            Console.WriteLine("Finch senses the current Light Level on the Right is {0}.", CurrentRightLightSensorValue);
            Console.WriteLine("Finch senses the current Light Level on the Left is {0}.", CurrentLeftLightSensorValue);
            

            bool LightThresholdAlarm = false;

            switch (SensorToMonitor)
            {
                case "left":
                    if (RangeType == "min")
                    {
                        LightThresholdAlarm = CurrentLeftLightSensorValue < MinMaxLightThresholdValue;
                    }
                    else
                    {
                        LightThresholdAlarm = CurrentLeftLightSensorValue > MinMaxLightThresholdValue;
                    }
                    break;

                case "right":
                    if (RangeType == "min")
                    {
                        LightThresholdAlarm = CurrentRightLightSensorValue < MinMaxLightThresholdValue;
                    }
                    else
                    {
                        LightThresholdAlarm = CurrentRightLightSensorValue > MinMaxLightThresholdValue;
                    }
                    break;

                case "both":
                    if (RangeType == "min")
                    {
                        LightThresholdAlarm = (CurrentLeftLightSensorValue < MinMaxLightThresholdValue) || (CurrentRightLightSensorValue < MinMaxLightThresholdValue);
                    }
                    else
                    {
                        LightThresholdAlarm = (CurrentLeftLightSensorValue > MinMaxLightThresholdValue) || (CurrentRightLightSensorValue > MinMaxLightThresholdValue);
                    }
                    break;

                default:
                    Console.WriteLine("Finch does not know about that sensor type.");
                    break;
            }

            return LightThresholdAlarm;
        }


        /// <summary>
        /// *****************************************************************
        /// *                  Temperature Threshold                        *
        /// *****************************************************************
        /// </summary>
        
        static bool AlarmSystemTemperatureThresholdAlarm(Finch finchRobot, string SensorToMonitor, string RangeType, double MinMaxTemperatureThresholdValue)
        {
            
            double CurrentTemperatureValue = finchRobot.getTemperature();

            Console.WriteLine();
            Console.WriteLine(); 
            Console.WriteLine("\tFinch sensess that the current Tempurature is {0}° C", CurrentTemperatureValue.ToString("n"));
            Console.WriteLine();


            bool TemperatureThresholdAlarm;


            if (RangeType == "min")
            {
                TemperatureThresholdAlarm = CurrentTemperatureValue < MinMaxTemperatureThresholdValue;
            }
            else
            {
                TemperatureThresholdAlarm = CurrentTemperatureValue > MinMaxTemperatureThresholdValue;
            }

            return TemperatureThresholdAlarm;
        }

        /// <summary>
        /// *****************************************************************
        /// *                  Set Time to Monitor                          *
        /// *****************************************************************
        /// </summary>

        private static int AlarmSystemSetTimetoMonitor()
        {
            int TimeToMonitor;

            DisplayScreenHeader("Time to Monitor");


            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Enter the number of seconds you would like Finch to Monitor the environment:  ");
            TimeToMonitor = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Finch will Monitor the environment for {0} seconds.", TimeToMonitor);
            Console.WriteLine();


            DisplayContinuePrompt();

            return TimeToMonitor;
        }

        /// <summary>
        /// *****************************************************************
        /// *                 Set Light Threshold                           *
        /// *****************************************************************
        /// </summary>

        private static int AlarmSystemSetLightThresholdValue(Finch finchRobot, string RangeType)
        {
            int MinMaxLightThresholdValue;

            DisplayScreenHeader("Min/Max Light Threshold Value");

            Console.WriteLine();
            Console.WriteLine(); 
            Console.WriteLine("The Current Light Value on Finch's Right Light Sensor is {0}.", finchRobot.getRightLightSensor());
            Console.WriteLine();
            Console.WriteLine("The Current Light Value on Finch's Left Light Sensor is {0}.", finchRobot.getLeftLightSensor());

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Enter the {0} Light Threshold Value (0-255):  ", RangeType);
            MinMaxLightThresholdValue = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Finch will monitor Light Threshold for {0}", MinMaxLightThresholdValue);

            DisplayContinuePrompt();

            return MinMaxLightThresholdValue;

        }


        /// <summary>
        /// *****************************************************************
        /// *               Set Tempurature to Monitor                      *
        /// *****************************************************************
        /// </summary>

        static double AlarmSystemSetTemperatureValue(Finch finchRobot, string RangeType)
        {
            int MinMaxTemperatureThresholdValue;
            double CurrentTemperatureValue = finchRobot.getTemperature();
            

            DisplayScreenHeader("Min/Max Temperature Threshold Value");

            Console.WriteLine();
            Console.WriteLine(); 
            Console.WriteLine("Finch senses the Current Temperature is {0}° C", CurrentTemperatureValue.ToString("n"));

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Enter the {0} Tempurature Threshold Value: ", RangeType);
            MinMaxTemperatureThresholdValue = int.Parse(Console.ReadLine());
           
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Finch will monitor Tempurature Threshold for {0}° C", MinMaxTemperatureThresholdValue);

            DisplayContinuePrompt();

            return MinMaxTemperatureThresholdValue;
        }


        /// <summary>
        /// *****************************************************************
        /// *                      Set Range Type                           *
        /// *****************************************************************
        /// </summary>

        static string AlarmSystemSetRangeType()
        {
            string RangeType;

            DisplayScreenHeader("Range Type");

            bool ValidInput = false;

            do
            {
                Console.WriteLine();
                Console.WriteLine(); 
                Console.Write("What Range Type would you like Finch to Monitor? (min, max):  ");
                RangeType = Console.ReadLine().ToLower();
                Console.WriteLine();

                if (RangeType == "min" || RangeType == "max")
                {
                    ValidInput = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(); 
                    Console.WriteLine("You entered {0}. Please enter 'min' or 'max'.", RangeType);
                    Console.WriteLine();
                }

            } while (!ValidInput);


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Finch will monitor {0} range.", RangeType);
            Console.WriteLine();

            DisplayContinuePrompt();

            return RangeType;
        }

        /// <summary>
        /// *****************************************************************
        /// *                  Set Sensors To Monitor                       *
        /// *****************************************************************
        /// </summary>

        static string AlarmSystemSetSensorsToMonitor()
        {
            string SensorsToMonitor;

            DisplayScreenHeader("Sensors to Monitor");

            bool ValidInput = false;

            do
            {
                Console.WriteLine();
                Console.WriteLine(); 
                Console.Write("\tEnter Sensor(s) you would like Finch to Monitor (left, right, both):  ");
                SensorsToMonitor = Console.ReadLine().ToLower();
                Console.WriteLine();

                if (SensorsToMonitor == "left" || SensorsToMonitor == "right" || SensorsToMonitor == "both")
                {
                    ValidInput = true;
                }
                else
                {
                    Console.WriteLine(); 
                    Console.WriteLine(); 
                    Console.WriteLine($"\tYou entered {0}. Please enter 'left', 'right' or 'both'.", SensorsToMonitor);
                    Console.WriteLine();
                }

            } while (!ValidInput);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Finch will Monitor {0} sensor(s).", SensorsToMonitor);
            Console.WriteLine();


            DisplayContinuePrompt();

            return SensorsToMonitor;
        }

        #endregion


        #region USER PROGRAMMING
        private static void UserProgrammingDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool quitUserProgrammingMenu = false; 
            string menuChoice;
            


            (int MotorSpeed, int LEDBrightness, double WaitSeconds) CommandParameters = (0,0,0);


            List<Commands> Commands = new List<Commands>();

            do
            {
                DisplayScreenHeader("User Programming Menu");

                //
                // Get user menu choice
                //
                Console.WriteLine("\ta) Set Command Parameters");
                Console.WriteLine("\tb) Add Commands");
                Console.WriteLine("\tc) View Commands");
                Console.WriteLine("\td) Execute Commands");
                Console.WriteLine("\tq) Main Menu");
                Console.WriteLine(" ");
                Console.Write("\t\tPlease enter a letter for the menu choice >>  ");
                menuChoice = Console.ReadLine();
                Console.WriteLine(" ");
                Console.WriteLine(" ");

                //
                // process user menu choice
                //

                switch (menuChoice)
                {
                    case "a":
                        CommandParameters = UserProgrammingDisplayGetCommandParameters();
                        break;

                    case "b":
                        UserProgrammingDisplayGetFinchCommands(Commands); 
                        break;

                    case "c":
                        UserProgrammingDisplayCommands(Commands);
                        break;

                    case "d":
                        UserProgrammingDisplayExecuteCommands(finchRobot, Commands, CommandParameters);
                        CommandParameters = (0, 0, 0);
                        break;

                    case "q":
                        quitUserProgrammingMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }
            } while (!quitUserProgrammingMenu);
        }

        public static void UserProgrammingDisplayExecuteCommands(Finch finchRobot, List<Commands> Command, (int MotorSpeed, int LEDBrightness, double WaitSeconds) CommandParameters)
        {

            int MotorSpeed = CommandParameters.MotorSpeed;
            int LEDBrightness = CommandParameters.LEDBrightness;
            int WaitSeconds = (int)(CommandParameters.WaitSeconds * 1000);
            double Temperature;
            string CommandInput = "";

            foreach (Commands command in Command)
            {
                switch (command)
                {
                    case Commands.None:
                        break;

                    case Commands.MoveForward:
                        finchRobot.setMotors(MotorSpeed, MotorSpeed);
                        CommandInput = Commands.MoveForward.ToString();
                        break;

                    case Commands.MoveBackward:
                        finchRobot.setMotors(-MotorSpeed, -MotorSpeed);
                        CommandInput = Commands.MoveBackward.ToString();
                        break;

                    case Commands.StopMotors:
                        finchRobot.setMotors(0, 0);
                        CommandInput = Commands.StopMotors.ToString();
                        break;

                    case Commands.Wait:
                        finchRobot.wait(WaitSeconds);
                        CommandInput = Commands.Wait.ToString();
                        break;

                    case Commands.TurnRight:
                        finchRobot.setMotors(0, MotorSpeed);
                        CommandInput = Commands.TurnRight.ToString();
                        break;

                    case Commands.TurnLeft:
                        finchRobot.setMotors(MotorSpeed, 0);
                        CommandInput = Commands.TurnLeft.ToString();
                        break;

                    case Commands.LEDOn:
                        finchRobot.setLED(LEDBrightness, LEDBrightness, LEDBrightness);
                        CommandInput = Commands.LEDOn.ToString();
                        break;

                    case Commands.LEDOff:
                        finchRobot.setLED(0, 0, 0);
                        CommandInput = Commands.LEDOff.ToString();
                        break;

                    case Commands.GetTemperature:
                        Temperature = finchRobot.getTemperature();
                        CommandInput = $"\tFinch sensess that the current Tempurature is {Temperature:n}° C";
                        break;

                    case Commands.Done:
                        CommandInput = Commands.Done.ToString();
                        break;

                    default:
                        break;
                }
                Console.WriteLine("\t{0}", CommandInput);
            }
        }


        static void UserProgrammingDisplayCommands(List<Commands> Commands)
        {
            DisplayScreenHeader("Finch Command List");
            foreach (Commands Command in Commands)
            {
                Console.WriteLine($"\t{Commands}");
            }
            DisplayMenuPrompt("Return to User Programming Menu");
        }

        private static void UserProgrammingDisplayGetFinchCommands(List<Commands> Commands)
        {
 
            Commands Command = Commands.None;

            DisplayScreenHeader("Finch Commands");

            int commandCount = 1;

            Console.WriteLine("\tCommands Available");
            Console.WriteLine();
            Console.Write("\t-");

            foreach (string CommandName in Enum.GetNames(typeof(Commands)))
            {
                Console.Write($"- {CommandName.ToLower()}  -");
                if (commandCount % 5 == 0) Console.Write("\n\t-");
                commandCount++;
            }
            Console.WriteLine();

            while (Command != Commands.Done)
            {
                Console.Write("\tEnter command: ");

                if (Enum.TryParse(Console.ReadLine().ToUpper(), out Command))
                {
                    Commands.Add(Command);
                }
                else
                {
                    Console.WriteLine("\t\tPlease enter a command from the list above.");
                }
            }

            Console.WriteLine();
            Console.WriteLine("\tYour list of Commands for Finch to perform");

            for (int i = 0; i < Commands.Count; i++)
            {
                Console.WriteLine(Commands[i]);
            }

            DisplayContinuePrompt();

        }

        static (int MotorSpeed, int LEDBrightness, double WaitSeconds) UserProgrammingDisplayGetCommandParameters()
        {
            DisplayScreenHeader("Finch Command Parameters Menu");
            (int MotorSpeed, int LEDBrightness, double WaitSeconds) CommandParameters = (0,0,0);

            Console.WriteLine("How fast would you like Finch to go?   (1 - 255)");
            int.TryParse(Console.ReadLine(), out CommandParameters.MotorSpeed);
            while (CommandParameters.MotorSpeed < 0 || CommandParameters.MotorSpeed >= 255 || CommandParameters.MotorSpeed == 0) ;
            {
                Console.WriteLine("Finch cannot go that speed, please enter a number between 1 and 255.");
                CommandParameters.MotorSpeed = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(); 
            Console.WriteLine(" You wish for Finch to travel at a speed of {0}.", CommandParameters.MotorSpeed);
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("How bright would you like Finch to display the LEDs?  (1 - 255)");
            int.TryParse(Console.ReadLine(), out CommandParameters.LEDBrightness);
            while (CommandParameters.LEDBrightness < 0 || CommandParameters.LEDBrightness >= 255 || CommandParameters.LEDBrightness == 0) ;
            {
                Console.WriteLine("Finch does not have that setting for the LEDs, please enter a number between 1 and 255.");
                CommandParameters.LEDBrightness = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("You wish for the Finch to display the LEDs at {0} brightness", CommandParameters.LEDBrightness);

            Console.WriteLine("Enter the amount time you want the wait duration to be in seconds, (1 - 10)");
            double.TryParse(Console.ReadLine(), out CommandParameters.WaitSeconds);
            while (CommandParameters.WaitSeconds < 0 || CommandParameters.WaitSeconds >= 10 || CommandParameters.WaitSeconds == 0) ;
            {
                Console.WriteLine("Your selection is not valid.  Please enter an amount of time between 1 and 10");
                CommandParameters.WaitSeconds = double.Parse(Console.ReadLine());
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Your Selecctions are as follows");
            Console.WriteLine();
            Console.WriteLine("\tFinch's Speed:  {0}", CommandParameters.MotorSpeed);
            Console.WriteLine("\tLED Brightness:  {0}", CommandParameters.LEDBrightness);
            Console.WriteLine("\tWait Duration:  {0}", CommandParameters.WaitSeconds);
            Console.WriteLine();
            Console.WriteLine();
            DisplayMenuPrompt("Return to User Programming Menu.");
            return CommandParameters;
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
