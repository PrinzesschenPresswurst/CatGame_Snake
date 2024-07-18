using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSettingsHandler : MonoBehaviour
{
    public static float ScreenWidth { get; private set; }
    public static float ScreenHeight { get; private set; } 
    private Camera _cam;

    private void Awake()
    {
        _cam = Camera.main;

        if (_cam != null)
        {
            GetScreenSize();
            SetCameraPosition();
        }
    }

    private void GetScreenSize()
    {
        ScreenHeight = _cam.orthographicSize *2;
        ScreenWidth = ScreenHeight * _cam.aspect;
    }

    private void SetCameraPosition()
    {
        _cam.transform.position = new Vector3(ScreenWidth / 2, ScreenHeight / 2, -10);
    }
}
