using UnityEngine;

public class RifleController : MonoBehaviour, PickableItem
{
    WeaponType weaponType = WeaponType.Rifle;
    void OnTriggerEnter2D(Collider2D collision)
    {
        IEquipmentController equipementController = collision.GetComponent<IEquipmentController>();
        if (equipementController is not null)
        {
            equipementController.PickupWeapon(weaponType);
            Destroy(gameObject);
        }
    }
}

interface PickableItem
{
    
}
