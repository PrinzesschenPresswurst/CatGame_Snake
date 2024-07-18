using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BodyHandler : MonoBehaviour
{
    [SerializeField] private GameObject body;
    public static GameObject LastBody { get; set; }
    public static Tile LastBodyTile { get; set; }
    private int _bodyNumber;
    private void Start()
    {
        Treat.TreatWasCollected += OnTreatWasCollected;
        PlayerMovement.PlayerWasSetUp += OnPlayerWasSetUp;
        _bodyNumber = 1;
    }

    private void OnPlayerWasSetUp()
    {
        LastBody = FindObjectOfType<PlayerMovement>().gameObject;
        LastBodyTile = FindObjectOfType<PlayerMovement>()._currentTile;
    }
    
    private void OnTreatWasCollected()
    {
        GameObject newBody = Instantiate(body, LastBody.transform.position, quaternion.identity);
        newBody.GetComponent<Body>().Parent = LastBody;
        newBody.name = "Body: " + _bodyNumber;
        _bodyNumber++;
        LastBody = newBody;
    }
}
