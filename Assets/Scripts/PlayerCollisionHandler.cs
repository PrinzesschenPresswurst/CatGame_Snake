using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public static event Action PlayerCrashedInBody;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Body: 1") 
            return;

        if (other.gameObject.GetComponent<Treat>() != null)
            return;
        
        if (PlayerCrashedInBody != null)
            PlayerCrashedInBody.Invoke();
        
        Debug.Log("collided with: " + other.name);
    }
}
