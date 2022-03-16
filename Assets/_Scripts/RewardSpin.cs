using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSpin : MonoBehaviour
{
    public GameObject SpinningWheel;
    public RewardDecideNM rewardDecide;
    //subscribe RewardDecide to the state change of the StateManager singleton
    private void Awake()
    {
        StateManager.OnGameStateChanged += OnStateChanged;
        rewardDecide = new RewardDecideNM();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //only act if the state has changed to spin
    private void OnStateChanged(GameState state)
    {
        if (state == GameState.Spin)
        {
            SpinWheel();
        }
    }

    private void SpinWheel()
    {
        int id = rewardDecide.CalculateReward();
        //gives the WheelSpin the reward id and sets boolean to true to start the animation
        SpinningWheel.GetComponent<WheelSpin>().id = id;
        SpinningWheel.GetComponent<WheelSpin>().startSpin = true;
    }
}
