using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ProjectileBase : MonoBehaviour
{
    public enum EProjectileType
    {
        NONE = 0,
        BULLET = 1,
        GRENADE = 2,
        MISSILE = 3,
        MOLOTOV = 4
    }

    public EProjectileType projectileType;
    WeaponBase owner;
    ModifierBase modifier;

    public Rigidbody rb;
    public float Damage;

    protected void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public abstract void Fire(float power, bool gravity);

    public abstract void Destruct();

}