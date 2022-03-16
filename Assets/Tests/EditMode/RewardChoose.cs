using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
public class RewardChoose
{
    // Start is called before the first frame update

    [Test]
    public void RewardSnipe()
    {
        //instantiate class
        RewardDecideNM rewardDecide = new RewardDecideNM();

        float testInput = 36.7f;
        //ranges for output in this case are
        //0 : 0~20 ; 1 : 20~30 ; 2 : 30~40 ; 3 : 40~50 ; 4 : 50~55 ; 5 : 55~75 ; 6 : 75~80 ; 7 : 80~100
        //with the higher limit given to the higher id, except for 100.
        int expectedOutput = 2;

        int id = rewardDecide.Search(testInput);

        Assert.AreEqual(expected: expectedOutput, actual: id);
        Debug.Log("Expected is " + expectedOutput + " and actual is " + id);
    }
}
