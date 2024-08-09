using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movementSpeed = 5f;
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    //position+movement ensures it goes the right way. movementSpeed makes sure it's going the right speed and the Time is to keep the movement constant.
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}