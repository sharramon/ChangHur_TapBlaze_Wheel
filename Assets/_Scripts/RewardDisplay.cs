using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//A class that takes info from the Reward scriptable object and uses the information to create the icons
//on the wheel
public class RewardDisplay : MonoBehaviour
{
    public GameObject rewardManager;

    public Reward reward;

    public TMP_Text rewardNumber;
    public TMP_Text rewardText;
    public Image rewardSprite;

    private void Awake()
    {
        rewardManager = GameObject.Find("RewardManager");
    }
    //Update all the sprites on start
    void Start()
    {
        UpdateSprite();
    }

    //simple method to update the sprite on call
    public void UpdateSprite()
    {
        rewardNumber.text = reward.rewardAmount;
        rewardText.text = reward.rewardTextline;
        rewardSprite.sprite = reward.rewardSprite;
    }

    //a method to pull the right reward info from the reward manager
    public void GetSprite(int id)
    {
        List<Reward> rewardList = rewardManager.GetComponent<GottenReward>().Rewards;
        reward = rewardList[id];
        Debug.Log("the reward id is " + id + " and the reward is " + reward);
        UpdateSprite();
    }
}
