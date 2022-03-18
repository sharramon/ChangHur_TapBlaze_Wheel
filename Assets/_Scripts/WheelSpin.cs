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
        Debug.Log("running coroutine");
        startSpin = false;

        int stopAngle = GetStopAngle();
        var time = 0f;
        var spinSpeed = 3f;
        while (time < 3f)
        {
            transform.Rotate(0, 0, spinSpeed);
            time += Time.deltaTime;
            yield return null;
        }
        while (Mathf.Abs(transform.localEulerAngles.z - stopAngle) > 2)
        {
            transform.Rotate(0, 0, spinSpeed - 1f);
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);
        ShowRewardSprite();
        StateManager.Instance.UpdateGameState(GameState.Reward);
        yield return null;
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
        rewardSprite.GetComponent<RewardDisplay>().GetSprite(id);
    }

}
