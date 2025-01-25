using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private EventInstance backgroundSound;
    public static GameManager instance { get; private set; }
    // Start is called before the first frame update
    void Awake(){
        if(instance!=null && instance!=this){
            Destroy(this);
            return;
        }

        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //play background sound -- not working?
        //backgroundSound = AudioManager.instance.CreateEventInstance(backgroundSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
