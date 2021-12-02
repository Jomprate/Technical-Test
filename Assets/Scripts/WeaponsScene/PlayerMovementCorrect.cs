using UnityEngine.InputSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class PlayerMovementCorrect : MonoBehaviour
{
    public CharacterController controller;
        
    public float speed = 12f;
    private Vector2 _moveDirection;
    private Vector3 _move;
    [SerializeField] private Vector2 cameraMoveDir;
    [SerializeField] private float rotationSpeed = 4f;
    
    [SerializeField] private Transform playerTransform;

    [SerializeField] private Rigidbody _rb;
    
    [Header("Hover")]
    public float desiredHeight = 2f;
    private float _offsetDistance, _differenceFloorDesiredHeight;
    private const float MovementStep = 0.1f;
    private Vector3 _targetPosition;
    [SerializeField] private float mouseSensitivity = 100f;
    private const string FloorTag = "Floor";
    

    public bool floorIsDown;

    private static bool _sprinting;

    private float _normalSpeed;
    private float _sprintSpeed;
    

    
    

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        _normalSpeed = 10f; _sprintSpeed = 16f;
        _sprinting = false;

        _rb = gameObject.GetComponent<Rigidbody>();
        
        InputManager.PlayerInputs.Player.Movement.performed += 
            context => MoveAxis(context.ReadValue<Vector2>());
        InputManager.PlayerInputs.Player.CameraMovement.performed +=
            context => CamAxis(context.ReadValue<Vector2>());
        InputManager.PlayerInputs.Player.Sprint.performed += context => Sprint();
    }

    //Input Usage to set the movement direction
    private void MoveAxis(Vector2 direction) => _moveDirection = direction;

    private void CamAxis(Vector2 camDirection) => cameraMoveDir = camDirection;

    //Update Method
    private void Update() { if (ManagerS2.PlayerCanMove) { PlayerMovementOnly(); } }

    private void FixedUpdate() { if (ManagerS2.PlayerCanMove) { HoverRayCast(); } }

    

    private void Sprint()
    {
        switch (_sprinting) {
            case true:
                speed = _normalSpeed;
                _sprinting = false;
                return;
            case false:
                speed = _sprintSpeed;
                _sprinting = true;
                return;
        }
    }

    

    //Let the player movement
    private void PlayerMovementOnly()
    {
        var x = _moveDirection.x;
        var z = _moveDirection.y;

        _move = playerTransform.right * x + playerTransform.forward * z;
        
        controller.Move(_move * (speed * Time.deltaTime));
        
    }


    #region Hover Player Movement
    
    //RayCast To calculate player floor distance
    private void HoverRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            _offsetDistance = hit.distance;
            Debug.DrawLine(transform.position, hit.point, Color.cyan);
            _differenceFloorDesiredHeight = _offsetDistance - desiredHeight;
            
            if (hit.transform.gameObject.CompareTag(FloorTag)) {
                floorIsDown = true;
                if (_differenceFloorDesiredHeight != 0f) {
                    var position = transform.position;
                    _targetPosition = new Vector3(position.x, position.y - _differenceFloorDesiredHeight, position.z);
                    MoveToCorrectHeight();
                }
            }

            if (!hit.transform.gameObject.CompareTag(FloorTag)) { floorIsDown = false; }
            
        }
    }
    //Move Player position in Y if it changes
    private void MoveToCorrectHeight()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, MovementStep);
    }
    #endregion
    
    
}
