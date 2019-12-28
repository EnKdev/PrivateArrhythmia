namespace PrivateArrhythmia.Backend
{
	public class Versioning
	{
		public static string AppVersion = "1.0.2";
		private static string AppAbbreviation = "PA";
		private static string AppVersionNumber = "102";
		private static string BuildRevisionFull = "2812192125";
		private static string BuildRevisionAbbr = "281219";

		private static char FullVerSeparator = '_';
		private static char AbbrVerSeparator = ':';
		private static char Joiner = '+';

		public static string FullVersionString =
			AppVersion + Joiner + BuildRevisionFull +
			FullVerSeparator + AppAbbreviation + FullVerSeparator +
			AppVersionNumber;

		public static string AbbrVersionString =
			AppVersion + Joiner + BuildRevisionAbbr +
			AbbrVerSeparator + AppAbbreviation + AbbrVerSeparator +
			AppVersionNumber;
	}
}