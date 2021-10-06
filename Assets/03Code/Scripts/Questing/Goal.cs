using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Goal
{
    public GoalType goalType;
    public GoalType2 Report;
    public int requiredAmount;
    public int currentAmount;

    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void RevengeOfTheSlimes()
    {
        if (goalType == GoalType.Kill)
        {
            currentAmount ++;
            Debug.Log("Triggered by Enemy");
        }
    }
}

public enum GoalType
{
    Kill,
    Gather,
    Rescue,
}
public enum GoalType2
{
    TalkToNpc,
    ReportProgress

}

