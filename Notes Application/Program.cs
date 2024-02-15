namespace Notes_Application
{
	internal class Program
	{
		// Core notepad functionality.
		static void Main(string[] args)
		{
			string fileName = null;
			Console.WriteLine("Notepad | Press ESC key to open document options                 ");
			int userLeft = 0;
			int userTop = 0;

			while (true)
			{
				var keyInfo = Console.ReadKey(intercept: true);

				switch (keyInfo.Key)
				{
					case ConsoleKey.Escape:
						Options(userLeft, userTop);
						break;

					case ConsoleKey.Enter:
						Console.Write("\n"); // move cursor to a new column
						userTop++; // state that the user has moved into a new column
						userLeft = 0; // reset the row position for the current collumn
						break;

					default:
						Console.Write(keyInfo.KeyChar); // echo the character to the console
						userLeft++; // state that the user has moved one row position in this column
						break;
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
		static void NotepadOpen(int userLeft, int userTop)
		{
			string fileExtension = "txt";
			// Console.WriteLine("Enter the file extension to search for:");
			// string fileExtension = Console.ReadLine();

			Console.WriteLine("Enter the directory to search inside:");
			string chosenDirectory = Console.ReadLine();

			ProcessDirectory(chosenDirectory, fileExtension);
		}


		// "Save" file logic.
		static void NotepadSave(int userLeft, int userTop)
		{

		}


		// "Save As" file logic
		static void NotepadSaveas(int userLeft, int userTop)
		{

		}


		// "New" file logic.
		static void NotepadNew(int userLeft, int userTop)
		{

		}


		// Settings
		static void Settings(int userLeft, int userTop)
		{
			Console.WriteLine("Notepad | Settings");
		}


		// Options Menu
		static void Options(int userLeft, int userTop)
		{
			Console.SetCursorPosition(0, 0);
			Console.WriteLine("Notepad | (1: Open) (2: Save) (3: Save As) (4: New) (5: Settings)");
			Console.SetCursorPosition(userLeft, (userTop + 1));


			var keyInfo = Console.ReadKey(intercept: true);

			switch (keyInfo.Key)
			{
				case ConsoleKey.D1:
					NotepadOpen(userLeft, userTop);
					break;

				case ConsoleKey.D2:
					NotepadSave(userLeft, userTop);
					break;

				case ConsoleKey.D3:
					NotepadSaveas(userLeft, userTop);
					break;

				case ConsoleKey.D4:
					NotepadNew(userLeft, userTop);
					break;

				case ConsoleKey.D5:
					Settings(userLeft, userTop);
					break;

				case ConsoleKey.Escape:
					Console.SetCursorPosition(0, 0);
					Console.WriteLine("Notepad | Press ESC key to open document options                 ");
					Console.SetCursorPosition(userLeft, (userTop + 1));
					break;

				default:
					Console.SetCursorPosition(0, 0);
					Console.WriteLine("Notepad | Press ESC key to open document options                 ");
					Console.SetCursorPosition(userLeft, (userTop + 1));
					break;

			}

		}
	}
}
