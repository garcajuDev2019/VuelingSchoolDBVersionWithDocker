using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VuelingSchool.Common.Library.Factory;
using VuelingSchool.Common.Library.Models;
using VuelingSchool.Common.Library.Utils;
using VuelingSchool.DataAccess.Repository;

namespace VuelingSchool.Presentation.Console
{
	using System;
	public class RetrieveStudentDataMenu
	{
		public static AbstractDataManagerFactory fileFactory = new FileManagerFactory();
		public static AbstractFileManager fileRepository;



		public static Student AddNewMenu(string typeOfData)
		{
			fileRepository = fileFactory.CreateFileManager(typeOfData);
			Student exist, student;
			do
			{
				student = new Student();
				PropertyInfo[] properties = student.GetType().GetProperties();
				foreach (var p in properties)
				{
					if (p.Name != "StudentGuid")
					{
						System.Console.WriteLine("Plese enter the {0}:", p.Name);
						var myVal = System.Console.ReadLine();
						p.SetValue(student, myVal);
					}
				}
				var students = fileRepository.GetAll();
				exist = (students == null ? null : students.Find(s => s.StudentId == student.StudentId));
			} while (exist != null);
			student.StudentGuid = student.GenerateGuid();
			
			return fileRepository.Add(student); 
		}

		public static Student SelectById(string typeOfData)
		{
			fileRepository = fileFactory.CreateFileManager(typeOfData);
			Student returnedStudent;
			do
			{
				System.Console.WriteLine("Please enter the id of the student:");
				var id = System.Console.ReadLine();
				returnedStudent = fileRepository.GetById(id);
			} while (returnedStudent == null);
			
			Console.WriteLine(returnedStudent.StudentGuid.ToString());
			return returnedStudent;
		}

		internal static void GetAll(string typeOfData)
		{
			fileRepository = fileFactory.CreateFileManager(typeOfData);

			var listOfStudents = fileRepository.GetAll();
			if (listOfStudents != null)
			{ 
				var studentString = "";
				foreach (var s in listOfStudents)
				{
					studentString = StudentRepository.studentToString(s);
					System.Console.WriteLine(studentString);
				}
			}
		}

		internal static void Update(string typeOfData)
		{
			fileRepository = fileFactory.CreateFileManager(typeOfData);
			Student returnedStudent;
			string id;
			do
			{
				System.Console.WriteLine("Please enter the id of the student:");
				id = System.Console.ReadLine();

				returnedStudent = fileRepository.GetById(id);

			} while (returnedStudent == null);

			Console.WriteLine("Enter the new values:");
			Console.WriteLine("Name:");
			returnedStudent.Name = Console.ReadLine();
			Console.WriteLine("Surname:");
			returnedStudent.Surname = Console.ReadLine();
			Console.WriteLine("Birthday:");
			returnedStudent.Birthday = Console.ReadLine();

			var newReturnedStudent = fileRepository.Update(id, returnedStudent);

			Console.WriteLine(newReturnedStudent);

		}

		internal static void Remove(string typeOfData)
		{
			fileRepository = fileFactory.CreateFileManager(typeOfData);
			Student deletedStudent, studentToDelete;
			string id;
			do
			{
				System.Console.WriteLine("Please enter the id of the student:");
				id = System.Console.ReadLine();
				var students = fileRepository.GetAll();
				studentToDelete = students.Find(s => s.StudentId == id);
			} while (studentToDelete == null);
			deletedStudent = fileRepository.Delete(id);
			Console.WriteLine(deletedStudent.StudentGuid.ToString());
		}
	}
}
