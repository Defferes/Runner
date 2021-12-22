using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    public GameManager manager;
    public Material normalMat;
    public Material phasedMat;
    [Header("Gameplay")]
    public float bounds = 1f;
    public float phaseCooldown = 2f;
    Renderer mesh;
    Collider collision;
    bool canPhase = true;
    void Start()
    {
        mesh = GetComponentInChildren<SkinnedMeshRenderer>();
        collision = GetComponent<Collider>();
    }
    void Update()
    {
        Vector3 position = transform.position;
        if (Input.GetKeyDown(KeyCode.A))
        {
            position.x -= 1f;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            position.x += 1f;
        }
        if (Input.GetButtonDown("Jump") && canPhase)
        {
            canPhase = false;
            mesh.material = phasedMat;
            collision.enabled = false;
            Invoke("PhaseIn", phaseCooldown);
        }
        position.x = Mathf.Clamp(position.x, -bounds, bounds);
        transform.position = position;
    }
    void PhaseIn()
    {
        canPhase = true;
        mesh.material = normalMat;
        collision.enabled = true;
    }
}
