using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDataSO", menuName = "Items/WeaponData")]
public class WeaponDataSO : ScriptableObject
{
     [SerializeField] private WeaponType weaponType;
     [SerializeField] private int maxAmmo;
     [SerializeField] private int damage;
     [SerializeField] private float fireRate;
     [SerializeField] GameObject projectilePrefab;

     public WeaponType WeaponType => weaponType;
     public int MaxAmmo => maxAmmo;
     public int Damage => damage;
     public float FireRate => fireRate;
     public GameObject ProjectilePrefab => projectilePrefab;
}

// [SerializeField] private float maxCooldown;