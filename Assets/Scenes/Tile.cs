using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int GridX { get; set; }
    public int x;
    public int GridY { get; set; }
    public int y;

    private void Start()
    {
        x = GridX;
        y = GridY;
    }
}
