using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VuelingSchool.Common.Library.Models;
using VuelingSchool.Common.Library.Utils;
using VuelingSchool.Common.Library.Factory;
using System.Configuration;

namespace VuelingSchool.Presentation.WinSite
{
	public partial class AddForm : Form
	{
		// Adding settings of AbstractDataManagerFactory
		public static AbstractDataManagerFactory fileFactory = new FileManagerFactory();
		public static AbstractFileManager fileRepository = fileFactory.CreateFileManager("XML");
		public readonly static string localPath = ConfigurationSettings.AppSettings["localPath"] + "xml";

		// Define an Event based on the Delegate
		public event StudentAddedHandler StudentAdded;

		public AddForm()
		{
			InitializeComponent();
		}
		protected virtual void OnStudentAdded()
		{
			if (StudentAdded != null)
			{
				StudentAdded();
			}
		}

		public void btSaveStudent_Click(object sender, EventArgs e)
		{
			var student = new Student()
			{
				StudentId = txtId.Text,
				Name = txtName.Text,
				Surname = txtSurname.Text,
				Birthday = txtBirthday.Text
			};
			student.StudentGuid = Student.GenerateGuid(student);
			fileRepository.Add(student);
			OnStudentAdded();
		}
	}
}
