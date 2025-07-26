using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Items/WeaponPickable")]
public class WeaponPickable : ScriptableObject
{
     public WeaponType weaponType;
     public Sprite icon;

}
