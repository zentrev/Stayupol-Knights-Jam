using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public enum EWeapon
    {
        NONE = 1 << 0,
        THROWN = 1 << 1,
        SHOOT = 1 << 2,
        LAUNCH = 1 << 3,
        ROLL = 1 << 4,
    }

    public EWeapon weaponType = EWeapon.NONE;
    public Vector3 velocity = Vector3.zero;
    // public ProjectileBase projectileRef = null;


    public void WeaponFire()
    {
        // projectileRef.Fire(velocity)
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
