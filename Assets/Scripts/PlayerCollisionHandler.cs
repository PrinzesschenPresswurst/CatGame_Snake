using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public static event Action PlayerCrashedInBody;
    private bool _firstBodySpawnException;

    private void Start()
    {
        _firstBodySpawnException = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_firstBodySpawnException)
        {
            if (other.gameObject.name == "Body: 1")
            {
                _firstBodySpawnException = true;
                Debug.Log("spawn body collision");
                return;
            }
        }
        
        if (other.gameObject.GetComponent<Treat>() != null)
            return;
        
        PlayerCrashedInBody?.Invoke();
        
        Debug.Log("collided with: " + other.name);
    }
}
