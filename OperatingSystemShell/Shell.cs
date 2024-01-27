using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Runtime.Versioning;

namespace OperatingSystemShell
{
    [SupportedOSPlatform("windows")]
    public class Shell
    {
        private string _currentDirectory;
        private WindowsIdentity _currentUser;
        private bool _hasError = false;

        public Shell()
        {
            _currentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            _currentUser = WindowsIdentity.GetCurrent();
        }

        public void RunLoop() 
        { 
        
            while (true)
            {
                Console.Write(">> ");
                var line = Console.ReadLine();

                if(line != null)
                {
                    var commands = line.Split(" ");
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
                    if (ExecuteDirCommand(commands))
                    {
                        return;
                    }
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
                default:
                    HandleError("An error occurred");
                    break;

            }

        }

        private void HandleError(string v)
        {
            throw new NotImplementedException();
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

        public bool ExecuteDirCommand(string[] tokens)
        {
            // if no arg was passed set to home dir
            // TODO - or args is .
            if (tokens.Length == 1)
            {
                _currentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                return true;
            }
            else
            {
                ValidatePath(tokens[1]);
                
                return true;
            }
        }

 

        public bool ValidatePath(string path)
        {
            var listOfDirectories = CreatePathList(path);

            // is it a relative path?
            if (!path.StartsWith('\\') || path.StartsWith('.'))
            {
                // path exists?
                if (Directory.Exists(path))
                {
                    if (UserHasDirectoryPermission(path))
                    {
                        return true;

                    }
                    HandleError("User doenst have permission to view dir");
                    return false;
                }

                HandleError("path doesnt exist");
                return false;
            }
            // go up a level?
            if (listOfDirectories.First!.Value == "..")
            {
                // TODO
            }
            // whats left should be a full path
            else
            {
                // TODO
            }

            return false;


        }

        private bool UserHasFilePermissions(string path)
        {
            throw new NotImplementedException();
        }

        public bool UserHasDirectoryPermission(string dirPath)
        {
            var userDeviceAndName = _currentUser.Name;

            var dirInfo = new DirectoryInfo(dirPath);
            DirectorySecurity accessControlList = dirInfo.GetAccessControl(AccessControlSections.All);

            throw new NotImplementedException();
        }

        public LinkedList<string> CreatePathList(string path)
        {
            string[] directories = path.Split("\\");
            return new LinkedList<string>(directories);
        }

        public void ShowDirectories() { }
        public string[] SplitLine(string line)
        {
            return line.Split(" ");
        }
    }
}
