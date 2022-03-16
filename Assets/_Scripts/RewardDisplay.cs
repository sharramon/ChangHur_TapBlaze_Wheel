using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//A class that takes info from the Reward scriptable object and uses the information to create the icons
//on the wheel
public class RewardDisplay : MonoBehaviour
{

    public Reward reward;

    public TMP_Text rewardNumber;
    public TMP_Text rewardText;
    public Image rewardSprite;

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
}
