using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Escape
{
    // In this class making how does player have to move.
    // Making a map so it can be easier for player to play the game.
    class Game
    {
        Nurse nurse;
        Parser parser;
        bool player;

        // creating the list for items.
        public static string[] items = { "Stethescope", 
                                         "BP machine", 
                                         "Heart machine", 
                                         "Brownie points", 
                                         "Clipboard",
                                         "Defibrilator"};
        public static int limitedPoint = 0;
        private static Game unique_game;
        private List<Rooms> observerRooms = new List<Rooms>();
        public static List<Rooms> rooms = new List<Rooms>();

        // initializing the things what we need to use.
        public Game()
        {
            player = false;
            parser = new Parser(new CommandWord());
            nurse = new Nurse(createWorld());
            register(nurse);
            NotificationCenter.Instance.AddObserver(" patient saved ", patientSaved);
        }
        // using getInstance class to creating the game. if there is no game then their will be no players.
        // ( using Null to give reference ).
        // Singleton pattern 
        // control object creation and in used via get instance class.
        public static Game getInstance()
        {
            if (unique_game == null)
            {
                unique_game = new Game();
            }
            return unique_game;
        }

        // creating new world for hospital escape and new rooms.
        public Rooms createWorld()
        {
            ItemCreator factory = new ItemCreator();
            // placing the items in room
            Rooms outside = new Rooms("Enterance");
            Rooms HelpDesk = new Rooms("HelpDesk");
            HelpDesk.placeItem(factory.FactoryMethod("Bp machine"));
            HelpDesk.placeItem(factory.FactoryMethod("Heart machine"));
            HelpDesk.placeItem(factory.FactoryMethod("Clipboard"));
            HelpDesk.placeItem(factory.FactoryMethod("Stethescope"));
            HelpDesk.placeItem(factory.FactoryMethod("defibrillator"));

            // placing the items in check up room
            Rooms Check_up_Room  = new Rooms("Check_up_Room");
            Check_up_Room.placeItem(factory.FactoryMethod("Bp machine"));
            Check_up_Room.placeItem(factory.FactoryMethod("Clipboard"));
            Check_up_Room.placeItem(factory.FactoryMethod("Stethescope"));

            // placing the items in doctor room
            Rooms Doctor_Office = new Rooms("Doctor_Office");
            Doctor_Office.placeItem(factory.FactoryMethod("Clipboard"));
            Doctor_Office.placeItem(factory.FactoryMethod("Stethescope"));

            // placing the items in patient room
            Rooms Patient_Room = new Rooms("Patient_Room");
            Patient_Room.AddPatient(new Patient());
            Patient_Room.AddPatient(new Patient());
            Patient_Room.AddPatient(new Patient());
            Patient_Room.AddPatient(new Patient());

            Patient_Room.placeItem(new Item("ClipBoard", 1, 3));

            // placing the items in emergency room.
            Rooms Emergency_room = new Rooms("Emergency_Room");
            Emergency_room.placeItem(factory.FactoryMethod("Bp machine"));
            Emergency_room.placeItem(factory.FactoryMethod("Heart machine"));
            Emergency_room.placeItem(factory.FactoryMethod("ClipBoard"));
            Emergency_room.placeItem(factory.FactoryMethod("Stethescope"));
            Emergency_room.placeItem(factory.FactoryMethod("defibrillator"));

            // placing the items in cafe room
            Rooms Cafe_room = new Rooms("Cafe_Room");
 //           Cafe_room.placeItem(factory.FactoryMethod("Soda"));
 //           Cafe_room.placeItem(factory.FactoryMethod("Lunch"));
  //          Cafe_room.placeItem(factory.FactoryMethod("Desert"));

            outside.setExit("North", HelpDesk);
            rooms.Add(outside);
            HelpDesk.setExit("East", Patient_Room);
            HelpDesk.setExit("West", Check_up_Room);
            HelpDesk.setExit("North", Cafe_room);
            HelpDesk.setExit("South", outside);

            rooms.Add(HelpDesk);
            Check_up_Room.setExit("East", HelpDesk);
            Check_up_Room.setExit("South", Emergency_room);
            rooms.Add(Check_up_Room);
            Doctor_Office.setExit("South", Patient_Room);
            rooms.Add(Doctor_Office);
            Patient_Room.setExit("North", Patient_Room);
            rooms.Add(Patient_Room);
            Emergency_room.setExit("North", Check_up_Room);
            Emergency_room.AddPatient(new Patient());
            rooms.Add(Emergency_room);
            Cafe_room.isAvailable = false;
            Cafe_room.Items["brownie"] = 1;
            this.observerRooms.Add(Cafe_room);
            return outside;
        }

        public void patientSaved(Notification notification)
        {
            Nurse nurse = (Nurse)notification.Object;
            // using notification pattern to send a notification.
            nurse.giveBrownie();
            nurse.outputMessage("you saved a patient! you get a brownie point.\n your total brownie points are"+nurse.checkInventory("Brownie points").ToString());
        }

        // registering the rooms for the player.

        public void register(Nurse nurse)
        {
            foreach(Rooms rooms in this.observerRooms)
            {
                nurse.registerObserver(rooms);
            }
        }
        // it's starting the game.
        public void play()
        {
            bool finished = false;
            while(!finished)
            {
                Console.Write("\n>");
                Command command = parser.parseCommand(Console.ReadLine());
                if (command == null)
                {
                    Console.WriteLine(" I don't quiet understand what you meant... ");
                }
                else
                {
                    finished = command.Execute(nurse);
                }
            }
        }
        // starting up the game.
        public void start()
        {
            player = true;
            nurse.outputMessage(welcome());
        }

        // ending the game.
        public void end()
        {
            player = false;
            nurse.outputMessage(goodbye());
        }
        // displaying the welcome message for the game.
        public string welcome()
        {
            string str = "\n\n";
            str += "     _________________________________________________________________________________________________________ \n";
            str += "    |                                           | Hospital Escape |                                           |\n";
            str += "    |                                           |_________________|                                           |\n";
            str += "    |                                                                                                         |\n";
            str += "    |                                                                                                         |\n";
            str += "    |                                                                                                         |\n";
            str += "    |                                                                                                         |\n";
            str += "    |                                                                                                         |\n";
            str += "    |                                              Cafe                            Doctor Office              |\n";
            str += "    |                                                |                               |                        |\n";
            str += "    |                                                |                               |                        |\n";
            str += "    |                                                |                               |                        |\n";
            str += "    |                                                |                               |                        |\n";
            str += "    |                                                |                               |                        |\n";
            str += "    |                                                |                               |                        |\n";
            str += "    |                     Check_Up Room <_________ Help Desk ______________> Patient Room                     |\n";
            str += "    |                              |                 |                                                        |\n";
            str += "    |                              |                 |                                                        |\n";
            str += "    |                              |                 |                                                        |\n";
            str += "    |                              |                 |                                                        |\n";
            str += "    |                              |                 |                                                        |\n";
            str += "    |                              |                 |                                                        |\n";
            str += "    |                         Emergency           Enterance                                                   |\n";
            str += "    |                                                                                                         |\n";
            str += "    |                                                                                                         |\n";
            str += "    |_________________________________________________________________________________________________________|\n";
            str += "\n";
            return " Welcome to Hospital Escape! \n\n " +
                str+
                    "\n\n Type 'help' if you need help. " + nurse.currentRoom.description();
        }

        // displaying the good bye message.
        public string goodbye()
        {
            return "\n Thank you for playing, Goodbye. \n";
        }
        // creating patients in the room.

        public void createPatients (Rooms rooms)
        {
            Random random = new Random();
            for(int i=0; i<= random.Next(1,10); i++)
            {
                rooms.patients.Add(new Patient());
            }
        }
        
    }
}
