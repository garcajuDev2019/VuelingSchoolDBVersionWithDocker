using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VuelingSchool.Common.Library.Models
{

	public class Student
	{
		private static readonly log4net.ILog log
		  = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



		public Guid StudentGuid { get; set; }
		public string StudentId { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Birthday { get; set; }


		public Student()
		{
		}

		public Student(Guid studentGuid, string studentId, string name, string surname, string birthday)
		{
			StudentId = studentId;
			Name = name;
			Surname = surname;
			Birthday = birthday;
			StudentGuid = studentGuid;
		}

		public Student(string studentId, string name, string surname, string birthday)
		{
			StudentId = studentId;
			Name = name;
			Surname = surname;
			Birthday = birthday;
		}

		public Guid GenerateGuid()
		{
			string userInput = (this.StudentId + this.Name + this.Surname + this.Birthday);
			using (MD5 md5 = MD5.Create())
			{
				try
				{
					byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes(userInput));
					Guid studentGuid = new Guid(hash);
					return studentGuid;
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
			}
		}
		public static Guid GenerateGuid(Student student)
		{
			string userInput = (student.StudentId + student.Name + student.Surname + student.Birthday);
			using (MD5 md5 = MD5.Create())
			{
				Guid newGuid;
				try
				{
					byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes(userInput));
					Guid studentGuid = new Guid(hash);
					newGuid = studentGuid;
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

				return newGuid;
			}
		}


		public override bool Equals(object obj)
		{
			var student = obj as Student;
			return student != null &&
				   StudentId == student.StudentId &&
				   Name == student.Name &&
				   Surname == student.Surname &&
				   Birthday == student.Birthday;
		}

		public override int GetHashCode()
		{
			var hashCode = -387832195;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(StudentId);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Surname);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Birthday);
			return hashCode;
		}
	}
}
