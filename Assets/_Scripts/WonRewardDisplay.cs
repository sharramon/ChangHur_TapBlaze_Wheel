using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WonRewardDisplay : MonoBehaviour
{
    public GameObject rewardManager;

    public Reward reward;

    public TMP_Text rewardNumber;
    public TMP_Text rewardText;
    public Image rewardSprite;

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
