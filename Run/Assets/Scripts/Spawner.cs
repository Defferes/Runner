using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using Random = System.Random;

public class Spawner : MonoBehaviour
{
    public GameObject powerupPrefab;
    public GameObject obstaclePrefab;
    public float spawnCycle = .5f;
    GameManager manager;
    float elapsedTime;
    bool spawnPowerup = true;
    void Start()
    {
        manager = GetComponent<GameManager>();
    }
    void Update()
    {
        elapsedTime += Time.deltaTime;
        Random rnd = new Random();
        if (elapsedTime > spawnCycle)
        {
            GameObject temp;
            if (spawnPowerup)
                temp = Instantiate(powerupPrefab) as GameObject;
            else
                temp = Instantiate(obstaclePrefab) as GameObject;
            Vector3 position = temp.transform.position;
            position.x = rnd.Next(-1, 2);
            temp.transform.position = position;
            Collidable col = temp.GetComponent<Collidable>();
            col._GameManager = manager;
            elapsedTime = 0;
            spawnPowerup = !spawnPowerup;
        }
    }
}
