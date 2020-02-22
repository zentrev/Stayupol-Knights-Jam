using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClusterModifier : ModifierBase
{
    [SerializeField] int m_clusterCount = 3;
    [SerializeField] int m_waitTimer = 1;

    private void OnEnable()
    {
        m_projectile.Damage = m_projectile.Damage / m_clusterCount;
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        throw new System.NotImplementedException();
    }

    private void Update()
    {
        
    }
}
