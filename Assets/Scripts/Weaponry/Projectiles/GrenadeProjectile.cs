using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GrenadeProjectile : ProjectileBase
{
    public float Range;
    public GameObject ExplosionPrefab;

    public override void Fire(float power, bool gravity)
    {
        rb.useGravity = gravity;
        rb.AddForce(transform.forward * power, ForceMode.VelocityChange);
        rb.AddTorque(new Vector3(Random.value * 90.0f, 0, 0), ForceMode.Impulse);
    }

    public override void Destruct()
    {
        List<Health> hpObjs = Physics.OverlapSphere(transform.position, Range).Where(h => h.GetComponent<Health>()).Select(h => h.GetComponent<Health>()).ToList();
        foreach (Health c in hpObjs)
        {
            c.DealDamage(Damage); //* modifier

        }
        Instantiate(ExplosionPrefab, transform.position, transform.rotation, null);
        Destroy(gameObject);
    }
}
