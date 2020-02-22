using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeWayModifier : ModifierBase
{
    [SerializeField] float m_distanceApart = 3;
    private Rigidbody rb;
    private bool spawn = true;
    public bool horizontalShot = true;

    protected override void OnCollisionEnter(Collision collision)
    {
        m_projectile.Destruct();
    }

    private void OnEnable()
    {
        m_projectile.TryGetComponent(out rb);
    }

    private void Start()
    {

        if (spawn)
        {
            if (horizontalShot)
            {
                ProjectileBase firstSpawn = Instantiate(m_projectile);
                firstSpawn.GetComponent<ThreeWayModifier>().spawn = false;
                firstSpawn.transform.position += new Vector3(-m_distanceApart, 0.0f, 0.0f).normalized;
                firstSpawn.GetComponent<Rigidbody>().velocity = rb.velocity;

                ProjectileBase secondSpawn = Instantiate(m_projectile);
                secondSpawn.GetComponent<ThreeWayModifier>().spawn = false;
                secondSpawn.transform.position += new Vector3(m_distanceApart, 0.0f, 0.0f).normalized;
                secondSpawn.GetComponent<Rigidbody>().velocity = rb.velocity;
            }
            else
            {
                ProjectileBase firstSpawn = Instantiate(m_projectile);
                firstSpawn.GetComponent<ThreeWayModifier>().spawn = false;
                firstSpawn.transform.position += new Vector3(0.0f, -m_distanceApart, 0.0f).normalized;
                firstSpawn.GetComponent<Rigidbody>().velocity = rb.velocity;

                ProjectileBase secondSpawn = Instantiate(m_projectile);
                secondSpawn.GetComponent<ThreeWayModifier>().spawn = false;
                secondSpawn.transform.position += new Vector3(0.0f, m_distanceApart, 0.0f).normalized;
                secondSpawn.GetComponent<Rigidbody>().velocity = rb.velocity;
            }
        }

    }
}
