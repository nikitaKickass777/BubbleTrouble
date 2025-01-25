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
        currentScore = maximum;
        calculateFillAmount();
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        decrementingTimer -= Time.deltaTime;
        if(decrementingTimer <= 0){
            decrementingTimer = decrementingTimerConst;
            currentScore -= 1;
            ScoreManager.instance.score = currentScore;
            calculateFillAmount();
        }
    }

    public void calculateFillAmount(){
        fillAmount = (float) currentScore / (float) maximum;
        mask.fillAmount = fillAmount;
    }
}
