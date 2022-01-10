using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")] 
    
    [Header("Gameplay")]
    public float bounds = 1f;

    private CharacterController _characterController;
    private float position = 0f,
        jumpSpeed = 12f;
    private Vector3 moveVec,gravity;
    private bool isMove = false;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
        moveVec = Vector3.zero;
        gravity = Vector3.zero;
    }

    void FixedUpdate()
    {
        if (_characterController.isGrounded)
        {
            gravity = Vector3.zero;
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                _animator.SetTrigger("IsJumping");
                gravity.y = jumpSpeed;
            }

            if (Input.GetAxisRaw("Vertical") < 0)
            {
                StartCoroutine("DoRolling");
            }
        }
        else
        {
            gravity += Physics.gravity * Time.deltaTime * 3f;
            if (_characterController.velocity.y < 0)
            {
                _animator.SetTrigger("IsFalling");
            }
        }

        moveVec += gravity;
        moveVec *= Time.deltaTime;
        _characterController.Move(moveVec);
        float input = Input.GetAxis("Horizontal");
        if (input != 0)
        {
            if (!isMove)
            {
                isMove = true;
                position += Mathf.Sign(input);
                position = Mathf.Clamp(position, -bounds, bounds);
            }
        }
        else isMove = false;
        
        Vector3 newPos = transform.position;
        newPos.x = Mathf.Lerp(newPos.x, position, 10f * Time.deltaTime);
        transform.position = newPos;
        
    }

    IEnumerator DoRolling()
    {
        _animator.SetBool("IsRolling",true);
        yield return new WaitForSeconds(1.5f);
        _animator.SetBool("IsRolling", false);
    }
}
