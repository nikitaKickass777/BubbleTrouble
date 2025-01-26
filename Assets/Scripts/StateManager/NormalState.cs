using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : AbstractState
{
    public float timer = 0f;
    public override void EnterState(StateMachine stateMachine)
    {
        timer = stateMachine.amountOfTimeTillBonusTime;
        RhythmManager.Instance.bpm = 88;
        stateMachine.disableLights();
        stateMachine.BossBattleText.SetActive(false);
        RhythmManager.Instance.maxBubbles = 7;
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
            stateMachine.currentstate = stateMachine.bossFightState;
            stateMachine.currentstate.EnterState(stateMachine);
        }

        Debug.Log(Time.time);
    }
}
