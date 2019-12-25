using System;
using System.IO;
using Newtonsoft.Json;
using PrivateArrhythmia.Backend.Lsb;

namespace PrivateArrhythmia.Backend
{
	public class LsbWriter
	{
		private Metadata metadata;
		private MetaArtist ma;
		private MetaCreator mc;
		private MetaSong ms;
		private MetaBeatmap mb;

		public void WriteLsb(string destination)
		{
			metadata = new Metadata
			{
				Artist = ma,
				Creator = mc,
				Song = ms,
				Beatmap = mb
			};

			using (StreamWriter sw = File.CreateText($"{destination}/metadata.lsb"))
			{
				var fileText = JsonConvert.SerializeObject(metadata, Formatting.Indented);
				sw.WriteAsync(fileText);

				Console.WriteLine($"Wrote new metadata.lsb into {destination}");
			}

			FlushMetadata();
		}

		public void PrepareMetaArtist(string name, string link, long linkType)
		{
			ma = new MetaArtist
			{
				Name = name,
				Link = link,
				LinkType = linkType
			};
		}

		public void PrepareMetaCreator(string steamName, string steamId)
		{
			mc = new MetaCreator
			{
				SteamName = steamName,
				SteamId = steamId
			};
		}

		public void PrepareMetaSong(string title, string difficulty, string description, string bpm, string t,
			string prevStart, string prevLength)
		{
			ms = new MetaSong
			{
				Title = title,
				Difficulty = difficulty,
				Description = description,
				Bpm = bpm,
				T = t,
				PreviewStart = prevStart,
				PreviewLength = prevLength
			};
		}

		public void PrepareMetaBeatmap(string dateEdited, string versionNumber, string gameVersion, string workshopId)
		{
			mb = new MetaBeatmap
			{
				DateEdited = dateEdited,
				VersionNumber = versionNumber,
				GameVersion = gameVersion,
				WorkshopId = workshopId
			};
		}

		private void FlushMetadata()
		{
			metadata = null;
			ma = null;
			mc = null;
			ms = null;
			mb = null;
		}
	}
}