/*
 * (Levi Schoof)
 * (HungryState.cs)
 * (Assignment 9)
 * (A class that implaments the Pet Statesm, and handles the behaviour when the enemy gets engraded due to Joy)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayfulState : PetStates
{
    public override void FeedPet()
    {
        WrongItem();
    }

    public override void NotifyPlayer()
    {
        thisPet.stateNotifier.text = "Playful";
        thisPet.stateColor.color = Color.yellow;
    }

    public override void PlayWithPet()
    {
        CorrectItem();
    }

    public override void WaterPet()
    {
        WrongItem();
    }

    public override void CorrectItem()
    {
        thisPet.currentPlayful = thisPet.resetValue;
        thisPet.DeAgro();
    }

    public override void DecreaseSliders()
    {
        Debug.Log("No Decrease, in Playful State");
    }
}
