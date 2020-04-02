/*
 * (Levi Schoof)
 * (HungryState.cs)
 * (Assignment 9)
 * (A class that implaments the Pet Statesm, and handles the behaviour when the enemy gets engraded due to hunger)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungryState : PetStates
{
    public override void FeedPet()
    {
        CorrectItem();
    }

    public override void NotifyPlayer()
    {
        thisPet.stateNotifier.text = "Hungry";
        thisPet.stateColor.color = Color.red;
    }

    public override void PlayWithPet()
    {
        WrongItem();
    }

    public override void WaterPet()
    {
        WrongItem();
    }

    public override void CorrectItem()
    {
        thisPet.currentHunger = thisPet.resetValue;
        thisPet.DeAgro();
    }

    public override void DecreaseSliders()
    {
        Debug.Log("No Decrease, in Hungry State State");
    }
}
