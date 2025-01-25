using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }
    // Start is called before the first frame update
    void Awake(){
        if(instance!=null && instance!=this){
            Destroy(this);
            return;
        }

        instance = this;
    }
    
    public void PlayOneShot(EventReference sound, Vector3 position)
    {
        RuntimeManager.PlayOneShot(sound, position);
    }

    //TODO : add music playables
}
