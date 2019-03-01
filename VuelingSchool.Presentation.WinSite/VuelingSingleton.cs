using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VuelingSchool.Presentation.WinSite
{

	// patron de instancia unica

	// con  'sealed' evitamos que nadie herede e instancie la clase

	/// <summary>
	/// Implements Singleton pattern using the CLR to manage static fields
	/// </summary>
	sealed class VuelingSingleton
	{
		private static readonly log4net.ILog log
		  = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


		public readonly static string provinciasPath = ConfigurationSettings.AppSettings["provinciasPath"];


		// Para el singleton necesitamos tener una instancia privada estatica de la clase
		private static volatile VuelingSingleton instance = null;

		// Tambien un objeto que gestionara los bloqueos. Evitar que dos threads entren en el singleton a la vez
		private static readonly object lockerObject = new object();

		// Haciendo el constructor privado. Aseguramos que solo se pueda invocar con la instance: nombreclase.instance.nombreobjeto;
		private VuelingSingleton() { }


		/// <summary>
		/// VuelingSingleton implements singleton double check
		/// </summary>
		public static VuelingSingleton Instance
		{
			get
			{
				if (instance == null)
				{
					lock (lockerObject)
					{
						if (instance == null)
							instance = new VuelingSingleton();
					}
				}

				return instance;
			}
		}

		/// <summary>
		/// Loads the content of an XML with the spanish provinces
		/// </summary>
		/// <returns>List<string> with the spanish provinces</returns>
		public List<string> SelectStates()
		{
			List<string> list;
			try
			{
				XDocument xmlRoot = XDocument.Load(provinciasPath);
				list = xmlRoot.Descendants("Provinces")
							.Select(prov => prov.Value)
							.ToList();
			}
			catch (ArgumentNullException e)
			{
				log.Error(e.Message);
				log.Info(e.StackTrace);
				throw;
			}
			return list;
		}
	}


	// con  'sealed' evitamos que nadie herede e instancie la clase
	sealed class VuelingSingleton2
	{
		private static readonly log4net.ILog log
		  = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


		public readonly static string provinciasPath = ConfigurationSettings.AppSettings["provinciasPath"];


		private static VuelingSingleton2 instance = new VuelingSingleton2();

		private VuelingSingleton2()
		{
		}

		/// <summary>
		/// Compact version of Singleton pattern. Works on multithread environments
		/// <para>Returns only one instance of VuelingSingleton to show all spanish provinces</para>
		/// </summary>
		/// <returns>Instance of VuelingSingleton</returns>
		public static VuelingSingleton2 getInstance()
		{
			return instance;
		}

		/// <summary>
		/// Loads the content of an XML with the spanish provinces
		/// </summary>
		/// <returns>List<string> with the spanish provinces</returns>
		public List<string> SelectStates()
		{
			List<string> list;
			try
			{
				XDocument xmlRoot = XDocument.Load(provinciasPath);
				list = xmlRoot.Descendants("Provinces")
							.Select(prov => prov.Value)
							.ToList();
			}
			catch (ArgumentNullException e)
			{
				log.Error(e.Message);
				log.Info(e.StackTrace);
				throw;
			}
			return list;
		}
	}
}
