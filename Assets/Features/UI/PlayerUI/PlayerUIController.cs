using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] GameObject Player;
    private IHealthController healthController;
    void Start()
    {
        IHealthController healthController = Player.GetComponent<IHealthController>(); 
    }

    void Update()
    {
        
    }
}
