using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VuelingSchool.Common.Library.Models;
using VuelingSchool.Common.Library.Utils;
using VuelingSchool.Common.Library.Factory;
using System.Reflection;

namespace VuelingSchool.DataAccess.Repository
{
	public class StudentRepository : IStudentRepository
	{
		private static readonly log4net.ILog log
		  = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


		public static string studentToString(Student student)
		{
			try
			{
				PropertyInfo[] properties = student.GetType().GetProperties();

				var i = 0;
				var sb = new StringBuilder();
				foreach (var p in properties)
				{
					var studentProperty = p.GetValue(student).ToString();
					sb.Append(studentProperty);
					sb.Append(", ");
					i++;
				}
				sb = sb.Remove(sb.Length - 2, 1);

				return sb.ToString();
			}
			catch (IOException e)
			{
				log.Warn(e.Message);
				throw;
			}
			catch (ArgumentOutOfRangeException e)
			{
				log.Warn(e.Message);
				throw;
			}
		}

		public Student stringToStudent(string studentString)
		{
			Student student = new Student();
			PropertyInfo[] properties = student.GetType().GetProperties();
			var i = 0;
			foreach (var p in properties)
			{
				var myVal = studentString[i];
				p.SetValue(student, myVal);
				i++;
			}
			return student;
		}


		public String[] StringToArrayOfProperties(string myArray)
		{
			try
			{
				var arrayOfStudentProperties = myArray.Split(' ').ToArray();

				return arrayOfStudentProperties;
			}
			catch (ArgumentNullException e)
			{
				log.Warn(e.Message);
				throw;
			}

		}

		public bool StudentExists (string id, string s)
		{
			try
			{
				return s.Contains(id);
			}
			catch (ArgumentNullException e)
			{
				log.Warn(e.Message);
				throw;
			}
		}
	}
}
