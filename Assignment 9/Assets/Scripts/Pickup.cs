/*
 * (Levi Schoof)
 * (Pickup.cs)
 * (Assignment 9)
 * (Handles the basic behaviour of the pickups)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum Type { food, drink, toy};
    public Type thisType;

    Pet pet;
    PickupSpawner spawner;

    private void Start()
    {
        pet = FindObjectOfType<Pet>();
        spawner = FindObjectOfType<PickupSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (thisType)
            {
                case Type.food:
                    pet.AddItem("Food");
                    spawner.SpawnObject("Food");
                    break;
                case Type.drink:
                    pet.AddItem("Drink");
                    spawner.SpawnObject("Drink");
                    break;
                case Type.toy:
                    pet.AddItem("Toy");
                    spawner.SpawnObject("Toy");
                    break;
                    
            }

            Destroy(this.gameObject);
        }

     
    }
}
