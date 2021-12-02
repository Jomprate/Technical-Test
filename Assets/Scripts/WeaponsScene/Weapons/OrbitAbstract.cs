using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OrbitAbstract : MonoBehaviour
{
    public Transform center;
    //public Vector3 axis = Vector3.forward;
    public Vector3 axis = new Vector3(0,0,1);
    public float radius = 2.0f;
    public float radiusSpeed = 0.5f;
    public float rotationSpeed = 80.0f;
    
 
    void Start() {
        if (center != null)
        {
            transform.position = (transform.position - center.position).normalized * radius + center.position;
        }
        
    }
 
    public void Update() {
        // transform.RotateAround (center.position, axis, rotationSpeed * Time.deltaTime);
        // var desiredPosition = (transform.position - center.position).normalized * radius + center.position;
        // transform.position = Vector3.MoveTowards( transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
    }
    
}
