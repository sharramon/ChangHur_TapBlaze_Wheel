using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIActiveManager : MonoBehaviour
{
    public GameObject wheel;
    public GameObject spinButton;
    public GameObject claimButton;
    public GameObject rewardSprite;

    private void Awake()
    {
        StateManager.OnGameStateChanged += OnStateChanged;
        claimButton.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnStateChanged(GameState state) {
        if (state == GameState.Spin)
        {
            spinButton.gameObject.SetActive(false);
        }
        else if (state == GameState.Reward)
        {
            wheel.gameObject.SetActive(false);
            claimButton.gameObject.SetActive(true);
        }
        else if (state == GameState.Main)
        {
            claimButton.gameObject.SetActive(false);
            rewardSprite.gameObject.SetActive(false);
            wheel.gameObject.SetActive(true);
            spinButton.gameObject.SetActive(true);
        }
    }
}
