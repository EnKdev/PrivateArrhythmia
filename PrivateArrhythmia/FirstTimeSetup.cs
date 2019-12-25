using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using PrivateArrhythmia.Backend;

namespace PrivateArrhythmia
{
	public partial class FirstTimeSetup : Form
	{
		public static string PaWorkshopLocation = "";
		public static DateTime SetupCreationTime = new DateTime();
		public static string PaVerFull = "";
		public static string PaVerAbbr = "";

		public FirstTimeSetup()
		{
			InitializeComponent();
		}

		private void buttonConfirm_Click(object sender, EventArgs e)
		{
			PaWorkshopLocation = Convert.ToString(waterMarkTextBoxWorkshopLocation.Text);
			SetupCreationTime = DateTime.Now;
			PaVerFull = Versioning.FullVersionString;
			PaVerAbbr = Versioning.AbbrVersionString;

			Program.PaWorkshopLocation = PaWorkshopLocation;
			Program.SetupCreationTime = SetupCreationTime;

			Setup setup = new Setup
			{
				PaVerFull = PaVerFull,
				PaVerAbbr = PaVerAbbr,
				SetupCreated = SetupCreationTime,
				WorkshopLocation = PaWorkshopLocation
			};

			if (!Directory.Exists($"./config"))
				Directory.CreateDirectory($"./config");

			using (StreamWriter sw = File.CreateText($"./config/setup.pa"))
			{
				var fileText = JsonConvert.SerializeObject(setup, Formatting.Indented);
				sw.WriteAsync(fileText);
			}

			Close();
		}
	}
}
