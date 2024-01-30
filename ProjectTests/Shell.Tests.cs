using OperatingSystemShell;
using System.Runtime.Versioning;

namespace ProjectTests
{
    [SupportedOSPlatform("windows")]
    public class ShellTests
    {
        [Fact]
        public void CreatePathList()
        {

            // arrange
            Shell shell = new Shell();
            string path = "C:\\Users\\User\\Documents";

            // act
            var result = shell.CreatePathList(path);


            // assert
            Assert.NotNull(result.First);
            Assert.Contains("C:", result.First.Value);

        }

        //[Fact]
        public void ChangeDir() 
        {
            // arrange
            Shell shell = new Shell();
            string path = "C:\\Users\\domis";

            // act
            var result = shell.IsPathValid(path);

            // assert
            Assert.True(result);
        }

        [Fact]
        public void ExecuteDirCommand_dot_arg_sets_currentDirectory_to_users_spetial_folder()
        {
            // arrange
            Shell shell = new Shell();
            string path = "cd .";

            string[] command = path.Split(" ");
            string users_spetial_folder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            // act
            var result = shell.ExecuteDirCommand(command);

            // assert
            Assert.True(result);
            Assert.Equal(shell._currentDirectory, users_spetial_folder);
        }

        //[Fact]
        public void ExecuteDirCommand_single_args_returns_true()
        {
            // arrange
            Shell shell = new Shell();
            string path = "cd path\\to\\dir";

            string[] command = path.Split(" ");

            // act
            var result = shell.ExecuteDirCommand(command);

            // assert
            Assert.True(result);
        }
    }
}