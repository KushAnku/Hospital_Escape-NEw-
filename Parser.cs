using System.Collections;
using System.Collections.Generic;
using System;

namespace Hospital_Escape
{
    // interface 
    // To convert a text to a floating-point number or value , a parsing procedure is used.
    public class Parser
    {
        private CommandWord commands;

        public Parser() : this(new CommandWord())
        {

        }
        public Parser(CommandWord newCommands)
        {
            commands = newCommands;
        }

        public Command parseCommand(string commandString)
        {
            // Create a Command object
            // to control the object creation. ( using Null to give reference ).
            Command command = null;                         
            string[] words = commandString.Split(' ');
            if (words.Length > 0)
            {
                command = commands.get(words[0]);
                if (command != null)
                {
                    if (words.Length > 1)
                    {
                        command.SecondWord = words[1];
                    }
                    else
                    {
                        command.SecondWord = null;
                    }
                }
                else
                {
                    Console.WriteLine(">>>> Did not find the command " + words[0]);
                }
            }
            else
            {
                Console.WriteLine("No words are parsed!");
            }
            return command;
        }

        public string description()
        {
            return commands.description();
        }
    }
}
