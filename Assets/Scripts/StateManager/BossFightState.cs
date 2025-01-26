using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightState : AbstractState
{
    public float timer = 3f;

    public override void EnterState(StateMachine stateMachine)
    {
        stateMachine.BossBattleText.SetActive(true);
        enableLights(stateMachine);
        AudioManager.instance.changeMusic(AudioManager.instance.specialTime);
        RhythmManager.Instance.bpm = 140;
        RhythmManager.Instance.maxBubbles = 25;
        timer = stateMachine.timeInSpecialTime;
        Debug.Log("entered special state");
    }

    public override void OnCollisionEnter(StateMachine stateMachine)
    {
    }

    public override void UpdateState(StateMachine stateMachine)
    {
        if(stateMachine.PlayerWon){
            stateMachine.currentstate = stateMachine.winState;
            stateMachine.currentstate.EnterState(stateMachine);
        }

        if(ScoreManager.instance.score <= 0){
            stateMachine.currentstate = stateMachine.loseState;
            stateMachine.currentstate.EnterState(stateMachine);
        }

        timer -= 0.1f;
        if(timer <= 0){
            AudioManager.instance.changeMusic(AudioManager.instance.backgroundSound);
            stateMachine.currentstate = stateMachine.normalState;
            stateMachine.currentstate.EnterState(stateMachine);
        }

    }

    void enableLights(StateMachine machine){
        foreach(var light in machine.lights){
            light.SetActive(true);
        }
    }
}
