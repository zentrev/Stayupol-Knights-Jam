using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ProjectileBase : MonoBehaviour
{
    public enum eProjectileType
    {
        BULLET,
        GRENADE,
        MISSILE,
        MOLOTOV
    }

    public eProjectileType projectileType;
    //WeaponBase owner;
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