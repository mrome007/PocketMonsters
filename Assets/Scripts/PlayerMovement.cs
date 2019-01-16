using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.2f;

    [SerializeField]
    private float jumpSpeed = 4f;
    private Vector2 movementVector;
    private Rigidbody2D playerRigidBody2d;
    private MovementDirection currentDirection;
    private bool movingThroughGap;

    private enum MovementDirection
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    private void Awake()
    {
        playerRigidBody2d = GetComponent<Rigidbody2D>();
        movementVector = Vector2.zero;

        movingThroughGap = false;
    }

    private void FixedUpdate()
    {
        if(movingThroughGap)
        {
            return;
        }

        var h = 0f;
        var v = 0f;

        if(Input.GetKey(KeyCode.D))
        {
            h = 1f;
            currentDirection = MovementDirection.RIGHT;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            h = -1f;
            currentDirection = MovementDirection.LEFT;
        }
        else if(Input.GetKey(KeyCode.W))
        {
            v = 1f;
            currentDirection = MovementDirection.UP;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            v = -1f;
            currentDirection = MovementDirection.DOWN;
        }

        movementVector.x = h;
        movementVector.y = v;

        playerRigidBody2d.velocity = movementVector.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var gap = collision.gameObject.GetComponent<Gap>();
        if(gap != null && currentDirection == MovementDirection.DOWN)
        {
            JumpThroughGap();
        }
    }

    private void JumpThroughGap()
    {
        StartCoroutine(JumpThroughGapRoutine());
    }

    private IEnumerator JumpThroughGapRoutine()
    {
        movingThroughGap = true;
        playerRigidBody2d.isKinematic = true;

        var targetPos = new Vector2(transform.position.x, transform.position.y - 0.35f);

        var distance = 0f;

        do
        {
            distance = (targetPos - (Vector2)transform.position).sqrMagnitude;
            transform.position = Vector2.Lerp(transform.position, targetPos, speed * jumpSpeed * Time.deltaTime);
            yield return null;

        }
        while(distance > 0.01f);

        movingThroughGap = false;
        playerRigidBody2d.isKinematic = false;
    }
}
