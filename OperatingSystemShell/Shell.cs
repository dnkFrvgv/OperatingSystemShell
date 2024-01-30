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
using System.IO;

namespace OperatingSystemShell
{
    [SupportedOSPlatform("windows")]
    public class Shell
    {
        public string _currentDirectory;
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
            // if no arg was passed or arg is "." set to home dir
            if (tokens.Length == 1 || tokens.Length > 1 && tokens[1] == ".")
            {
                _currentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                return true;
            }
            else
            {
                if(IsPathValid(tokens[1]))
                {
                    // is a full path
                        // 1.set current dir to                         
                    var listOfDirectories = CreatePathList(tokens[1]);

                    // is it a relative path?
                    if (!tokens[1].StartsWith('\\') || tokens[1].StartsWith('.'))
                    {
                        // 1.join path to _current dir 
                        // 2.set current dir to dir
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

                return false;
            }
        }

 

        public bool IsPathValid(string path)
        {
            var lastPosition = path.LastIndexOf("\\");

            bool isLastPositionAFile = path.Substring(lastPosition + 1).Contains('.');

            // last position is a file?
            if (isLastPositionAFile)
            {

                if (File.Exists(path))
                {
                    if (UserHasFilePermissions(path))
                    {
                        return true;
                    }

                    HandleError("User doenst have permission to view file");
                    return false;
                }
            }
            else
            {
                if (Directory.Exists(path))
                {
                    if (UserHasDirectoryPermission(path))
                    {
                        return true;
                    }

                    HandleError("User doenst have permission to view dir");
                    return false;
                }
            }

            HandleError("path doesnt exist");
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
