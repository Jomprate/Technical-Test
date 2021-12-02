using Managers;
using UnityEngine;

public class PlayerMovementCorrect : MonoBehaviour
{
    #region Fields
    public CharacterController controller;
        
    public float speed = 12f;
    private Vector2 _moveDirection;
    private Vector3 _move;
    [SerializeField] private Transform playerTransform;

    [Header("Hover")]
    public float desiredHeight = 2f;
    private float _offsetDistance, _differenceFloorDesiredHeight;
    private const float MovementStep = 0.1f;
    private Vector3 _targetPosition;
    private const string FloorTag = "Floor";
    

    public bool floorIsDown;

    private static bool _sprinting;

    private float _normalSpeed;
    private float _sprintSpeed;
    

    #endregion

    private void Start() => Initialize();

    private void Initialize() {
        _normalSpeed = 10f; _sprintSpeed = 16f;
        _sprinting = false;
        InputManager.PlayerInputs.Player.Movement.performed += 
            context => MoveAxis(context.ReadValue<Vector2>());
        
        InputManager.PlayerInputs.Player.Sprint.performed += context => Sprint();
    }

    //Input Usage to set the movement direction
    private void MoveAxis(Vector2 direction) => _moveDirection = direction;

    //Update Method
    private void Update() { if (ManagerS2.PlayerCanMove) { PlayerMovementOnly(); } }
    //FixedUpdate Method
    private void FixedUpdate() { if (ManagerS2.PlayerCanMove) { HoverRayCast(); } }
    
    //Used to change between walking & Sprinting
    private void Sprint() {
        switch (_sprinting) {
            case true: speed = _normalSpeed; _sprinting = false; return;
            case false: speed = _sprintSpeed; _sprinting = true; return;
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
