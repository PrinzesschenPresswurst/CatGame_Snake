using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Treat : MonoBehaviour
{
    public static event Action TreatWasCollected;

   private void OnTriggerEnter2D(Collider2D other)
    {
        if (TreatWasCollected != null)
            TreatWasCollected.Invoke();
        Destroy(this.gameObject);
    }
}
