using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    public EventReference backgroundSound;
    public EventReference specialTime;

    private EventInstance musicInstance;

    public static AudioManager instance { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        if(instance!=null && instance!=this)
        {
            Destroy(this);
            return;
        }

        instance = this;
    }

    public void Start()
    {
        //play background sound -- not working?
        musicInstance = CreateEventInstance(backgroundSound);
        musicInstance.start();
    }
    
    public void PlayOneShot(EventReference sound, Vector3 position)
    {
        RuntimeManager.PlayOneShot(sound, position);
    }

    public EventInstance CreateEventInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        return eventInstance;
    }

    public void  changeMusic(EventReference eventReference){
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        musicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        musicInstance = eventInstance;
        musicInstance.start();
    }

    private void OnDestroy()
    {
        musicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        musicInstance.release();
    }
}
