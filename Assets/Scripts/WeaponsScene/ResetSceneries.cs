using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ResetSceneries : MonoBehaviour
{
    [SerializeField] public ObjectPooler objectPooler;

    [SerializeField] public PositionReset _positionReset;
    
    private readonly string WeaponSce1S = "WeaponSce1";
    private readonly string WeaponSce2S = "WeaponSce2";
    private readonly string WeaponSce3S = "WeaponSce3";

    [SerializeField] private GameObject wep2P;
    [SerializeField] private GameObject wep3P;
    
    
    [SerializeField] private PositionReset[] positionResetGameObjects;
    [SerializeField] private Orbit[] orbitsS;
    [SerializeField] private OrbitProjectile[] orbitProjectiles;
    [SerializeField] private ID1[] _id1;
    [SerializeField] private ID2[] _id2;

    [HideInInspector] public List<GameObject> spheresSt1;
    [HideInInspector] public List<GameObject> spheresSt2;


    private void Start()
    {
        InputManager.PlayerInputs.Player.ResetScenery.performed += context => TurnOffAllProjectiles();
    }

    private void TurnOffAllProjectiles()
    {
        positionResetGameObjects = FindObjectsOfType<PositionReset>();
        orbitProjectiles = FindObjectsOfType<OrbitProjectile>();
        _id1 = FindObjectsOfType<ID1>();
        _id2 = FindObjectsOfType<ID2>();

        foreach (var orbitProjectile in orbitProjectiles) { orbitProjectile.catchGameObjects = false; }
        foreach (var id1 in _id1) { spheresSt1.Add(id1.gameObject); Destroy(id1.gameObject.GetComponent<Orbit>()); }
        foreach (var st1GameObject in spheresSt1) { st1GameObject.transform.SetParent(wep2P.transform); }
        foreach (var id2 in _id2) { spheresSt2.Add(id2.gameObject);
            if (id2.gameObject.GetComponent<Rigidbody>() == null) continue;
                id2.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0.0f,0.0f,0.0f);
                id2.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f,0.0f,0.0f);
                id2.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0.0f,0.0f,0.0f);
        }
        foreach (var st2GameObject in spheresSt2) { st2GameObject.transform.SetParent(wep3P.transform); }
        foreach (var positionReset in positionResetGameObjects) { positionReset.ResetPosition(); }
        objectPooler.SetActiveFalseAll();
    }

    private void OnTriggerEnter(Collider other) { TurnOffAllProjectiles(); }
}
