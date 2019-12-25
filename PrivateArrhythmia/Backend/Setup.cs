using System;
using Newtonsoft.Json;

namespace PrivateArrhythmia.Backend
{
	public class Setup
	{
		[JsonProperty("paVerFull")]
		public string PaVerFull { get; set; }

		[JsonProperty("paVerAbbr")]
		public string PaVerAbbr { get; set; }

		[JsonProperty("workshopLocation")]
		public string WorkshopLocation { get; set; }

		[JsonProperty("setupCreated")]
		public DateTime SetupCreated { get; set; }
	}
}