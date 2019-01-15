using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.2f;
    private Vector2 movementVector;
    private Rigidbody2D playerRigidBody2d;

    private void Awake()
    {
        playerRigidBody2d = GetComponent<Rigidbody2D>();
        movementVector = Vector2.zero;
    }

    private void FixedUpdate()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        movementVector.x = h;
        movementVector.y = v;

        playerRigidBody2d.velocity = movementVector.normalized * speed;
    }
}
