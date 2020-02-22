using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ModifierBase : MonoBehaviour
{
    public ProjectileBase m_projectile;
    public float m_damageModifier;

    public enum EModifier
    {
        NONE = 0,
        CLUSTER = 1,
        RICOCHET = 2,
        THREEWAY = 3,
        PIERCE = 4
    }

    protected abstract void OnCollisionEnter(Collision collision);

}
