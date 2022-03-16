using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WheelSpin : MonoBehaviour
{
    public bool startSpin;
    public int id;
    public int max;
    public GameObject rewardSprite;
    // Start is called before the first frame update
    private void Awake()
    {
        //currently hard coded to 8, but a method can be added later to make this more flexible
        max = 8;
    }
    void Start()
    {
        startSpin = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(startSpin)
        {
            StartCoroutine(SpinCoroutine());
        }
    }

    IEnumerator SpinCoroutine()
    {
        int stopAngle = GetStopAngle();
        transform.Rotate(0, 0, 3f);
        yield return new WaitForSeconds(3f);
        while (Mathf.Abs(transform.localEulerAngles.z - stopAngle) > 2)
        {
            yield return null;
        }
        startSpin = false;
        yield return new WaitForSeconds(0.5f);
        ShowRewardSprite();
        StateManager.Instance.UpdateGameState(GameState.Reward);
    }
    //use the number of sections to figure out how much rot each section requires
    //then use the id to pinpoint where the wheel needs to stop
    public int GetStopAngle()
    {
        int singleSlice = Mathf.RoundToInt(360 / max);
        int midSlice = Mathf.RoundToInt(singleSlice / 2);
        int stopAngle = id * singleSlice + midSlice;
        return stopAngle;
    }

    public void ShowRewardSprite()
    {
        rewardSprite.gameObject.SetActive(true);
        rewardSprite.GetComponent<WonRewardDisplay>().GetSprite(id);
    }

}
