/*
 * (Levi Schoof)
 * (Pet.cs)
 * (Assignment 9)
 * (Spawnss the different pickups)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    private float startingForEach = 3;

    public GameObject foodPrefab;
    public GameObject drinkPrefab;
    public GameObject toyPrefab;

    private GameObject spawnType;

    Vector3 center;

    Vector3 pos;

    public float radius;

    private float ang;

    private void Start()
    {
        center = this.transform.position;
        InitialSpawn();
    }

    private void InitialSpawn()
    {
        for (int i = 0; i < startingForEach; i++)
        {
            SpawnObject("Food");
        }

        for (int i = 0; i < startingForEach; i++)
        {
            SpawnObject("Drink");
        }

        for (int i = 0; i < startingForEach; i++)
        {
            SpawnObject("Toy");
        }
    }

    public void SpawnObject(string itemType)
    {
        pos = Random.insideUnitSphere * radius;
        pos.y = 1;

        switch (itemType)
        {
            case "Food":
                Instantiate(foodPrefab, pos, Quaternion.identity);
                break;

            case "Drink":
                Instantiate(drinkPrefab, pos, Quaternion.identity);
                break;

            case "Toy":
                Instantiate(toyPrefab, pos, Quaternion.identity);
                break;
            
        }
    }


}
