using System;
using System.IO;
using Newtonsoft.Json;
using PrivateArrhythmia.Backend.Lsb;

namespace PrivateArrhythmia.Backend
{
	public class LsbReader
	{
		// Fields
		public string MA_Name = "";
		public string MA_Link = "";
		public long MA_LinkType = 0;

		public string MC_SteamName = "";
		public string MC_SteamId = "";

		public string MS_Title = "";
		public string MS_Difficulty = "";
		public string MS_Description = "";
		public string MS_Bpm = "";
		public string MS_T = "";
		public string MS_PreviewStart = "";
		public string MS_PreviewLength = "";

		public string MB_DateEdited = "";
		public string MB_VersionNumber = "";
		public string MB_GameVersion = "";
		public string MB_WorkshopId = "";

		public void ReadMetadataFile(string location)
		{
			if (!File.Exists($"{location}/metadata.lsb"))
			{
				Console.WriteLine($"metadata.lsb not found at location: {location}");
				return;
			}
			else
			{
				var fileText = File.ReadAllText(location + "/metadata.lsb");
				var metadata = JsonConvert.DeserializeObject<Metadata>(fileText);
				var artist = metadata.Artist;
				var creator = metadata.Creator;
				var song = metadata.Song;
				var beatmap = metadata.Beatmap;

				MA_Name = artist.Name;
				MA_Link = artist.Link;
				MA_LinkType = artist.LinkType;

				MC_SteamName = creator.SteamName;
				MC_SteamId = creator.SteamId;

				MS_Title = song.Title;
				MS_Difficulty = song.Difficulty;
				MS_Description = song.Description;
				MS_Bpm = song.Bpm;
				MS_T = song.T;
				MS_PreviewStart = song.PreviewStart;
				MS_PreviewLength = song.PreviewLength;

				MB_DateEdited = beatmap.DateEdited;
				MB_VersionNumber = beatmap.VersionNumber;
				MB_GameVersion = beatmap.GameVersion;

				if (beatmap.WorkshopId == "-1")
					MB_WorkshopId = "Not uploaded";
				else
					MB_WorkshopId = beatmap.WorkshopId;
			}
		}

		public void DisposeLsbReader()
		{
			MA_Name = "";
			MA_Link = "";
			MA_LinkType = 0;

			MC_SteamName = "";
			MC_SteamId = "";

			MS_Title = "";
			MS_Difficulty = "";
			MS_Description = "";
			MS_Bpm = "";
			MS_T = "";
			MS_PreviewStart = "";
			MS_PreviewLength = "";

			MB_DateEdited = "";
			MB_VersionNumber = "";
			MB_GameVersion = "";
			MB_WorkshopId = "";
		}
	}
}