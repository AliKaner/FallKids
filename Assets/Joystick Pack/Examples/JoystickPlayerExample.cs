using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public FloatingJoystick variableJoystick;
    public Animator animator;
    public Rigidbody rb;
    public Vector3 direction;
    private static readonly int IsWalking = Animator.StringToHash("isWalking");

    public void FixedUpdate()
    {
        direction = Vector3.right * variableJoystick.Vertical + Vector3.back * variableJoystick.Horizontal;
        rb.freezeRotation = true;
        if (Input.GetMouseButton(0) && direction != Vector3.zero && GameStateManager.Instance.CurrentState != GameStates.Paint)
        {
            rb.freezeRotation = false;
            animator.SetBool(IsWalking, true);
            rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
            if (direction != Vector3.zero) transform.forward = direction;
        }
        else
        {
            animator.SetBool(IsWalking, false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Finish"))
        {
            animator.SetBool(IsWalking, false);
            enabled = true;
        }
    }

}