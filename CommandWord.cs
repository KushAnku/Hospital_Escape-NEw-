using System;
using System.Collections.Generic;
using System.Text;


namespace Hospital_Escape
{
    public class CommandWord
    {
        Dictionary<string, Command> commands;
        private static Command[] myCommandArray = { new backcommand(), new buyCommand(), new GoCommand(), new HelpCommand(), new QuitCommand(), new InventoryCommand(),new SaveCommand(), new TakeCommand()};
        


        public CommandWord()
        {
            commands = new Dictionary<string, Command>();
            foreach (Command command in myCommandArray)
            {
                commands[command.name] = command;
            }
            Command help = new HelpCommand();
            commands[help.name] = help;
        }

        public Command get(string word)
        {
            commands.TryGetValue(word, out Command command);
            return command;
        }

        public string description()
        {
            string commandNames = "";
            Dictionary<string, Command>.KeyCollection keys = commands.Keys;
            foreach(string commandName in keys)
            {
                commandNames += " " + commandName;
            }
            return commandNames;
        }
    }
}
