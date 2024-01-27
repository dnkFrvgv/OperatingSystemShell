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

        [Fact]
        public void ChangeDir() 
        {
            // arrange
            Shell shell = new Shell();
            string path = "C:\\Users\\domis";

            // act
            var result = shell.ValidatePath(path);

            // assert
            Assert.True(result);
        }

/*        [Fact]
        public void ExecuteDirCommand_multiple_args_returns_false() {
            // arrange
            Shell shell = new Shell();
            string path = "cd path\\to\\dir second\\arg";

            string[] command = path.Split(" ");

            // act
            var result = shell.ExecuteDirCommand(command);

            // assert
            Assert.False(result);
        }*/

        [Fact]
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