using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DroppableItemController : MonoBehaviour
{
     private IHealthController healthController;
     [SerializeField] List<GameObject> droppableObjectPrefabs;
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
          //TODO: Very bad code, strange behaviour when object is destoryed before dropLoot is called;
          if (gameObject is null)
          {
               return;
          }
          var dropItem = droppableObjectPrefabs.ElementAt(Random.Range(0, droppableObjectPrefabs.Count()));
          var itemObject = Instantiate<GameObject>(dropItem, transform.position, transform.rotation);
     }
}
