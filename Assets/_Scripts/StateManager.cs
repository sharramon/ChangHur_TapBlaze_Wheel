using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static StateManager Instance;

    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        UpdateGameState(GameState.Main);
    }


    void Update()
    {
        
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.Main:
                HandleMain();
                break;
            case GameState.Spin:
                HandleSpin();
                break;
            case GameState.Reward:
                HandleReward();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleMain()
    {

    }

    private void HandleSpin()
    {

    }

    private void HandleReward()
    {

    }

    public void SpinButtonPress()
    {
        UpdateGameState(GameState.Spin);
        Debug.Log("Spin button was pressed and the state is now " + State) ;
    }

    public void ClaimButtonPress()
    {
        UpdateGameState(GameState.Main);
    }
}

public enum GameState
{
    Main,
    Spin,
    Reward
}

