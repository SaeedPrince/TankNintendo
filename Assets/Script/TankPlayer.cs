using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPlayer : BaseUnit
{
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        au = GetComponent<AudioSource>();
        Team = "Player";
    }

    protected void Stop()
    {
        rb.velocity = new Vector2(0, 0);
    }

    void Update ()
    {
        // Moving by keyboard using: WASD
        if (Input.GetKey(KeyCode.W))
        {
            Move(0, 1, 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Move(0, -1, 1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Move(1, 0, 1);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Move(-1, 0, 1);
        }
        else
        {
            Stop();
        }
        // Fire with SPACE
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire(-1);
        }
    }
}
