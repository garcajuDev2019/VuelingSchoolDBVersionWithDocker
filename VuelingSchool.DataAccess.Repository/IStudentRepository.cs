using System;
using VuelingSchool.Common.Library.Models;

namespace VuelingSchool.DataAccess.Repository
{
	public interface IStudentRepository 
	{
		string[] StringToArrayOfProperties(string myArray);
		bool StudentExists(string id, string s);
	}
}