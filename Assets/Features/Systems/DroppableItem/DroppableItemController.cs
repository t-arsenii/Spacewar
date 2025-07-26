using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DroppableItemController : MonoBehaviour
{
    private IHealthController healthController;
    [SerializeField] List<GameObject> droppableObjects;
    void Start()
    {
        healthController = GetComponent<IHealthController>();
        InitSystem();

    }
    void InitSystem()
    {
        healthController.AddOnDeathEventHandler(DropLoot);
    }
    void DropLoot()
    {
        var dropItem = droppableObjects.ElementAt(Random.Range(0, droppableObjects.Count()));
        var bullet = Instantiate<GameObject>(dropItem, transform.position, transform.rotation);
    }
}
