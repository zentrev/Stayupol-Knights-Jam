using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletProjectile : ProjectileBase
{
    public GameObject BloodHitPrefab;

    public override void Fire(Vector3 velocity)
    {
        rb.AddForce(velocity, ForceMode.VelocityChange);

    }

    public override void Destruct()
    {
        List<Health> hpObjs = Physics.OverlapSphere(transform.position, 1.0f).Where(h => h.GetComponent<Health>()).Select(h => h.GetComponent<Health>()).ToList();
        foreach (Health c in hpObjs)
        {
            c.DealDamage(Damage ); //* modifier
        }
        Instantiate(BloodHitPrefab, transform.position, transform.rotation, null);
        Destroy(gameObject);
    }
}
