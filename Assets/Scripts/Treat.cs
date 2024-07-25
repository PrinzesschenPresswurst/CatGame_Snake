using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Treat : MonoBehaviour
{
    public static EventHandler <TreatWasCollectedEventArgs> TreatWasCollected;
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        TreatWasCollected?.Invoke(this, new TreatWasCollectedEventArgs { TreatPosition = transform.position });
        Destroy(this.gameObject);
    }
    public class TreatWasCollectedEventArgs : EventArgs
    {
        public Vector2 TreatPosition { get; set; }
    }
}
