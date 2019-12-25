using System;
using System.IO;
using System.Windows.Forms;
using Ionic.Zip;
using PrivateArrhythmia.Backend;

namespace PrivateArrhythmia
{
	public partial class MainForm : Form
	{
		public static string PaWorkshopLocation = "";
		public static DateTime SetupCreationTime = new DateTime();
		public static string PaVerFull = "";
		public static string PaVerAbbr = "";

		private LsbReader lr = new LsbReader();
		private LevelArtHelper lah = new LevelArtHelper();
		private LsbWriter lw = new LsbWriter();

		public MainForm()
		{
			InitializeComponent();
			logTextBox.AppendText("Initializing Private Arrhythmia V" + Versioning.AppVersion + "\n");
			PaWorkshopLocation = Program.PaWorkshopLocation;
			SetupCreationTime = Program.SetupCreationTime;
			labelWorkshop.Text = "Workshop Location: " + PaWorkshopLocation;
			labelCreation.Text = "Setup Created: " + SetupCreationTime;
			logTextBox.AppendText("Initialized Private Arrhythmia V" + Versioning.AppVersion + "\n");
		}

		private void buttonLoadLevel_Click(object sender, EventArgs e)
		{
			logTextBox.AppendText("Loading editor level...\n");

			string levelArtLocation = lah.GetLevelArtFile(waterMarkTextBoxSrcLevel.Text);

			lr.ReadMetadataFile(waterMarkTextBoxSrcLevel.Text);

			pictureBoxSrcLvlArt.Load(levelArtLocation);

			labelSrcLocation.Text = waterMarkTextBoxSrcLevel.Text;

			labelArtistName.Text = lr.MA_Name;
			labelArtistLink.Text = lr.MA_Link;
			labelArtistLinkType.Text = lr.MA_LinkType.ToString();

			labelSteamName.Text = lr.MC_SteamName;
			labelSteamId.Text = lr.MC_SteamId;

			labelSongTitle.Text = lr.MS_Title;
			labelDiff.Text = lr.MS_Difficulty;
			labelBpm.Text = lr.MS_Bpm;

			labelDateEdit.Text = lr.MB_DateEdited;
			labelLvlVersion.Text = lr.MB_VersionNumber;
			labelGameVersion.Text = lr.MB_GameVersion;
			labelWorkshopId.Text = lr.MB_WorkshopId;

			logTextBox.AppendText("Editor level loaded\n");
		}

		private void buttonTransferLvl_Click(object sender, EventArgs e)
		{
			logTextBox.AppendText("Trying to transfer editor level to target location...\n");

			pictureBoxTargetLvlArt.Dispose();

			if (waterMarkTextBoxTargetLvl.Text == "")
				MessageBox.Show("Can't transfer level to non-existant target location", "Error", MessageBoxButtons.OK,
					MessageBoxIcon.Error);

			using (var zip = new ZipFile())
			{
				zip.AddDirectory($"{waterMarkTextBoxSrcLevel.Text}");
				zip.Save($"PrivateLevel_{labelSongTitle.Text}_{labelArtistName.Text}_{labelSteamName.Text}.zip");
			}

			File.Move($"PrivateLevel_{labelSongTitle.Text}_{labelArtistName.Text}_{labelSteamName.Text}.zip",
				$"{labelTargetLocation.Text}/PrivateLevel_{labelSongTitle.Text}_{labelArtistName.Text}_{labelSteamName.Text}.zip");

			File.Delete($"{labelTargetLocation.Text}/level.jpg");
			File.Delete($"{labelTargetLocation.Text}/level.lsb");
			File.Delete($"{labelTargetLocation.Text}/level.ogg");
			File.Delete($"{labelTargetLocation.Text}/metadata.lsb");

			ZipFile zip1 = ZipFile.Read($"{labelTargetLocation.Text}/PrivateLevel_{labelSongTitle.Text}_{labelArtistName.Text}_{labelSteamName.Text}.zip");

			foreach (ZipEntry ze in zip1)
				ze.Extract($"{labelTargetLocation.Text}", ExtractExistingFileAction.OverwriteSilently);

			zip1.Dispose();

			File.Delete($"{labelTargetLocation.Text}/metadata.lsb");
			WriteModifiedMetadataFile();
			lr.DisposeLsbReader();

			if (!Directory.Exists($"{PaWorkshopLocation}/ReadyToShare"))
				Directory.CreateDirectory($"{PaWorkshopLocation}/ReadyToShare");

			File.Move($"{labelTargetLocation.Text}/PrivateLevel_{labelSongTitle.Text}_{labelArtistName.Text}_{labelSteamName.Text}.zip", $"{PaWorkshopLocation}/ReadyToShare/PrivateLevel_{labelSongTitle.Text}_{labelArtistName.Text}_{labelSteamName.Text}.zip");

			logTextBox.AppendText($"Transfer complete. Sharable private level archive found in {PaWorkshopLocation}\\ReadyToShare\n");
		}

		private void buttonLoadLvlTarget_Click(object sender, EventArgs e)
		{
			logTextBox.AppendText("Loading workshop level...\n");

			string levelArtLocation = lah.GetLevelArtFile(waterMarkTextBoxTargetLvl.Text);

			lr.ReadMetadataFile(waterMarkTextBoxTargetLvl.Text);

			pictureBoxTargetLvlArt.Load(levelArtLocation);

			labelTargetLocation.Text = waterMarkTextBoxTargetLvl.Text;

			labelArtistNameTarget.Text = lr.MA_Name;
			labelArtistLinkTarget.Text = lr.MA_Link;
			labelArtistLinkTypeTarget.Text = lr.MA_LinkType.ToString();

			labelSteamNameTarget.Text = lr.MC_SteamName;
			labelSteamIdTarget.Text = lr.MC_SteamId;

			labelSongTarget.Text = lr.MS_Title;
			labelDiffTarget.Text = lr.MS_Difficulty;
			labelBpmTarget.Text = lr.MS_Bpm;

			labelEditDateTarget.Text = lr.MB_DateEdited;
			labelLvlVersionTarget.Text = lr.MB_VersionNumber;
			labelGameVersionTarget.Text = lr.MB_GameVersion;
			labelWorkshopIdTarget.Text = lr.MB_WorkshopId;

			logTextBox.AppendText("Workshop level loaded.\n");
		}

		private void buttonLvlBackup_Click(object sender, EventArgs e)
		{
			logTextBox.AppendText("Backing up workshop level\n");

			if (!Directory.Exists($"{PaWorkshopLocation}/Backup"))
				Directory.CreateDirectory($"{PaWorkshopLocation}/Backup");

			using (var zip = new ZipFile())
			{
				zip.AddDirectory($"{waterMarkTextBoxTargetLvl.Text}");
				zip.Save($"Backup_{labelWorkshopIdTarget.Text}_{labelSongTarget.Text}.zip");
			}

			File.Move($"./Backup_{labelWorkshopIdTarget.Text}_{labelSongTarget.Text}.zip",
				$"{PaWorkshopLocation}/Backup/Backup_{labelWorkshopIdTarget.Text}_{labelSongTarget.Text}.zip");

			File.Delete($"./Backup_{labelWorkshopIdTarget.Text}_{labelSongTarget.Text}.zip");

			logTextBox.AppendText($"Level backup successful. Backup located at: {PaWorkshopLocation}\\Backup\n");
		}

		private void WriteModifiedMetadataFile()
		{
			logTextBox.AppendText("Writing modified metadata.lsb file...\n");

			lw.PrepareMetaArtist(labelArtistName.Text, labelArtistLink.Text, Convert.ToInt64(labelArtistLinkType.Text));
			lw.PrepareMetaCreator(labelSteamName.Text, labelSteamId.Text);
			lw.PrepareMetaSong(labelSongTitle.Text, labelDiff.Text, lr.MS_Description, labelBpm.Text, lr.MS_T,
				lr.MS_PreviewStart, lr.MS_PreviewLength);
			lw.PrepareMetaBeatmap(labelDateEdit.Text, labelLvlVersion.Text, labelGameVersion.Text,
				labelWorkshopIdTarget.Text);
			lw.WriteLsb($"{labelTargetLocation.Text}");

			logTextBox.AppendText("Modified metadata.lsb file written\n");
		}

		private void logTextBox_TextChanged(object sender, EventArgs e)
		{
			logTextBox.SelectionStart = logTextBox.Text.Length;
			logTextBox.ScrollToCaret();
		}
	}
}
