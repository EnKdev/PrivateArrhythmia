namespace PrivateArrhythmia.Backend
{
	public class Versioning
	{
		public static string AppVersion = "1.1.0";
		private static string AppAbbreviation = "PA";
		private static string AppVersionNumber = "110";
		private static string BuildRevisionFull = "2101201913";
		private static string BuildRevisionAbbr = "210120";

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