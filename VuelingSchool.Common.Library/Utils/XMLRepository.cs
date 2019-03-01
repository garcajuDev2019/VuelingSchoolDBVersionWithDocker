using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingSchool.Common.Library.Models;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Xml.Serialization;


namespace VuelingSchool.Common.Library.Utils
{
	public class XMLRepository : AbstractFileManager
	{
		public static string localPath = ConfigurationSettings.AppSettings["localPath"] + "xml";


		public override Student Add(Student student)
		{

			FileIsLocked();
			XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));

			var studentList = GetAll();

			studentList.Add(student);

			using (var stream = new FileStream(localPath, FileMode.Create))
			{
				serializer.Serialize(stream, studentList);
			}

			return GetById(student.StudentId);
		}

		public override Student GetById(string id)
		{
			FileIsLocked();
			var studentList = GetAll();
			var student = studentList.Find(s => s.StudentId == id);

			return student;
		}

		public override List<Student> GetAll()
		{

			FileIsLocked();

			var studentsList = new List<Student>();

			using (var stream = new FileStream(localPath, FileMode.Open))
			{

				XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));

				studentsList = (List<Student>)serializer.Deserialize(stream);
			}
			return studentsList;

		}

		public override Student Delete(string id)
		{
			FileIsLocked();
			var studentsList = GetAll();
			var student = GetById(id);
			studentsList = studentsList.Where(s => s.StudentId != id).ToList();

			Save(studentsList);

			return student;
		}

		public override void Save(List<Student> newContent)
		{
			FileIsLocked();


			XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
			FileStream fileStream = File.Create(localPath);
			xmlSerializer.Serialize(fileStream, newContent);
			fileStream.Close();
		}

		public override Student Update(string id, Student studentToUpdate)
		{
			FileIsLocked();
			var tempStudentList = GetAll();
			tempStudentList[tempStudentList.FindIndex(ind => ind.StudentId.Equals(id))] = studentToUpdate;
			Save(tempStudentList);
			return GetById(id);
		}

		public static void GenerateXmlFile()
		{
			var FileStreamObj = new FileStream(localPath, FileMode.Create, FileAccess.ReadWrite);
			FileStreamObj.Close();

			var doc = new XmlDocument();
			XmlElement xmlElement = doc.CreateElement("Students");
			doc.Save(localPath);

			Student	s = new Student();
			XmlSerializer writer =
				new XmlSerializer(typeof(Student));

			FileStream file = System.IO.File.Create(localPath);

			writer.Serialize(file, s);
			file.Close();

		}

		public void FileIsLocked()
		{
			FileInfo file = new FileInfo(localPath);
			FileStream stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
			stream.Close();
			System.IO.FileStream fs;
			fs = System.IO.File.Open(localPath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Read, System.IO.FileShare.None);
			fs.Close();
		}

	}
}
