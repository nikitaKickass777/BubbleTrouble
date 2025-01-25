using UnityEngine;
using UnityEngine.UI;

public class RhythmManager : MonoBehaviour
{
    public static RhythmManager Instance { get; private set; }

    public float bpm = 88f;  // Beats per minute
    public float beatWindow = 0.2f;  // Timing window for rhythm
    private float beatInterval;  // Time between beats
    private float nextBeatTime;  // Time of next beat
    private bool inRhythm = false;

    public bool InRhythm => inRhythm;
    public Image rhythmIndicator;  // Assign this in the Inspector

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        beatInterval = 60f / bpm;
        nextBeatTime = Time.time + beatInterval;
    }

    private void Update()
    {
        float currentTime = Time.time;

        if (currentTime >= nextBeatTime - beatWindow && currentTime <= nextBeatTime + beatWindow)
        {
            inRhythm = true;
            if (rhythmIndicator) rhythmIndicator.color = Color.green;
        }
        else
        {
            inRhythm = false;
            if (rhythmIndicator) rhythmIndicator.color = Color.red;
        }

        if (currentTime >= nextBeatTime)
        {
            nextBeatTime += beatInterval;
        }
    }
}