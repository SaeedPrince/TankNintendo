using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : BaseUnit
{
    public float shootPeriod;
    public float pathxPeriod;
    public float pathyPeriod;

    private Vector2 destination;
    private IEnumerator coroutine1;
    private IEnumerator coroutine2;
    private IEnumerator coroutine3;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        au = GetComponent<AudioSource>();
        Team = "Enemy";
        SetDestination();

        // AI behaviour is determined by three coroutines: shoot, fixpathx, fixpathy
        coroutine1 = Shoot(shootPeriod);
        coroutine2 = FixPathX(pathxPeriod);
        coroutine3 = FixPathY(pathyPeriod);
        StartCoroutine(coroutine1);
        StartCoroutine(coroutine2);
        StartCoroutine(coroutine3);
    }

    private IEnumerator Shoot(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Fire(1);
        }
    }

    private IEnumerator FixPathX(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            // compares his position with destination's
            if (transform.position.x > destination.x)
            {
                Move(-1, 0, -1);
            }
            else
            {
                Move(1, 0, -1);
            }
        }
    }

    private IEnumerator FixPathY(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            if (transform.position.y > destination.y)
            {
                Move(0, -1, -1);
            }
            else
            {
                Move(0, 1, -1);
            }
        }
    }

    private void SetDestination()
    {
        // Eagle coordinations
        destination.x = 0.24f;
        destination.y = -10.05f;
    }
}
