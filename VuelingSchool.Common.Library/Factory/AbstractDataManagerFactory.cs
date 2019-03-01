using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingSchool.Common.Library.Utils;

namespace VuelingSchool.Common.Library.Factory
{
	public abstract class AbstractDataManagerFactory
	{
		public abstract AbstractFileManager CreateFileManager(string typeOfFileManager);
	}
}
