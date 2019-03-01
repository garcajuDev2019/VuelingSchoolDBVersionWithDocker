using Microsoft.VisualStudio.TestTools.UnitTesting;
using VuelingSchool.Common.Library.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using VuelingSchool.Common.Library.Models;

namespace VuelingSchool.Common.Library.Utils.Tests
{

	[TestClass()]
	public class JSONRepositoryTests
	{
		private AbstractFileManager mockObject;
		Student inputStudent = new Student(Guid.Parse("3f1655b0-844a-0e01-8eda-7334e790858b"), "fsd", "as", "s", "asdf");
		Student outStudent = new Student();
		


		[TestInitialize]
		public void Setup()
		{
			outStudent = inputStudent;
			var mock = new Mock<AbstractFileManager>();

			mock.Setup(x => x.Add(inputStudent)).Returns(inputStudent);
			mock.Setup(x => x.Add(null)).Throws<NullReferenceException>();
			mock.Setup(x => x.GetById("1")).Returns(outStudent);
			mock.Setup(x => x.GetById(null)).Throws<ArgumentNullException>();
			mock.Setup(x => x.Update(null,inputStudent)).Throws<ArgumentNullException>();
			mock.Setup(x => x.Delete("1")).Returns(outStudent);
			mock.Setup(x => x.Delete(null)).Throws<ArgumentNullException>();
		}

		[TestMethod()]
		public void AddTest()
		{
			inputStudent.GenerateGuid();
			var result = mockObject.Add(inputStudent);
			Assert.AreEqual(inputStudent, result);
		}
		[TestMethod]
		[ExpectedException(typeof(NullReferenceException))]
		public void AddNullTest()
		{
			var result = mockObject.Add(null);
		}

		[TestMethod()]
		public void GetByIdTest()
		{
			var result = mockObject.Update("1", inputStudent);
			Assert.AreEqual(inputStudent, result);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void GetByIdNullTest()
		{
			var result = mockObject.Update(null, inputStudent);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void UpdateNullTest()
		{
			var result = mockObject.Update(null, inputStudent);
		}


		[TestMethod()]
		public void DeleteTest()
		{
			var result = mockObject.Delete("1");
			Assert.AreEqual(inputStudent, result);
		}
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void DeleteNullTest()
		{
			var result = mockObject.Delete(null);
		}


	}
}