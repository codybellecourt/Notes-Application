namespace Notes_Application
{
    internal class Program
    {
        // Core notepad functionality.
        static void Main(string[] args)
        {
            Console.WriteLine("Notepad | Press ESC to open options menu");

            while (true)
            {
                var keyInfo = Console.ReadKey(intercept: true);
                if (keyInfo.Key == ConsoleKey.Escape || keyInfo.Key == ConsoleKey.Escape)
                {
                    Options();
                }
                else
                {
                    Console.Write(keyInfo.KeyChar); // echo the character to the console
                }
            }
        }


        // Search all files with a specified file extension in a specified directory and its subdirectories.
        public static void ProcessDirectory(string targetDirectory, string fileExtension)
        {
            try
            {
                // Process the list of files found in the directory.
                string[] fileEntries = Directory.GetFiles(targetDirectory);
                foreach (string fileName in fileEntries)
                    if (Path.GetExtension(fileName) == "." + fileExtension)
                        ProcessFile(fileName);

                // Recurse into subdirectories of this directory.
                string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
                foreach (string subdirectory in subdirectoryEntries)
                    ProcessDirectory(subdirectory, fileExtension);
            }

            // Inform the user if the directory cannot be accessed due to permissions.
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Permission denied for directory: " + targetDirectory);
            }

            // Inform the user if the directory cannot be accessed due to other reasons, and show the reason.
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while processing directory: " + targetDirectory);
                Console.WriteLine("Error message: " + ex.Message);
            }
        }


        // When a file is processed it executes these actions.
        public static void ProcessFile(string path)
        {
            Console.WriteLine("Processed file '{0}'.", path);
        }


        // "Open" file logic.
        static void NotepadOpen()
        {
            string fileExtension = "txt";
            // Console.WriteLine("Enter the file extension to search for:");
            // string fileExtension = Console.ReadLine();

            Console.WriteLine("Enter the directory to search inside:");
            string chosenDirectory = Console.ReadLine();

            ProcessDirectory(chosenDirectory, fileExtension);
        }


        // "Save" file logic.
        static void NotepadSave()
        {

        }


        // "Save As" file logic
        static void NotepadSaveas()
        {

        }


        // "New" file logic.
        static void NotepadNew()
        {

        }


        // Settings
        static void Settings()
        {
            Console.WriteLine("Notepad | Settings");
        }


        // Options Menu
        static void Options()
        {
            Console.WriteLine("Notepad | (1: Open) (2: Save) (3: Save As) (4: New) (5: Settings)");

            ConsoleKeyInfo response = Console.ReadKey(true);

            switch (response.KeyChar)
            {
                case '1':
                    NotepadOpen();
                    break;

                case '2':
                    NotepadSave();
                    break;

                case '3':
                    NotepadSaveas();
                    break;

                case '4':
                    NotepadNew();
                    break;

                case '5':
                    Settings();
                    break;

                default:
                    Console.WriteLine("\nCanceled.");
                    break;
            }
    
        }
    }
}
