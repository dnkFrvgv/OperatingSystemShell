using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OperatingSystemShell
{
    public class Shell
    {
        //private string _line;
        //private string[] _commands;
        private string _currentDirectory;

        public Shell()
        {
            // init shell to home dir
            _currentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }

        public void RunLoop() 
        { 
        
            while (true)
            {
                Console.Write(">> ");
                var line = Console.ReadLine();

                if(line != null)
                {
                    var commands = SplitLine(line);
                    RunCommand(commands);
                }
                else
                {
                    throw new Exception("line cannot be empty");
                }
            }
        }


        public void RunCommand(string[] commands)
        {
            switch(commands[0].ToLower()){
                case "dir":
                    ExecuteDirCommand(commands);
                    break;

                case "echo":
                    ExecuteEchoCommand();
                    break;

                case "run":
                    ExecuteRunCommand();
                    break;

                case "help":
                    DisplayHelp();
                    break;

                //default
            }

        }

        private void DisplayHelp()
        {
            throw new NotImplementedException();
        }

        private void ExecuteRunCommand()
        {
            throw new NotImplementedException();
        }

        private void ExecuteEchoCommand()
        {
            throw new NotImplementedException();
        }

        // cd /path/to/directory
        private void ExecuteDirCommand(string[] tokens)
        {
            if (tokens[1] == null)
            {
                Console.WriteLine("Expected path after cd");
            }
            else
            {
                ChangeDirectory(tokens[1]);
            }
        }

        private bool ChangeDirectory(string path)
        {
            var listOfDirectories = CreatePathList(path);



            throw new NotImplementedException();

        }


        private LinkedList<string> CreatePathList(string path)
        {
            string[] directories = path.Split("/");
            return new LinkedList<string>(directories);
        }

        public void ShowDirectories() { }
        public string[] SplitLine(string line)
        {
            return line.Split(" ");
        }
    }
}
