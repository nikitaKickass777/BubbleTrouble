using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void IncrementScore(int increment)
    {
        score += increment;
        Debug.Log("Score: " + score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
