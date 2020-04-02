/*
 * (Levi Schoof)
 * (HungryState.cs)
 * (Assignment 9)
 * (A class that implaments the Pet Statesm, and handles the behaviour when the enemy gets engraded due to Thirst)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirstyState : PetStates
{
    public override void FeedPet()
    {
        WrongItem();
    }

    public override void NotifyPlayer()
    {
        thisPet.stateNotifier.text = "Thirsty";
        thisPet.stateColor.color = Color.blue;
    }

    public override void PlayWithPet()
    {
        WrongItem();
    }

    public override void WaterPet()
    {
        CorrectItem();
    }

    public override void CorrectItem()
    {
        thisPet.currentThirst = thisPet.resetValue;
        thisPet.DeAgro();
    }

    public override void DecreaseSliders()
    {
        Debug.Log("No Decrease, in Thirsty State");
    }
}
