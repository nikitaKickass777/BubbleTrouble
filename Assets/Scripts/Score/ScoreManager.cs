using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int maximumScore = 100;
    public static ScoreManager instance { get; private set; }
    // Start is called before the first frame update
    void Awake(){
        if(instance!=null && instance!=this){
            Destroy(this);
            return;
        }

        instance = this;
    }

    public void IncrementScore(RhythmScore grade)
    {
        switch(grade)
        {
            case RhythmScore.PERFECT:
                score +=3;
                break;
            case RhythmScore.GOOD:
                score +=2;
                break;
            case RhythmScore.MEDIOCRE:
                score +=1;
                break;
            default:
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Debug.LogFormat($"Your score is:{score}"); 
    }


}
