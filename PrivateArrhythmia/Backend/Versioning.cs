namespace PrivateArrhythmia.Backend
{
	public class Versioning
	{
		public static string AppVersion = "1.0.1";
		private static string AppAbbreviation = "PA";
		private static string AppVersionNumber = "101";
		private static string BuildRevisionFull = "2612191941";
		private static string BuildRevisionAbbr = "261219";

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