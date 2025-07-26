using UnityEngine;

public class WeaponPickableController : MonoBehaviour
{
    [SerializeField] private WeaponPickable weaponPickable;
    private IInterractableController interractableController;
    void Awake()
    {
        interractableController = GetComponent<IInterractableController>();
    }
    void Start()
    {
        interractableController.AddOnInteractEventHandler(InteractionHandler);
    }
    void InteractionHandler(Collider2D targetCollider2D)
    {
        IEquipmentController equipmentController = targetCollider2D.gameObject.GetComponent<IEquipmentController>();
        if (equipmentController is not null)
        {
            equipmentController.PickupWeapon(weaponPickable.weaponType);
            Destroy(gameObject);
        }
    }
}
