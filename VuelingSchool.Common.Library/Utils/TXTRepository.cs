using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using VuelingSchool.Common.Library.Models;

namespace VuelingSchool.Common.Library.Utils
{
	public class TXTRepository : AbstractFileManager
	{
		private static readonly string localPath = ConfigurationSettings.AppSettings["localPath"] + "txt";

		private static readonly log4net.ILog log
		  = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


		public override Student Add(Student student)
		{
			Student returnedStudent;
			try
			{
				using (StreamWriter sw = new StreamWriter(localPath, true))
				{
					sw.WriteLine(studentToString(student));
				}
				returnedStudent = GetById(student.StudentId);

			}
			catch (IOException e)
			{
				log.Warn(e.Message);
				throw;
			}
			catch (ObjectDisposedException e)
			{
				log.Warn(e.Message);
				throw;
			}
			return returnedStudent;
		}


		public override Student GetById(string id)
		{
			Student student;

			try
			{
				List<Student> students = new List<Student>();
				string line = "";
				using (StreamReader sr = new StreamReader(localPath))
				{
					while ((line = sr.ReadLine()) != null)
					{
						students.Add(stringToStudent(line));
					}
				}
				student = students.FirstOrDefault(s => s.StudentId == id);
				

			}
			catch (ArgumentNullException e)
			{
				log.Warn(e.Message);
				throw;
			}
			catch (ArgumentException e)
			{
				log.Warn(e.Message);
				throw;
			}
			catch (OutOfMemoryException e)
			{
				log.Warn(e.Message);
				throw;
			}
			return student;
		}

		public override List<Student> GetAll()
		{
			List<Student> students;
			try
			{
				students = new List<Student>();
				string line = string.Empty;
				using (StreamReader sr = new StreamReader(localPath))
				{
					while ((line = sr.ReadLine()) != null)
					{
						students.Add(stringToStudent(line));
					}
				}
			}
			catch (ArgumentNullException e)
			{
				log.Warn(e.Message);
				throw;
			}
			catch (ArgumentException e)
			{
				log.Warn(e.Message);
				throw;
			}
			catch (OutOfMemoryException e)
			{
				log.Warn(e.Message);
				throw;
			}
			return students;
		}

		public override Student Update(string id, Student studentToUpdate)
		{
			Student returnedStudent;
			try
			{
				List<Student> studentList = GetAll();

				// Block file to prevent write while modify
				// look every 1000ms if its closed

				int studentIndex = studentList.FindIndex(s => s.StudentId == id);
				studentList[studentIndex] = studentToUpdate;
				File.Delete(localPath);
				Save(studentList);
				returnedStudent = GetById(id);
			}
			catch (IOException e)
			{
				log.Warn(e.Message);
				throw;
			}
			catch (ArgumentException e)
			{
				log.Warn(e.Message);
				throw;
			}
			catch (NotSupportedException e)
			{
				log.Warn(e.Message);
				throw;
			}
			catch (UnauthorizedAccessException e)
			{
				log.Warn(e.Message);
				throw;
			}
			return returnedStudent;
		}

		public override Student Delete(string id)  // devolver booleano
		{
			Student student;

			try
			{
				student = new Student();
				List<Student> studentList = GetAll();
				int studentIndex = studentList.FindIndex(s => s.StudentId == id);
				student = studentList[studentIndex];
				studentList.RemoveAt(studentIndex);
				File.Delete(localPath);
				Save(studentList);
			}
			catch (IOException e)
			{
				log.Warn(e.Message);
				throw;
			}
			catch (ArgumentException e)
			{
				log.Warn(e.Message);
				throw;
			}
			catch (NotSupportedException e)
			{
				log.Warn(e.Message);
				throw;
			}
			catch (UnauthorizedAccessException e)
			{
				log.Warn(e.Message);
				throw;
			}
			return student;
		}

		public override void Save(List<Student> newContent)
		{
			try
			{
				using (StreamWriter sw = new StreamWriter(localPath, true))
				{
					foreach (Student student in newContent)
					{
						sw.WriteLine(studentToString(student));
					}
				}
			}
			catch (IOException e)
			{
				log.Warn(e.Message);
				throw;
			}
			catch (ArgumentException e)
			{
				log.Warn(e.Message);
				throw;
			}
			catch (NotSupportedException e)
			{
				log.Warn(e.Message);
				throw;
			}
			catch (UnauthorizedAccessException e)
			{
				log.Warn(e.Message);
				throw;
			}
		}

		public Student stringToStudent(string studentString)
		{
			Regex expression = new Regex(
				string.Concat("(?<Guid>[^,]+), ", "(?<StudentId>[^,]+), ", "(?<Name>[^,]+), ",
				"(?<Surname>[^,]+), ", "(?<Birthday>[^,]+)"));
			Match match = expression.Match(studentString);
			string guid = match.Groups["Guid"].ToString();
			Student student = new Student
			{
				StudentGuid = new Guid(guid),
				StudentId = match.Groups["StudentId"].ToString(),
				Name = match.Groups["Name"].ToString(),
				Surname = match.Groups["Surname"].ToString(),
				Birthday = match.Groups["Birthday"].ToString()
			};

			return student;
		}
		public string studentToString(Student student)
		{
			return string.Concat(student.StudentGuid.ToString(), ", ", student.StudentId, ", ", student.Name, ", ", student.Surname, ", ", student.Birthday);
		}
	}
}
