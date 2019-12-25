using System.IO;
using System.Windows.Forms;

namespace PrivateArrhythmia.Backend
{
	public class LevelArtHelper
	{
		public string GetLevelArtFile(string destination)
		{
			string levelArtFile = "";

			if (destination == "")
				MessageBox.Show("Please specify a location where your level resides at.", "Error", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			else if (!File.Exists($"{destination}/level.jpg"))
				levelArtFile = $"./Img/paheart.png";
			else
				levelArtFile = $"{destination}/level.jpg";

			return levelArtFile;
		}
	}
}