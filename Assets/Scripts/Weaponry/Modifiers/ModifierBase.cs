using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ModifierBase : MonoBehaviour
{
    public ProjectileBase m_projectile;
    public float m_damageModifier;

    public enum EModifier
    {
        NONE = 1 << 0,
        CLUSTER = 1 << 1,
        RICOCHET = 1 << 2,
        THREEWAY = 1 << 3,
        PIERCE = 1 << 4
    }

    protected abstract void OnCollisionEnter(Collision collision);

}
