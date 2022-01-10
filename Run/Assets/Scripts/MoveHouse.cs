using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHouse : MonoBehaviour
{
    public float speed;
    private float offset = 23;
    void FixedUpdate()
    {
        Vector3 position = transform.position;
        transform.Translate(speed,0f,0f);
        if (transform.position.z <= -7f)
        {
            transform.position = new Vector3(position.x, position.y, offset);
        }
    }
}
