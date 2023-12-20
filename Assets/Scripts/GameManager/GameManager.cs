using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Singleton;

public class GameManager : Singleton<GameManager>
{
    public enum GameStates { 
        INTRO,
        GAMEPLAY,
        PAUSE,
        WIN,
        LOSE
    }

    public StateMachine<GameStates> stateMachine;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        stateMachine = new StateMachine<GameStates>(GameStates.INTRO);
        stateMachine.Init();
        stateMachine.RegisterStates(GameStates.INTRO);
        stateMachine.RegisterStates(GameStates.GAMEPLAY);
        stateMachine.RegisterStates(GameStates.PAUSE);
        stateMachine.RegisterStates(GameStates.WIN);
        stateMachine.RegisterStates(GameStates.LOSE);
    }


}
