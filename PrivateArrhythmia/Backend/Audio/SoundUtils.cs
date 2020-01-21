using System;
using System.Drawing;
using NVorbis;

namespace PrivateArrhythmia.Backend.Audio
{
	public static class SoundUtils
	{
		public static string GetOggFileInfo(string filename)
		{
			string fileInfo;

			using (var ogg = new VorbisReader(filename))
			{
				var channels = ogg.Channels;
				var sampleRate = ogg.SampleRate;
				var totalTime = ogg.TotalTime;

				fileInfo =
					$"File: level.ogg | Channels: {channels} | Sample Rate: {sampleRate} | Duration: {totalTime}";
			}

			return fileInfo;
		}
	}
}