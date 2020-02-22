using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LoadoutSelection : MonoBehaviour
{
    public List<Toggle> selectedWeapon = null;
    public List<Toggle> selectedProjectile = null;
    public List<Toggle> selectedModifier = null;

    public WeaponManager weaponManager;

    public void Start()
    {
        weaponManager = GameObject.FindObjectOfType<Network.NetworkRoomPipeline>().LocalPlayer.GetComponent<WeaponManager>();
    }

    public void ReadyUp()
    {
        //Sets the weapon manager to the correct Weapon for the player
       switch(selectedWeapon.First(e => e.isOn).name)
       {
            case "Random":
                weaponManager.weaponSelected = (WeaponBase.EWeapon)Random.Range(1, 5);
                break;
            case "Thrown":
                weaponManager.weaponSelected = WeaponBase.EWeapon.THROWN;
                break;
            case "Shoot":
                weaponManager.weaponSelected = WeaponBase.EWeapon.SHOOT;
                break;
            case "Launch":
                weaponManager.weaponSelected = WeaponBase.EWeapon.LAUNCH;
                break;
            case "Roll":
                weaponManager.weaponSelected = WeaponBase.EWeapon.ROLL;
                break;
       }
        //Sets the weapon manager to the correct Projectile for the player
       switch(selectedProjectile.First(e => e.isOn).name)
       {
           case "Random":
                weaponManager.projectileSelected = (ProjectileBase.EProjectileType)Random.Range(1, 5);
                break;
           case "Thrown":
               weaponManager.projectileSelected = ProjectileBase.EProjectileType.BULLET;
                break;
           case "Shoot":
               weaponManager.projectileSelected = ProjectileBase.EProjectileType.GRENADE;
                break;
           case "Launch":
               weaponManager.projectileSelected = ProjectileBase.EProjectileType.MISSILE;
                break;
           case "Roll":
               weaponManager.projectileSelected = ProjectileBase.EProjectileType.MOLOTOV;
                break;
       }
        //Sets the weapon manager to the correct Modifier for the player
       switch(selectedModifier.First(e => e.isOn).name)
       {
           case "Random":
                weaponManager.modifierSelected = (ModifierBase.EModifier)Random.Range(1, 5);
                break;
           case "Thrown":
                weaponManager.modifierSelected = ModifierBase.EModifier.CLUSTER;
                break;
           case "Shoot":
                weaponManager.modifierSelected = ModifierBase.EModifier.RICOCHET;
                break;
           case "Launch":
                weaponManager.modifierSelected = ModifierBase.EModifier.THREEWAY;
                break;
           case "Roll":
                weaponManager.modifierSelected = ModifierBase.EModifier.PIERCE;
                break;
       }
        Debug.Log(weaponManager.weaponSelected.ToString() + " " + weaponManager.projectileSelected.ToString() + " " + weaponManager.modifierSelected.ToString());
    }
}
