using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BodyHandler : MonoBehaviour
{
    [SerializeField] private GameObject body;
    private int _bodyNumber;
    private bool _isFirstBody;
    
    public static GameObject LastBody { get; private set;}
    public static List<Body> BodyList { get; private set; }
    
    private void Start()
    {
        Treat.TreatWasCollected += OnTreatWasCollected;
        PlayerDeathHandler.PlayerDied += OnPlayerDied;
        _bodyNumber = 1;
        _isFirstBody = true;
        BodyList = new List<Body>();
    }
    
    private void OnTreatWasCollected()
    {
        if (_isFirstBody)
        {
            PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
            LastBody = playerMovement.gameObject;
            _isFirstBody = false;
        }
        
        GameObject newBody = Instantiate(body, LastBody.transform.position, quaternion.identity);
        newBody.name = "Body: " + _bodyNumber;
        BodyList.Add(newBody.GetComponent<Body>());
        
        _bodyNumber++;
        LastBody = newBody;
    }

    private void OnPlayerDied()
    {
        Treat.TreatWasCollected -= OnTreatWasCollected;
        PlayerDeathHandler.PlayerDied -= OnPlayerDied;
    }
}
