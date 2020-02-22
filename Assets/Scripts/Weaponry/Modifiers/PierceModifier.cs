using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PierceModifier : ModifierBase
{
    private Rigidbody rb;
    private Vector3 velocity;

    private void OnEnable()
    {
        m_projectile.TryGetComponent(out rb);
    }

    private void Update()
    {
        velocity = rb.velocity;
        if(rb.velocity != velocity)
        {
            rb.velocity = velocity;
        }
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag != "Player")
        {
            Physics.IgnoreCollision(collision.GetContact(0).thisCollider, collision.collider);
            rb.velocity = velocity;
        }
        m_projectile.Destruct();

    }

}
