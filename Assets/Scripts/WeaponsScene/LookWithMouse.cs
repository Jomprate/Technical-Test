using System;
using Managers;
using UnityEngine.InputSystem;
using UnityEngine;

public class LookWithMouse : MonoBehaviour
{
    public static LookWithMouse instance;
    
    public float mouseSensitivity = 100f;

    public Transform playerBody;
    public Transform playerSphere;

    private float _mouseX;
    private float _mouseY;

    private float _xRotation;

    private void Awake()
    {
        instance = this;
        
    }

    
    
    public static void CursorState(bool state)
    {
        switch (state)
        {
            case true:Cursor.lockState = CursorLockMode.Confined;
                Cursor.lockState = CursorLockMode.Locked;
                break;
            case false:Cursor.lockState = CursorLockMode.None;
                Cursor.lockState = CursorLockMode.None;
                break;
        }
    }
    
    private void Update()
    {
        
        #region Camera Movement

        
        if (ManagerS2.PlayerCanMove == true)
        {
            _mouseX = 0;
            _mouseY = 0;

            if (Mouse.current != null && InputManager.PlayerInputsActive)
            {
                var delta = Mouse.current.delta.ReadValue() / 15.0f;
                _mouseX += delta.x;
                _mouseY += delta.y;
            }
        
            if (Gamepad.current != null  && InputManager.PlayerInputsActive)
            {
                var value = Gamepad.current.rightStick.ReadValue() * 1;
                _mouseX += value.x;
                _mouseY += value.y;
            }

            _mouseX *= mouseSensitivity * Time.deltaTime;
            _mouseY *= mouseSensitivity * Time.deltaTime;

            _xRotation -= _mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -50f, 50f);

            playerSphere.localRotation = Quaternion.Euler(_xRotation, 0, 0f);
       
            playerBody.Rotate(Vector3.up * _mouseX);
        }
        #endregion
       
    }

    public static void UseCamera(bool use)
    {
    }
}
