using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace ETTrans
{
	static class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			string initialFile = null;
			if ((args != null) && (args.Length > 0))
			{
				initialFile = args[0];
			}
			Application.Run(new frmMain(initialFile));
		}
	}
}