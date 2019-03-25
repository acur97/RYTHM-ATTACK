using UnityEngine;
using System.Collections;
using SynchronizerData;

public class BeatCounter : MonoBehaviour {
	
	public BeatValue beatValue = BeatValue.QuarterBeat;
	public int beatScalar = 1;
	public BeatValue beatOffset = BeatValue.None;
	public bool negativeBeatOffset = false;
	public BeatType beatType = BeatType.OnBeat;
	public float loopTime = 30f;
	public AudioSource audioSource;
	public GameObject[] observers;
	
	private float nextBeatSample;
	private float samplePeriod;
	private float sampleOffset;
	private float currentSample;

	
	void Awake ()
	{
		// Calculate number of samples between each beat.
		float audioBpm = audioSource.GetComponent<BeatSynchronizer>().bpm;
		samplePeriod = (60f / (audioBpm * BeatDecimalValues.values[(int)beatValue])) * audioSource.clip.frequency;

		if (beatOffset != BeatValue.None) {
			sampleOffset = (60f / (audioBpm * BeatDecimalValues.values[(int)beatOffset])) * audioSource.clip.frequency;
			if (negativeBeatOffset) {
				sampleOffset = samplePeriod - sampleOffset;
			}
		}

		samplePeriod *= beatScalar;
		sampleOffset *= beatScalar;
		nextBeatSample = 0f;
	}

	void StartBeatCheck (double syncTime)
	{
		nextBeatSample = (float)syncTime * audioSource.clip.frequency;
		StartCoroutine(BeatCheck());
	}
	
	void OnEnable ()
	{
		BeatSynchronizer.OnAudioStart += StartBeatCheck;
	}

	void OnDisable ()
	{
		BeatSynchronizer.OnAudioStart -= StartBeatCheck;
	}
    
	IEnumerator BeatCheck ()
	{
		while (audioSource.isPlaying) {
			currentSample = (float)AudioSettings.dspTime * audioSource.clip.frequency;
			
			if (currentSample >= (nextBeatSample + sampleOffset)) {
                Debug.Log("Beat!");
				nextBeatSample += samplePeriod;
			}

			yield return new WaitForSeconds(loopTime / 1000f);
		}
	}

}
