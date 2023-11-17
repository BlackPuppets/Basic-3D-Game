using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T> where T : System.Enum
{

    public Dictionary<T, StateBase> dictionaryStates;

    private StateBase _currentState;
    public float timeToStartGame = 1f;

    public StateBase currentState { get { return _currentState; } }

    public StateMachine(T state)
    {
        //SwitchState(state);
    }

    public void Init()
    {
        dictionaryStates = new Dictionary<T, StateBase>();
    }

    public void RegisterStates(T type)
    {
        dictionaryStates.Add(type, new StateBase());
    }

    public void SwitchState(T state)
    {
        if (_currentState != null)
            _currentState.OnStateExit();

        _currentState = dictionaryStates[state];

        _currentState.OnStateEnter();
    }

    private void Update()
    {
        if(_currentState != null)
            _currentState.OnStateStay();
    }
}
