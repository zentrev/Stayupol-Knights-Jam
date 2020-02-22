using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class MolotovProjectile : ProjectileBase
{
    public GameObject FloodPrefab;
    public float Range;

    public override void Fire(float power, bool gravity)
    {
        rb.useGravity = gravity;
        rb.AddForce(transform.forward * power, ForceMode.VelocityChange);
        rb.AddTorque(new Vector3(Random.value * 90.0f, 0, 0), ForceMode.Impulse);

    }

    public override void Destruct()
    {
        Instantiate(FloodPrefab, transform.position, transform.rotation, null);
        Destroy(gameObject);

    }
}
