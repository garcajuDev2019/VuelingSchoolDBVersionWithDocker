using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingSchool.Common.Library.Models;

namespace VuelingSchool.Common.Library.Utils
{
	public abstract class AbstractFileManager
	{
		public abstract Student Add(Student student);
		public abstract Student GetById(string id);
		public abstract List<Student> GetAll();
		public abstract Student Update(string id, Student studentToUpdate);
		public abstract Student Delete(string id);
		public abstract void Save(List<Student> newContent);
	}
}
