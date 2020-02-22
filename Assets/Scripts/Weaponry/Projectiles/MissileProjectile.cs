using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class MissileProjectile : ProjectileBase
{
    public float Range;
    public bool fired;
    public float timer;
    public float boost;
    public GameObject ExplosionPrefab;

    public override void Fire(float power, bool gravity)
    {
        rb.useGravity = gravity;
        rb.AddForce(transform.forward * power, ForceMode.VelocityChange);
        fired = true;
    }

    private void Update()
    {
        if (fired && timer > 0.0f)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0.0f)
        {
            rb.AddForce(rb.transform.forward * boost, ForceMode.Acceleration);
        }
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
