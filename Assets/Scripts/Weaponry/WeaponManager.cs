﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Header("Weapon Prefabs")]
    [SerializeField] GameObject ThrowWeapon;
    [SerializeField] GameObject ShootWeapon;
    [SerializeField] GameObject LaunchWeapon;
    [SerializeField] GameObject RollWeapon;
    [Header("Projectiled Prefabs")]
    [SerializeField] GameObject BulletProjectile;
    [SerializeField] GameObject MolotovProjectile;
    [SerializeField] GameObject GrenadeProjectile;
    [SerializeField] GameObject MissileProjectile;
    [Header("Modifier Prefabs")]
    [SerializeField] GameObject RicochetModifier;
    [SerializeField] GameObject ThreeWayModifier;
    [SerializeField] GameObject ClusterModifier;
    [SerializeField] GameObject PierceModifier;

    [Header("Player's Selections")]
    public ProjectileBase.eProjectileType projectileSelected;
    public WeaponBase.EWeapon weaponSelected;
    //Mod selected

        //Ref to player
    Transform weaponSpawnPosition;

    public void SetUpSelections()
    {
        //Get Selections (from manager?)
        //Instantiate game objects
        //Link them together
    }
}
