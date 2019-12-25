using Newtonsoft.Json;

namespace PrivateArrhythmia.Backend.Lsb
{
	public class Metadata
	{
		[JsonProperty("artist")]
		public MetaArtist Artist { get; set; }

		[JsonProperty("creator")]
		public MetaCreator Creator { get; set; }

		[JsonProperty("song")]
		public MetaSong Song { get; set; }

		[JsonProperty("beatmap")]
		public MetaBeatmap Beatmap { get; set; }
	}

	public class MetaArtist
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("link")]
		public string Link { get; set; }

		[JsonProperty("linkType")]
		public long LinkType { get; set; }
	}

	public class MetaCreator
	{
		[JsonProperty("steam_name")]
		public string SteamName { get; set; }

		[JsonProperty("steam_id")]
		public string SteamId { get; set; }
	}

	public class MetaSong
	{
		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("difficulty")]
		public string Difficulty { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("bpm")]
		public string Bpm { get; set; }

		[JsonProperty("t")]
		public string T { get; set; }

		[JsonProperty("preview_start")]
		public string PreviewStart { get; set; }

		[JsonProperty("preview_length")]
		public string PreviewLength { get; set; }
	}

	public class MetaBeatmap
	{
		[JsonProperty("date_edited")]
		public string DateEdited { get; set; }

		[JsonProperty("version_number")]
		public string VersionNumber { get; set; }

		[JsonProperty("game_version")]
		public string GameVersion { get; set; }

		[JsonProperty("workshop_id")]
		public string WorkshopId { get; set; }
	}
}