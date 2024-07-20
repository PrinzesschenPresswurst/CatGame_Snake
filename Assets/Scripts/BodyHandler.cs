using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BodyHandler : MonoBehaviour
{
    [SerializeField] private GameObject body;
    public static GameObject _lastBody;
    private int _bodyNumber;
    private bool _isFirstBody;
    public static List<Body> bodyList;
    
    private void Start()
    {
        Treat.TreatWasCollected += OnTreatWasCollected;
        _bodyNumber = 1;
        _isFirstBody = true;
        bodyList = new List<Body>();
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
        //newBody.GetComponent<Body>().Parent = _lastBody;
        newBody.name = "Body: " + _bodyNumber;
        bodyList.Add(newBody.GetComponent<Body>());
        
        _bodyNumber++;
        _lastBody = newBody;
    }
}
