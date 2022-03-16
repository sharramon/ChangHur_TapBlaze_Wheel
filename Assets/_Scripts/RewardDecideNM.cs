using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardDecideNM
{
    public List<RewardListNM.Reward> rewardList = RewardListNM.MakeList();

    //main method of this class that calculates which reward to get and invokes
    //the spinning animation

    //method to calculate reward
    public int CalculateReward()
    {
        float seed = Random.Range(0, 100f);
        int id = Search(seed);
        //Debug.Log("The reward ID is " + id);
        return id;
    }

    //a simple for loop search method, since the n value is low
    public int Search(float seed)
    {
        //Debug.Log("the seed is " + seed);
        //if the random number is 100 even, just give them the last sector
        if (seed == 100)
        {
            return rewardList.Count - 1; 
        }
        //else find the range in which it fits
        else {
            for (int i = 0; i < rewardList.Count; i++)
            {
                RewardListNM.Reward tempReward = rewardList[i];
                //Debug.Log("min is " + tempReward.rangeMin + " and max is " + tempReward.rangeMax);
                if ((tempReward.rangeMin <= seed) && ( seed < tempReward.rangeMax))
                {
                    //Debug.Log("min is " + tempReward.rangeMin + " and max is " + tempReward.rangeMax);
                    return tempReward.id;
                }
            }
        }

        //exception
        Debug.Log("A reward was not able to be found");
        return -1;
    }
}
