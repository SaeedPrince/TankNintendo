using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : BaseObject
{
    public float Damage;
    public BaseUnit Owner;
    public float speed;
    public int lifespan;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // bullet velocity is dependent to its owner power projector parameter, too
        rb.velocity = transform.TransformVector(Vector3.down * speed* Owner.powerProjector);
        Destroy(gameObject, lifespan);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BaseObject theObj = collision.GetComponent<BaseObject>();
        BaseUnit theUnit = collision.GetComponent<BaseUnit>();
        if (theObj == null)
        {
            Destroy(gameObject);
        }
        else if (Owner != theObj)
        {
            // Removing friendly fire
            if (theUnit == null || theUnit.GetTeam() != Owner.GetTeam())
            {
                theObj.Health--;
                this.Health--;
            }
        }
    }
}
