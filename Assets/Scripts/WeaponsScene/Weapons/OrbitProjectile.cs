using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

public class OrbitProjectile : MonoBehaviour
{
    //[SerializeField] private Orbit orbit;
    private string orbiterObjectTag = "OrbiterObj";
    [SerializeField] private SphereCollider _orbitSphereCollider;
    [SerializeField] public bool catchGameObjects;

    private float rRadius;
    private float rSpeed;

    public float smallestRO;
    public float biggestRO;
    public float smallestRS;
    public float biggestRS;
    

    

    public void Start()
    {
        catchGameObjects = true;





    }

    private void ReactiveCollider()
    {
        _orbitSphereCollider.enabled = true;
    }
    
    public void ModifyOrbitValues(float smallestRO,float biggestRO,float smallestRS,float biggestRS)
    {
        this.smallestRO = smallestRO;
        this.biggestRO = biggestRO;

        this.smallestRS = smallestRS;
        this.biggestRS = biggestRS;

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (catchGameObjects)
        {
            //Debug.Log("entered");
            if (!other.gameObject.CompareTag(orbiterObjectTag)) return;
                other.gameObject.AddComponent<Orbit>();
                Orbit tempO = other.GetComponent<Orbit>();
                tempO.center = this.gameObject.transform;
                rRadius = UnityEngine.Random.Range(smallestRO, biggestRO);
                tempO.radius = rRadius;
                rSpeed = UnityEngine.Random.Range(smallestRS, biggestRS);
                tempO.rotationSpeed = rSpeed;
                tempO.radiusSpeed = 0.1f;
                other.gameObject.transform.SetParent(this.gameObject.transform);
        }
        else
        {
            other.gameObject.transform.SetParent(transform.root);
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (!catchGameObjects)
        {
            
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        
    }
}
