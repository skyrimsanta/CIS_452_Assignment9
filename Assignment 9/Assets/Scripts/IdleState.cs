/*
 * (Levi Schoof)
 * (IdleState.cs)
 * (Assignment 9)
 * (A class that implaments the Pet Statesm, and handles the behaviour of the normal state of the enemy)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PetStates
{
    public override void FeedPet()
    {
        CorrectItem("Food");
    }

    public override void NotifyPlayer()
    {
        thisPet.stateNotifier.text = "Idle";
        thisPet.stateColor.color = Color.white;
    }

    public override void PlayWithPet()
    {
        CorrectItem("Toy");
    }

    public override void WaterPet()
    {
        CorrectItem("Drink");
    }

    public override void CorrectItem(string item)
    {
        switch (item)
        {
            case "Food":
                thisPet.currentHunger += thisPet.increaePerItem;
                break;
            case "Drink":
                thisPet.currentThirst += thisPet.increaePerItem;
                break;
            case "Toy":
                thisPet.currentPlayful += thisPet.increaePerItem;
                break;
        }
    }

    public override void DecreaseSliders()
    {
        DeafultDecrease();
    }

    public override void PushUp()
    {
        thisPet.currentState = thisPet.beingPushedUp;
      
    }
}
