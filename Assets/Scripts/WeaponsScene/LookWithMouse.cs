using Managers;
using UnityEngine.InputSystem;
using UnityEngine;

public class LookWithMouse : MonoBehaviour
{
    public static LookWithMouse Instance;

    #region fields
    
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public Transform playerSphere;
    
    private float _mouseX;
    private float _mouseY;
    private float _xRotation;
    
    #endregion
    //Used for singleton
    private void Awake() => Instance = this;
    
    //Used for change the cursor state
    public static void CursorState(bool state) {
        switch (state) {
            case true:Cursor.lockState = CursorLockMode.Confined; Cursor.lockState = CursorLockMode.Locked; break;
            case false:Cursor.lockState = CursorLockMode.None; Cursor.lockState = CursorLockMode.None; break;
        }
    }
    
    //Void For the respective first Person camera Movement
    private void Update() {
        #region Camera Movement

        if (ManagerS2.PlayerCanMove != true) return;
            _mouseX = 0;
            _mouseY = 0;

            if (Mouse.current != null && InputManager.PlayerInputsActive) {
                var delta = Mouse.current.delta.ReadValue() / 15.0f;
                _mouseX += delta.x;
                _mouseY += delta.y;
            }
            
            if (Gamepad.current != null  && InputManager.PlayerInputsActive) {
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
        #endregion
    }

}
