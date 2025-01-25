using UnityEngine;
using UnityEngine.UI;

public enum RhythmScore 
{
    PERFECT,
    GOOD,
    MEDIOCRE,
    SKILLISSUE
}
public class RhythmManager : MonoBehaviour
{
    public static RhythmManager Instance { get; private set; }

    public float bpm = 88f;  // Beats per minute
    public float beatWindow = 0.2f;  // Timing window for rhythm
    private float beatInterval;  // Time between beats
    private float nextBeatTime;  // Time of next beat
    public RhythmScore inRhythm = RhythmScore.SKILLISSUE;

    private RhythmScore InRhythm => inRhythm;

    [SerializeField]    
    private Animator boomBoxAnimator;

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

        if (currentTime >= nextBeatTime - beatWindow*0.2f && currentTime <= nextBeatTime + beatWindow*0.2f)
        {
            inRhythm = RhythmScore.PERFECT;
            boomBoxAnimator.Play("BoomBoxBeat");
        }
        else if (currentTime >= nextBeatTime - beatWindow*0.7f && currentTime <= nextBeatTime + beatWindow*0.7f)
        {
            inRhythm = RhythmScore.GOOD;
            boomBoxAnimator.Play("BoomBoxBeat");
        }
        else if (currentTime >= nextBeatTime - beatWindow && currentTime <= nextBeatTime + beatWindow)
        {
            inRhythm = RhythmScore.MEDIOCRE;
            boomBoxAnimator.Play("BoomBoxBeat");
        }
        else
        {
            inRhythm = RhythmScore.SKILLISSUE;
            boomBoxAnimator.Play("BoomBoxIdle");
        }
        

        if (currentTime >= nextBeatTime)
        {
            nextBeatTime += beatInterval;
        }
    }
}