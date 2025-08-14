using System;
using UnityEngine;

public class InterractableController : MonoBehaviour, IInterractableController
{
     private event Action<Collider2D> OnInteractEventHandler;
     void Awake()
     {
          Collider2D ItemCollider2D = GetComponent<Collider2D>();
     }
     public void AddOnInteractEventHandler(Action<Collider2D> OnInteractEventHandler)
     {
          this.OnInteractEventHandler += OnInteractEventHandler;
     }

     public void Interact(Collider2D targetCollision)
     {
          OnInteractEventHandler?.Invoke(targetCollision);
     }
     void OnTriggerEnter2D(Collider2D targetCollision)
     {
          Debug.Log("Start interact");
          Interact(targetCollision);
     }
}

interface IInterractableController
{
     void AddOnInteractEventHandler(Action<Collider2D> OnInteractEventHandler);
     void Interact(Collider2D targetCollision);
}
