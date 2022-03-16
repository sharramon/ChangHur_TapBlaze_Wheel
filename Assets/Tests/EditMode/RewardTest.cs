using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class RewardTest
{
    // A Test behaves as an ordinary method
    [Test]
    //this just runs the reward chances 1000 times and sees how many times the player has one each specific prize
    public void RewardChances()
    {
        //instantiate class
        RewardDecideNM rewardDecide = new RewardDecideNM();
        List<int> spinResult = new List<int>();

        int[] resultArray = new int[rewardDecide.rewardList.Count];
        //run the CalculateReward method 1000 times
        for(int i = 0; i < 1000; i++)
        {
            int id = rewardDecide.CalculateReward();
            spinResult.Add(id);
            resultArray[id]++;
            Debug.Log("spin number " + (i+1) + " and the id is " + id);
        }

        int sum = 0;
        for (int i = 0; i < resultArray.Length; i++) {
            Debug.Log("The number of times player won " + rewardDecide.rewardList[i].amount + " of " + rewardDecide.rewardList[i].prize + " is " + resultArray[i]);
            sum = sum + resultArray[i];
        }
        //sanity check
        Debug.Log("Sum of all spins is " + sum);
    }

}
