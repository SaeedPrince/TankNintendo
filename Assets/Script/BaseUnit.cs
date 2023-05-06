using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : BaseObject
{

    public float Speed;                 // Move speed
    public string Heading;              // Face to where
    public float powerProjector;        // Power of bullets
    public Projectile bulletPrefab;

    protected string Team;

    protected Rigidbody2D rb;
    protected SpriteRenderer sr;
    protected AudioSource au;

    // Getter
    public string GetTeam()
    {
        return Team;
    }

    protected void Move(float Xdirection, float Ydirection, float coer)
    {
        // Engine sound
        au.Play();

        // Heading to top
        if (Ydirection > 0)
        {
            switch (Heading)
            {
                case "Left":
                    transform.Rotate(0, 0, 90 * coer);
                    break;
                case "Right":
                    transform.Rotate(0, 0, -90 * coer);
                    break;
                case "Bot":
                    transform.Rotate(0, 0, 180);
                    break;
            }
            Heading = "Top";
        }
        // Heading to bot
        else if (Ydirection < 0)
        {
            switch (Heading)
            {
                case "Left":
                    transform.Rotate(0, 0, -90 * coer);
                    break;
                case "Right":
                    transform.Rotate(0, 0, 90 * coer);
                    break;
                case "Top":
                    transform.Rotate(0, 0, 180);
                    break;
            }
            Heading = "Bot";
        }

        // Heading to right
        if (Xdirection > 0)
        {
            switch (Heading)
            {
                case "Top":
                    transform.Rotate(0, 0, 90 * coer);
                    break;
                case "Bot":
                    transform.Rotate(0, 0, -90 * coer);
                    break;
                case "Left":
                    transform.Rotate(0, 0, 180);
                    break;
            }
            Heading = "Right";
        }

        // Heading to left
        else if (Xdirection < 0)
        {
            switch (Heading)
            {
                case "Top":
                    transform.Rotate(0, 0, -90 * coer);
                    break;
                case "Bot":
                    transform.Rotate(0, 0, 90 * coer);
                    break;
                case "Right":
                    transform.Rotate(0, 0, 180);
                    break;
            }
            Heading = "Left";
        }

        // Set velocity to speed * direction
        rb.velocity = new Vector2(Xdirection * Speed, Ydirection * Speed);

    }

    protected void Fire(float direction)
    {
        // Instantiate bullet to shoot
        Quaternion pose = transform.rotation;
        pose.w = pose.w * direction;
        Projectile bulletClone = Instantiate(bulletPrefab, transform.position, pose);
        bulletClone.Owner = this;
    }
}
