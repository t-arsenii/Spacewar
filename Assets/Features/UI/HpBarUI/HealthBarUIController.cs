using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] Transform Target;
    [SerializeField] HealthController HealthController;

    [SerializeField] TextMeshProUGUI TextUiElement;

    void Start()
    {
        TextUiElement.text = HealthController.CurrentHealth.ToString();
        HealthController.AddOnHealthChangeEventHandler(UpdateUI);
    }
    void LateUpdate()
    {
        transform.position = Target.position;
        transform.rotation = Quaternion.identity;
    }
    private void UpdateUI(float currentHealth)
    {
        TextUiElement.text = currentHealth.ToString();
    }
}
