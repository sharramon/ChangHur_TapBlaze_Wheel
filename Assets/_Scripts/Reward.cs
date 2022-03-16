using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//A scriptable object with the information needed to create the icons on the wheel.
//Later used by the RewardDisplay class to create the icons
[CreateAssetMenu(fileName = "New Reward", menuName = "Reward")]
public class Reward : ScriptableObject
{
    public string rewardName;
    public string rewardAmount;
    public string rewardTextline;
    public Sprite rewardSprite;
}
