/*
 * (Levi Schoof)
 * (Pet.cs)
 * (Assignment 9)
 * (Handles the basic behaviour of the Monster and uses the PetStates)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pet : MonoBehaviour
{
    public int maxHunger;
    public int maxPlay;
    public int maxThirst;

    [HideInInspector] public int currentThirst;
    [HideInInspector] public int currentHunger;
    [HideInInspector] public int currentPlayful;

    public PetStates idleState;
    public PetStates hungryState;
    public PetStates playfulState;
    public PetStates thirstyState;
    public PetStates beingPushedUp;

    public Slider hungerSlider;
    public Slider thirstSlider;
    public Slider playSlider;

    public TextMeshProUGUI distanceFromPlayer;

    [HideInInspector] public PetStates currentState;

    public int decreasePerSecond = 10;

    public int angerLimit = 50;
    public int increaePerItem = 10;

    public int resetValue = 70;

    public float startingDistance = 200;
    public float normalFallSpeed = 1;

    public float failDistance = 50;

    public TextMeshProUGUI stateNotifier;
    public Image stateColor;

    GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        currentState = idleState;
        currentThirst = maxThirst;
        currentHunger = maxHunger;
        currentPlayful = maxPlay;

        hungerSlider.maxValue = maxHunger;
        thirstSlider.maxValue = maxThirst;
        playSlider.maxValue = maxPlay;

        hungerSlider.value = maxHunger;
        thirstSlider.value = maxThirst;
        playSlider.value = maxPlay;

        StartCoroutine(Sliders());
        StartCoroutine(Fall());
        StartCoroutine(UpdateUI());

        currentState.NotifyPlayer();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentState.PushUp();
        }

        else if (Input.GetKeyUp(KeyCode.Space))
        {
            currentState.CancelPushUp();
        }
    }


    IEnumerator UpdateUI()
    {
        while (true)
        {
            distanceFromPlayer.text = "Distance " + (transform.position.y - 10).ToString("F2");

            hungerSlider.value = currentHunger;
            thirstSlider.value = currentThirst;

            playSlider.value = currentPlayful;
            yield return new WaitForSeconds(0);
        }
    }

    public void Angry(string state)
    {
        switch (state)
        {
            case "Hunger":
                currentState = hungryState;
                break;
            case "Thirsty":
                currentState = thirstyState;
                break;
            case "Playful":
                currentState = playfulState;
                break;
        }

        currentState.NotifyPlayer();
    }

    IEnumerator Sliders()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            currentState.DecreaseSliders();
        }
    }

    IEnumerator Fall()
    {
        while (true)
        {
            yield return new WaitForSeconds(.01f);
            currentState.Fall();
        }
    }

    public void AddItem(string itemType)
    {
        switch (itemType)
        {
            case "Food":
                currentState.FeedPet();
                break;
            case "Drink":
                currentState.WaterPet();
                break;
            case "Toy":
                currentState.PlayWithPet();
                break;
        }
    }

    public void DeAgro()
    {
        currentState = idleState;
        currentState.NotifyPlayer();
    }

    public void KillPlayer()
    {
        gm.PlayerLost();
    }
}
