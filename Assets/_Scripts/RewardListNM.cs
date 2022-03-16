using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//create a list of rewards with identifiers
public static class RewardListNM
{
    //Reward class for creating instances
    public class Reward
    {
        public string prize;
        public int amount;
        public int rangeMin;
        public int rangeMax;
        public int id;
    }
    
    //A method that's simply a for loop that creates the list of rewards
    public static List<Reward> MakeList()
    {
        List<Reward> rewardList = new List<Reward>();
        //build the reward array from the static RewardArrayNM class
        string[,] reward2DArray = RewardArrayNM.getRewardArray();
        int height = reward2DArray.GetLength(0);
        int rangeMin = 0;

        //as it's uncertain if the precentages will always hold true, a range of
        //percentages for each prize is determined in this loop
        //For now, the type of data is hard coded in
        for (int i = 0; i < height; i++)
        {
            Reward reward = new Reward();
            reward.id = i;
            reward.prize = reward2DArray[i, 0];
            reward.amount = int.Parse(reward2DArray[i, 1]);
            reward.rangeMin = rangeMin;
            reward.rangeMax = rangeMin + int.Parse(reward2DArray[i, 2]);
            rangeMin = reward.rangeMax;
            rewardList.Add(reward);
        }

        return rewardList;
    }
}
