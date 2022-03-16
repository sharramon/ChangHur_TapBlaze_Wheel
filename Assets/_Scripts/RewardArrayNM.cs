using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//An array of the reward info
public static class RewardArrayNM
{
    //In an actual setting thie should be a method to read the values of a csv file or some equivalent
    public static string[,] getRewardArray() {
        string[,] reward2DArray = new string[8, 3] {
            {"Life", "30", "20" },
            {"Brush", "3", "10" },
            {"Gems", "35", "10" },
            {"Hammer", "3", "10" },
            {"Coins", "750", "5" },
            {"Brush", "1", "20" },
            {"Gems", "75", "5" },
            {"Hammer", "1", "20" } };

        checkPercentage(reward2DArray);

        return reward2DArray;
    }
    
    //A sanity check method call to check if all the percentages add up to a hundred
    public static void checkPercentage(string[,] reward2DArray)
    {
        int height = reward2DArray.GetLength(0);
        int sum = 0;
        for (int i = 0; i<height;i++)
        {
            sum = sum + int.Parse(reward2DArray[i, 2]);
        }

        if (sum != 100)
        {
            //Just a debug log for now. Later a method to force the numbers to sum to 100 can be added
            Debug.Log("The numbers just don't make sense! The sum is " + sum);
        }
    }
}
