using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VuelingSchool.Common.Library.Models;
using VuelingSchool.Common.Library.Factory;
using VuelingSchool.Common.Library.Utils;

namespace VuelingSchool.Presentation.Console
{
	public class ConsoleMenu
	{
		public static void Menu()
		{
			var typeOfFile = ConsoleMenu.ChooseFileTypeMenu();


			while (true)
			{
				var option = OptionsMenu();
				SelectOption(option, typeOfFile);
			}
		}

		public static string ChooseFileTypeMenu()
		{
			var option = "";
			var fileType = "TXT";
			System.Console.WriteLine("By default the file type is TXT, you want to change it? y/n");
			option = System.Console.ReadLine();

			if (option.ToLower() == "n")
			{
				fileType = "TXT";
			}
			else if (option.ToLower() == "y")
			{
				fileType = ShowFileOptions();
			}
			else
			{
				System.Console.WriteLine("Please, enter a valid option!");
				fileType = ChooseFileTypeMenu();
			}

			return fileType;
		}

		private static string ShowFileOptions()
		{
			var sb = new StringBuilder();
			sb.Append("Choose a file type to work with:");
			sb.Append("\n1.    TXT");
			sb.Append("\n2.    JSON");
			sb.Append("\n3.    XML");
			System.Console.WriteLine(sb.ToString());

			var fileType = System.Console.ReadLine();
			switch (fileType)
			{
				case "2":
					return "JSON";
					break;
				case "3":
					return "XML";
					break;
				case "1":
				default:
					return "TXT";
					break;
			}
		}

		public static string OptionsMenu()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("Choose an option:");
			sb.AppendLine();
			string[] actionMenu = {"Add new student",
				"Select one student by Id",
				"Get a list of all the students",
				"Update the data of one student",
				"Remove one student",
				"Exit" }; 
			foreach (var action in actionMenu)
			{
				sb.AppendLine();
				sb.AppendFormat("{0}.    {1}", Array.IndexOf(actionMenu, action) + 1, action);
			}
			
			System.Console.WriteLine(sb.ToString());
			string option = System.Console.ReadLine();
			return option;
		}

		public static void SelectOption(string option, string typeOfData)
		{
			switch (option)
			{
				case ("1"):
					RetrieveStudentDataMenu.AddNewMenu(typeOfData);
					break;
				case "2":
					RetrieveStudentDataMenu.SelectById(typeOfData);
					break;
				case "3":
					RetrieveStudentDataMenu.GetAll(typeOfData);
					break;
				case "4":
					RetrieveStudentDataMenu.Update(typeOfData);
					break;
				case "5":
					RetrieveStudentDataMenu.Remove(typeOfData);
					break;
				case "6":
					Environment.Exit(0);
					break;
				default:
					System.Console.WriteLine("Por favor introduce un número valido");
					break;
			}
		}
	}
}
