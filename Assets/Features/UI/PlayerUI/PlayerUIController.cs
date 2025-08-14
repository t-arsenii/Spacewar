using TMPro;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
     [SerializeField] GameObject Player;
     private IHealthController healthController;
     private IEquipmentController equipmentController;
     private IWeaponUserController weaponUserController;
     [SerializeField] private TextMeshProUGUI playerHpUI;
     [SerializeField] private TextMeshProUGUI weaponUI; 
     [SerializeField] private TextMeshProUGUI ammoUI; 
     void Start()
     {
          healthController = Player.GetComponent<IHealthController>();
          equipmentController = Player.GetComponent<IEquipmentController>();
          weaponUserController = Player.GetComponent<IWeaponUserController>();

          healthController.AddOnHealthChangeEventHandler(UpdateHpUI);
          equipmentController.AddOnWeaponChangeHandler(UpdateWeaponUi);
          equipmentController.AddOnWeaponChangeHandler(UpdateAmmoUI);
          weaponUserController.AddOnSelectedWeaponAmmoChangeHandler(UpdateAmmoUI);
          
          InitUI();
     }

     void Update()
     {

     }
     void InitUI()
     {
          playerHpUI.text = healthController.CurrentHealth.ToString();
          WeaponModel selectedWeapon = equipmentController.GetSelectedEquipement();
          weaponUI.text = selectedWeapon.weaponData.WeaponType.ToString();
          string ammoText = selectedWeapon.CurrentAmmo.ToString() + " / " + selectedWeapon.weaponData.MaxAmmo;
          ammoUI.text = ammoText; 
     }
     void UpdateHpUI(float currentHp)
     {
          playerHpUI.text = currentHp.ToString();
     }
     void UpdateAmmoUI(WeaponModel weaponModel)
     {
          string ammoText = weaponModel.CurrentAmmo.ToString() + " / " + weaponModel.weaponData.MaxAmmo;
          ammoUI.text = ammoText;
     }
     void UpdateWeaponUi(WeaponModel weaponModel)
     {
          weaponUI.text = weaponModel.weaponData.WeaponType.ToString();
     }
}
