using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public int maximum;
    public int currentScore;
    public Image mask;
    float fillAmount;
    private float decrementingTimer = 5f;
    public float decrementingTimerConst = 5f;
    // Start is called before the first frame update
    void Start()
    {
        maximum = ScoreManager.instance.maximumScore;
        ScoreManager.instance.score = maximum;
        currentScore = maximum;
        calculateFillAmount();
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        decrementingTimer -= Time.deltaTime;
        if(decrementingTimer <= 0){
            decrementingTimer = decrementingTimerConst;
            ScoreManager.instance.score -= 3;
            this.currentScore = ScoreManager.instance.score;
        }
        calculateFillAmount();
    }

    public void calculateFillAmount(){
        currentScore = ScoreManager.instance.score;
        if(currentScore > maximum){
            currentScore = maximum;
        }
        fillAmount = (float) currentScore / (float) maximum;
        mask.fillAmount = fillAmount;
    }
}
