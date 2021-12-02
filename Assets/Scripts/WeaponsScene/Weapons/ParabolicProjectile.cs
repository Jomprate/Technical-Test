using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

public class ParabolicProjectile : MonoBehaviour
{
    [SerializeField] private Camera cam;
    public LayerMask layer;
    public GameObject cursor;
    public GameObject firepoint;

    private void Awake()
    {
        EnableBehaviour(true);
    }


    private void Update()
    {
        LaunchProjectile();
    }
    
    public void EnableBehaviour(bool enable) { this.enabled = enable switch {true => true, false => false}; }

    public void LaunchProjectile()
    {
        //Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
        Ray camRay = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        if (Physics.Raycast(camRay,out hit,1000f, layer))
        {
            cursor.SetActive(true);
            cursor.transform.position = hit.point + Vector3.up * 0.1f;

            Vector3 velocity = CalculateVelocity(hit.point, firepoint.transform.position, 1f);
            
            transform.rotation = Quaternion.LookRotation(velocity);

            if (Input.GetMouseButtonDown(0))
            {
                Rigidbody projectileRB = ObjectPooler.Instance.SpawnFromPool("ParabolicProjectile",firepoint.transform.position,Quaternion.identity).GetComponent<Rigidbody>();
                projectileRB.velocity = velocity;
            }
            else
            {
                //cursor.SetActive(false);
            }
            
        }
    }

    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {
        //define the distance x and y first
        Vector3 distance = target - origin;
        Vector3 distance_x_z = distance;
        distance_x_z.Normalize();
        distance_x_z.y = 0;

        //creating a float that represents our distance 
        float sy = distance.y;
        float sxz = distance.magnitude;


        //calculating initial x velocity
        //Vx = x / t
        float Vxz = sxz / time;

        ////calculating initial y velocity
        //Vy0 = y/t + 1/2 * g * t
        float Vy = sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distance_x_z * Vxz;
        result.y = Vy;



        return result;
    }   

}
