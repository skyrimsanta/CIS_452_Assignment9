/*
 * (Levi Schoof)
 * (BeingPushedUp.cs)
 * (Assignment 9)
 * (A class that implaments the Pet Statesm, and handles the behaviour of the enemy when its being pushed up)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeingPushedUp : PetStates
{
    public override void DecreaseSliders()
    {
        DeafultDecrease();
    }

    public override void FeedPet() {}

    public override void NotifyPlayer()
    {
        thisPet.stateNotifier.text = "Being Pushed Up";
        thisPet.stateColor.color = Color.white;
    }

    public override void PlayWithPet() { }

    public override void WaterPet() {}

    public override void Fall()
    {
        NotifyPlayer();
        Vector3 pos = thisPet.gameObject.transform.position;
        pos.y += thisPet.normalFallSpeed * Time.deltaTime;

        thisPet.gameObject.transform.position = pos;
    }

    public override void CancelPushUp()
    {
        thisPet.currentState = thisPet.idleState;
    }
}
