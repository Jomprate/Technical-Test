using System.Collections.Generic;
using UnityEngine;

public class ResetSceneries : MonoBehaviour
{
    #region Fields
    [SerializeField] public ObjectPooler objectPooler;
    [SerializeField] private GameObject wep2P;
    [SerializeField] private GameObject wep3P;
    
    [SerializeField] private PositionReset[] positionResetGameObjects;
    // ReSharper disable once NotAccessedField.Local
    [SerializeField] private Orbit[] orbitsS;
    [SerializeField] private OrbitProjectile[] orbitProjectiles;
    [SerializeField] private ID1[] id1;
    [SerializeField] private ID2[] id2;

    [HideInInspector] public List<GameObject> spheresSt1;
    [HideInInspector] public List<GameObject> spheresSt2;
    #endregion

    //Start Method
    private void Start() {
        InputManager.PlayerInputs.Player.ResetScenery.performed += context => TurnOffAllProjectiles();
    }

    //Used for Reset Active Scenery
    private void TurnOffAllProjectiles() {
        positionResetGameObjects = FindObjectsOfType<PositionReset>();
        orbitProjectiles = FindObjectsOfType<OrbitProjectile>();
        id1 = FindObjectsOfType<ID1>();
        id2 = FindObjectsOfType<ID2>();

        foreach (var orbitProjectile in orbitProjectiles) { orbitProjectile.catchGameObjects = false; }
        foreach (var id1S in id1) { spheresSt1.Add(id1S.gameObject); Destroy(id1S.gameObject.GetComponent<Orbit>()); }
        foreach (var st1GameObject in spheresSt1) { st1GameObject.transform.SetParent(wep2P.transform); }
        foreach (var id2S in id2) { spheresSt2.Add(id2S.gameObject);
            if (id2S.gameObject.GetComponent<Rigidbody>() == null) continue;
                id2S.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0.0f,0.0f,0.0f);
                id2S.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f,0.0f,0.0f);
                id2S.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0.0f,0.0f,0.0f);
        }
        foreach (var st2GameObject in spheresSt2) { st2GameObject.transform.SetParent(wep3P.transform); }
        foreach (var positionReset in positionResetGameObjects) { positionReset.ResetPosition(); }
        objectPooler.SetActiveFalseAll();
    }
    
    //Used for Use TurnOff Method
    private void OnTriggerEnter(Collider other) { TurnOffAllProjectiles(); }
}
