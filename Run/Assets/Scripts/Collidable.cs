using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public GameManager _GameManager;
    public float moveSpeed = 10f;
    void Update()
    {
        transform.Translate(0, 0, -moveSpeed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if (gameObject.name == "Powerup(Clone)")
            {
                Data.Score++;
            }
            else if (gameObject.name == "Obstacle(Clone)")
            {
                _GameManager.LoseGame();
            }
            Destroy(gameObject);
        }
    }
}
