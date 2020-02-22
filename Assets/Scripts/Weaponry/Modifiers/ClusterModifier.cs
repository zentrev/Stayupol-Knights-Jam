using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClusterModifier : ModifierBase
{
    [SerializeField] int m_clusterCount = 3;
    [SerializeField] float m_waitTimer = 1;
    [SerializeField] float m_explosionForce = -1000;
    public bool cluster = true;
    private Rigidbody rb;

    private void OnEnable()
    {
        m_projectile.Damage = m_projectile.Damage / m_clusterCount;
        m_projectile.TryGetComponent(out rb);
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        m_projectile.Destruct();

    }

    private void Update()
    {
        m_waitTimer -= Time.deltaTime;
        if(m_waitTimer <= 0.0f && cluster == true)
        {
            cluster = false;
            ClusterSpawn();
        }
    }

    private void ClusterSpawn()
    {
        for(int i = 0; i < m_clusterCount; i++)
        {
            ProjectileBase newSpawn = Instantiate(m_projectile);
            newSpawn.GetComponent<ClusterModifier>().cluster = false;
            newSpawn.transform.position += new Vector3(Random.value, Random.value, Random.value).normalized;
            newSpawn.GetComponent<Rigidbody>().velocity = rb.velocity;
            newSpawn.rb.AddExplosionForce(m_explosionForce, newSpawn.transform.position, 1);
        }
    }
}
