/*
 * (Levi Schoof)
 * (PetStates.cs)
 * (Assignment 9)
 * (The Abstract State Machine Class)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class PetStates : MonoBehaviour
{
    protected Pet thisPet;
    int randomNum;

    public abstract void NotifyPlayer();
    public abstract void FeedPet();
    public abstract void WaterPet();
    public abstract void PlayWithPet();
    public abstract void DecreaseSliders();
 

    private void Start() { thisPet = this.GetComponent<Pet>(); }

    public void WrongItem() { Debug.Log("Wrong Item"); }

    public virtual void CorrectItem() { }

    public virtual void CorrectItem(string item) { }

    public virtual void CancelPushUp() { }

    public virtual void PushUp() { }

    public virtual void Fall()
    {
        DeafultFall();
    }

    public void DeafultDecrease()
    {
        randomNum = Random.Range(0, 3);


        switch (randomNum)
        {
            case 0:
                thisPet.currentHunger -= thisPet.decreasePerSecond;
                break;
            case 1:
                thisPet.currentThirst -= thisPet.decreasePerSecond;
                break;
            case 2:
                thisPet.currentPlayful -= thisPet.decreasePerSecond;
                break;
        }

        if (thisPet.currentHunger < thisPet.angerLimit)
        {
            thisPet.Angry("Hunger");
        }

        else if (thisPet.currentThirst < thisPet.angerLimit)
        {
            thisPet.Angry("Thirsty");
        }

        else if (thisPet.currentPlayful < thisPet.angerLimit)
        {
            thisPet.Angry("Playful");
        }
    }

    public void DeafultFall()
    {
        Vector3 pos = thisPet.gameObject.transform.position;
        pos.y -= thisPet.normalFallSpeed * Time.deltaTime;

        thisPet.gameObject.transform.position = pos;

        Debug.Log("Deafult Fall Is being Called");

        if(thisPet.gameObject.transform.position.y <= thisPet.failDistance)
        {
            thisPet.KillPlayer();
        }
    }
}
