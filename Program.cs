namespace BestBuy.Sniper.Client {

	#region Directives
	using System;
	using System.Windows.Forms;
	#endregion

	public class Program {

		[STAThread]
		static void Main() {
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new SniperManager());
		}

	}

}