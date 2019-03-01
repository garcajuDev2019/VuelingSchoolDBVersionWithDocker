using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingSchool.Common.Library.Models;
using VuelingSchool.Common.Library.Utils;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;


namespace VuelingSchool.Common.Library.Factory
{
	public class FileManagerFactory: AbstractDataManagerFactory
	{
		private static readonly log4net.ILog log
			= log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		public override AbstractFileManager CreateFileManager(string typeOfFileManager)
		{
			var myAssembly = GetAssembly();
			
			XElement root = XElement.Load("RepositoryConfiguration.xml");
			IEnumerable<XElement> repository =
				from element in root.Elements("Type")
				where (string)element.Attribute("Id") == typeOfFileManager 
				select element;

			var fileType = repository.First().Element("class").Value;

			Type newFileManager = myAssembly.GetType(fileType);
			AbstractFileManager instance;

			try
			{
				instance = (AbstractFileManager)Activator.CreateInstance(newFileManager);

			}
			catch (ArgumentNullException e)
			{
				log.Warn(e.Message); // return also e.StackTrace
				throw;
			}
			catch (ArgumentException e)
			{
				log.Warn(e.Message);
				throw;
			}
			catch (TargetException e)
			{
				log.Warn(e.Message);
				throw;
			}
			catch (TargetInvocationException e)
			{
				log.Warn(e.Message);
				throw;
			}
			// Old way to implement the abstract factory
			//	remains here for documentation
			/*
			switch (typeOfFileManager)
			{
				case "JSON":
					return new JSONRepository();
					break;
				case "XML":
					return new XMLRepository();
					break;
				case "TXT":
				default:
					return new TXTRepository();
					break;
			}
			*/

			return instance;
		}

		public Assembly GetAssembly()
		{
			Assembly myAssembly = typeof(FileManagerFactory).Assembly;
			return myAssembly;
		}
	}
}
