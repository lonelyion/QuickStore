// QuickStore
// Blake Bolton
// 21 / 09 / 2012

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuickStore
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Main());
		}


	}
}
