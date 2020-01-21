using System.IO;
using System.Windows.Forms;

namespace PrivateArrhythmia.Backend
{
	public class LevelSongHelper
	{
		public string GetLevelSongFile(string destination)
		{
			string levelSongFile = "";

			if (destination == "")
				MessageBox.Show("Please specify a location where your level resides at.",
					"Error",
					MessageBoxButtons.OK);
			else if (!File.Exists($"{destination}/level.ogg"))
				MessageBox.Show("Can't find the level.ogg file. Are you sure this is the right location?",
					"Error",
					MessageBoxButtons.OK);
			else
				levelSongFile = $"{destination}/level.ogg";

			return levelSongFile;
		}
	}
}