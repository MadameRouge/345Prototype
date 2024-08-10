using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordRotation : MonoBehaviour
{
    void Update()
    {
        //Rotates the sword to face where the mouse is.
        Vector3 mouseLocation = Input.mousePosition;
        mouseLocation = Camera.main.ScreenToWorldPoint(mouseLocation);
        Vector2 direction = new Vector2(mouseLocation.x - transform.position.x, mouseLocation.y - transform.position.y);
        transform.up = direction;
    }
}
