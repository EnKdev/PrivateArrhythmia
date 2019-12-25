using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using PrivateArrhythmia.Backend;

namespace PrivateArrhythmia
{
	static class Program
	{
		// Fields
		public static string PaWorkshopLocation = "";
		public static DateTime SetupCreationTime = new DateTime();
		public static string PaVerFull = "";
		public static string PaVerAbbr = "";
		private static bool setupExists;

		// Forms
		private static MainForm mf = new MainForm();
		private static FirstTimeSetup fts = new FirstTimeSetup();

		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.ThreadException +=
				new ThreadExceptionEventHandler(new ThreadExceptionHandler().ApplicationThreadException);
			Application.EnableVisualStyles();

			setupExists = CheckForExistingSetup();

			if (setupExists == false)
				Application.Run(new FirstTimeSetup());

			Application.Run(new MainForm());
		}

		private static bool CheckForExistingSetup()
		{
			if (!File.Exists($"./config/setup.pa"))
				return false;

			var fileSetupText = File.ReadAllText($"./config/setup.pa");
			var setup = JsonConvert.DeserializeObject<Setup>(fileSetupText);
			PaWorkshopLocation = setup.WorkshopLocation;
			SetupCreationTime = setup.SetupCreated;
			PaVerFull = setup.PaVerFull;
			PaVerAbbr = setup.PaVerAbbr;

			return true;
		}
	}

	public class ThreadExceptionHandler
	{
		public void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
		{
		}
	}
}
