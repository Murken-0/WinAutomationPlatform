using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steps.Other
{
	public interface IScript
	{
		public void Perform(DesktopSession desktopSession);
	}
}
