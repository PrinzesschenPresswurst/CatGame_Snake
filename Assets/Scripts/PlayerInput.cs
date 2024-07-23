using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private static MoveDirection _direction;
    private static Camera _cam;
    
    private PlayerIputActions _controls;
    private Vector2 _swipeVector;
    
    
    private void Start()
    {
        _direction = MoveDirection.Up;
        //_cam = Camera.main;
        
        _controls = new PlayerIputActions();
        _controls.Enable();
        _controls.Player.Swipe.performed += OnSwiped;
        _controls.Player.Touch.canceled += OnTouchCancelled;
    }
    
    private void OnSwiped(InputAction.CallbackContext context)
    {
        _swipeVector =  context.ReadValue<Vector2>();
    }

    private void OnTouchCancelled(InputAction.CallbackContext context)
    {
        if (Mathf.Abs(_swipeVector.x) > Mathf.Abs(_swipeVector.y)) 
        {
            if (_swipeVector.x > 0)
            {
                Debug.Log("swiped right");
                _direction = MoveDirection.Right;
            }
            else
            {
                Debug.Log("swiped left");
                _direction = MoveDirection.Left;
            }
        }
        
        else
        {
            if (_swipeVector.y > 0) 
            {
                Debug.Log("swiped up");
                _direction = MoveDirection.Up;
            }
            else 
            {
                Debug.Log("swiped down");
                _direction = MoveDirection.Down;
            }
        }
    }
    
    public static MoveDirection GetDirection(GameObject player)
    {
        return _direction;
    }

    /*
    public static MoveDirection GetDirection(GameObject player)
    {
        //for keys
       // _direction = GetMoveDirectionFromKeys();

        //for touch
        
        if (Input.touchCount > 0)
        {
            float angle = GetTouchAngle(player);
            _direction = GetDirectionFromTouch(angle);
        }
        
        return _direction;
    }

    private static  float GetTouchAngle(GameObject player) 
    {
        Touch touch = Input.GetTouch(0);
        Vector2 touchPos = new Vector2(touch.position.x, touch.position.y);
        Vector2 point = _cam.ScreenToWorldPoint (touchPos);
        Vector2 ownPos = player.transform.position;
        
        Vector2 touchDirection = point - ownPos;
        Vector2 rightVector = new Vector2(1, ownPos.y);
        return Vector2.SignedAngle(touchDirection, rightVector);
    }

    private static MoveDirection GetDirectionFromTouch(float angle)
    {
        switch (angle)
        {
            case > -45 and < 45:
                return MoveDirection.Up; 
            case > -135 and < 45:
                return MoveDirection.Left;
            case > 45 and < 135:
                return MoveDirection.Right;
            case > 135 and < 180:
            case < -135 and > -180:
                return MoveDirection.Down;
        }
        return _direction;
    }
    
    private static MoveDirection GetMoveDirectionFromKeys()
    {
        if (Input.GetKey(KeyCode.UpArrow) && _direction != MoveDirection.Down)
            return MoveDirection.Up;
            
        if (Input.GetKey(KeyCode.DownArrow) && _direction != MoveDirection.Up)
            return MoveDirection.Down;
        
        if (Input.GetKey(KeyCode.LeftArrow) && _direction != MoveDirection.Right)
            return MoveDirection.Left;
        
        if (Input.GetKey(KeyCode.RightArrow) && _direction != MoveDirection.Left)
            return MoveDirection.Right;
        
        return _direction;
    }
    */
    
    public enum MoveDirection 
    {
        Left, 
        Right, 
        Up, 
        Down
    }
}
