using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VuelingSchool.Common.Library.Utils;
using VuelingSchool.Common.Library.Factory;
using VuelingSchool.Common.Library.Models;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace VuelingSchool.Presentation.WinSite
{
	public partial class VuelingForms : Form
	{
		AddForm addForm;

		public static AbstractDataManagerFactory fileFactory = new FileManagerFactory();
		public static AbstractFileManager fileRepository = fileFactory.CreateFileManager("XML");
		public readonly static string localPath = ConfigurationSettings.AppSettings["localPath"] + "xml";

		DataSet formDataSet;

		public VuelingForms()
		{
			InitializeComponent();
			RefreshDataGrid();
			
			formDataSet = new DataSet();

			BindingSource bindSource = new BindingSource();
			bindSource.DataSource = VuelingSingleton.Instance.SelectStates();
			cbStates.DataSource = bindSource;
		}

		/// <summary>
		/// Refresh the datagrid with the new data on persistent repository, on an event is fired
		/// </summary>
		public void RefreshDataGrid()
		{
			if (!File.Exists(localPath))
			{
				GenerateXmlFile();
			}
			if (fileRepository.GetAll() == null)
				formDataSet = null;
			else
			{
				formDataSet = new DataSet();
				formDataSet.ReadXml(localPath);
				studentDataGrid.DataSource = formDataSet.Tables[0];
				studentDataGrid.Columns["StudentGuid"].Visible = false;
			}
		}

		/// <summary>
		/// Generate a new Guid, based on the values of the Student
		/// </summary>
		/// <param name="studentList"></param>
		/// <returns>List<Student></returns>
		private List<Student> GenerateGuidsOnNewRows(List<Student> studentList)
		{
			var newList = new List<Student>();
			foreach (var student in studentList)
			{
				var newStudent = student;
				newStudent.StudentGuid = Student.GenerateGuid(student);
				newList.Add(newStudent);
			}
			return newList;
		}

		/// <summary>
		/// If the XML file doesn't exist, create new one based on student properties
		/// </summary>
		private void GenerateXmlFile()
		{
			var empty = string.Empty;
			Student s = new Student(empty, empty, empty, empty);
			List<Student> emptyList = new List<Student>() { s };
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
			FileStream fileStream = File.Create(localPath);
			xmlSerializer.Serialize(fileStream, emptyList);
			fileStream.Close();
		}

		/// <summary>
		/// Save changes of the dataset on XML
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void btSave_Click(object sender, EventArgs e)
		{
			formDataSet.WriteXml(localPath, XmlWriteMode.WriteSchema);
			var studentList = fileRepository.GetAll();

			var newstudentList = GenerateGuidsOnNewRows(studentList);
			fileRepository.Save(newstudentList);
			RefreshDataGrid();
		}

		/// <summary>
		/// Persists the changes of the DataGridView on an XML
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btAdd_Click_1(object sender, EventArgs e)
		{
			addForm = new AddForm();
			addForm.StudentAdded += new StudentAddedHandler(this.RefreshDataGrid); // Importante suscribir el metodo que queremos directamente desde el metodo que lanza el segundo evento
			addForm.Show();
		}
	}
}
