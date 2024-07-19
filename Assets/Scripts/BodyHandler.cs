using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BodyHandler : MonoBehaviour
{
    [SerializeField] private GameObject body;
    private GameObject _lastBody;
    private int _bodyNumber;
    private bool _isFirstBody;
    
    private void Start()
    {
        Treat.TreatWasCollected += OnTreatWasCollected;
        _bodyNumber = 1;
        _isFirstBody = true;
    }
    
    private void OnTreatWasCollected()
    {
        if (_isFirstBody)
        {
            PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
            _lastBody = playerMovement.gameObject;
            _isFirstBody = false;
        }
        
        GameObject newBody = Instantiate(body, _lastBody.transform.position, quaternion.identity);
        newBody.GetComponent<Body>().Parent = _lastBody;
        newBody.name = "Body: " + _bodyNumber;
        _bodyNumber++;
        _lastBody = newBody;
    }
}
