using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement Properties
    public float moveSpeed = 15;
    [Range(0, 1)] public float sliding = 0.9f;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Horizontal Movement
        float h = Input.GetAxis("Horizontal");
        Vector2 v = GetComponent<Rigidbody2D>().velocity;
        if (h != 0)
        {
            // Move Left/Right
            GetComponent<Rigidbody2D>().velocity = new Vector2(h * moveSpeed, v.y);
            transform.localScale = new Vector2(Mathf.Sign(h), transform.localScale.y);
        }
        else
        {
            // Get slower (Super Mario style sliding motion)
            GetComponent<Rigidbody2D>().velocity = new Vector2(v.x * sliding, v.y);
        }
        GetComponent<Animator>().SetFloat("Speed", Mathf.Abs(h));
    }
}
