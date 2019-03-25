using System.Collections;

namespace SynchronizerData
{
	public enum BeatValue {
		None,
		SixteenthBeat,
		SixteenthDottedBeat,
		EighthBeat,
		EighthDottedBeat,
		QuarterBeat,
		QuarterDottedBeat,
		HalfBeat,
		HalfDottedBeat,
		WholeBeat,
		WholeDottedBeat
	}
    
	public enum BeatType {
		None		= 0,
		OffBeat		= 1,
		OnBeat		= 2,
		UpBeat		= 4,
		DownBeat	= 8
	};
    
	public struct BeatDecimalValues {
		private static float dottedBeatModifier = 1.5f;
		public static float[] values = {
			0f,
			4f, 4f/dottedBeatModifier,			// sixteenth, dotted sixteenth
			2f, 2f/dottedBeatModifier,			// eighth, dotted eighth
			1f, 1f/dottedBeatModifier,			// quarter, dotted quarter
			0.5f, 0.5f/dottedBeatModifier,		// half, dotted half
			0.25f, 0.25f/dottedBeatModifier		// whole, dotted whole
		};
	}

}
