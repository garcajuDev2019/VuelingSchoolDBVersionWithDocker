using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingSchool.Common.Library.Models;
using Newtonsoft.Json;
using System.IO;
using System.Configuration;
using Newtonsoft.Json.Linq;
using System.Xml;


namespace VuelingSchool.Common.Library.Utils
{
	public class JSONRepository : AbstractFileManager
	{
		private static readonly log4net.ILog log
		  = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


		public static string localPath = ConfigurationSettings.AppSettings["localPath"] + "json";

		public override Student Add(Student student)
		{
			try
			{
				FileExists(localPath);

				// substituir las 2 siguientes por GetAll()
				var json = File.ReadAllText(localPath);
				var studentList = JsonConvert.DeserializeObject<List<Student>>(json);
				// crear un helper, para que quede documentado con el nombre, xq tenemos un persons == null aqui
				if (studentList == null)
					studentList = new List<Student>();
				studentList.Add(student);
				var newStudentList = JsonConvert.SerializeObject(studentList);
				File.WriteAllText(localPath, newStudentList);

				return GetById(student.StudentId);

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
		public override Student GetById(string id)
		{
			var studentList = GetAll();
			var student = studentList.Find(s => s.StudentId == id);

			return student;
		}
		public override List<Student> GetAll()
		{
			List<Student> studentsList;
			try
			{
				if (!File.Exists(localPath))
				{
					return null;
				}
				var json = File.ReadAllText(localPath);
				studentsList = JsonConvert.DeserializeObject<List<Student>>(json);
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
			return studentsList;
		}

		public override Student Update(string id, Student studentToUpdate)
		{  
			var tempStudentList = GetAll();
			tempStudentList[tempStudentList.FindIndex(ind => ind.StudentId.Equals(id))] = studentToUpdate;
			Save(tempStudentList);
			return GetById(id);
		}

		public override Student Delete(string id)
		{
			Student student;
			try
			{
				/*
				student = new Student();
				var studentList = GetAll();
				List<Student> empty = new List<Student>();
				var studentIndex = studentList.FindIndex(ind => ind.StudentId.Equals(id));
				student = studentList[studentIndex];
				studentList.RemoveAt(studentIndex);
				File.WriteAllText(localPath, "");
				Save(empty);
				Save(studentList);
				*/

				student = GetById(id);
				var studentList = GetAll();
				studentList.Remove(student);

				File.Open(localPath, FileMode.Open).Close();
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
				var newJson = JsonConvert.SerializeObject(newContent, Newtonsoft.Json.Formatting.Indented);
				File.WriteAllText(localPath, newJson);
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
		public static void FileExists(string path)
		{
			bool fileExists = File.Exists(path);
			if (!fileExists)
			{
				CreateFile(path);
			}
		}
		public static void CreateFile(string path)
		{ 
			try 
			{	        
				File.Create(path).Close();
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
	}
}
