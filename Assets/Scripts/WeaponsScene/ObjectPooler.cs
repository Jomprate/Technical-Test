using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    private Dictionary<string, Queue<GameObject>> _poolDictionary;

    private const string ParabolicProjectileS = "ParabolicProjectile";
    private const string OrbiterProjectileS = "OrbiterProjectile";
    private const string ExplosiveProjectileS = "ExplosiveProjectile";

    [SerializeField] private GameObject bulletsContainer;
    
    [Header("GameObjects Parents to Move")]
    [SerializeField] private GameObject parabolicProjectileP;
    [SerializeField] private GameObject orbiterProjectileP;
    [SerializeField] private GameObject explosiveProjectileP;

    [HideInInspector] public List<GameObject> parabolicProjectileL;
    [HideInInspector] public List<GameObject> orbiterProjectileL;
    [HideInInspector] public List<GameObject> explosiveProjectileL;

    public static ObjectPooler Instance;

    private void Awake() => Instance = this;

    public void Initialize() {
        SetNeeded();
        StartProduction();
    }
    //Set needed to the pool
    private void SetNeeded() {
        parabolicProjectileP = bulletsContainer.transform.GetChild(0).gameObject;
        orbiterProjectileP = bulletsContainer.transform.GetChild(1).gameObject;
        explosiveProjectileP = bulletsContainer.transform.GetChild(2).gameObject;
    }
    //Start the pool production
    private void StartProduction() {
        _poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools) {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++) {
                GameObject obj = Instantiate(pool.prefab);
                CheckGameObjectTag(obj);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            _poolDictionary.Add(pool.tag,objectPool);
        }
    }
    
    //Set in due parents
    private void CheckGameObjectTag(GameObject obj) {
        if (obj.CompareTag(ParabolicProjectileS)) {
            obj.transform.parent = parabolicProjectileP.transform;
            parabolicProjectileL.Add(obj);
        }
        if (obj.CompareTag(OrbiterProjectileS)) {
            obj.transform.parent = orbiterProjectileP.transform;
            orbiterProjectileL.Add(obj);
        }
        if (obj.CompareTag(ExplosiveProjectileS)) {
            obj.transform.parent = explosiveProjectileP.transform;
            explosiveProjectileL.Add(obj);
        }
    }
    
    //Lets use GameObjects already instantiated
    public GameObject SpawnFromPool(string wTag,Vector3 position,Quaternion rotation) {
        if (!_poolDictionary.ContainsKey(wTag)) {
            Debug.LogWarning("Pool with tag " + wTag + "Doesn't exist"); return null;
        }

        GameObject objectToSpawn = _poolDictionary[wTag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        
        IPooledObjects pooledObj = objectToSpawn.GetComponent<IPooledObjects>();

        if (pooledObj != null) { pooledObj.OnObjectsSpawn(); }
        
        _poolDictionary[wTag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
    
    // Set Bullets in false state expect the parent
    public void SetActiveFalseAll()
    {
        foreach (var obj in parabolicProjectileL) { obj.gameObject.SetActive(false); }
        parabolicProjectileP.SetActive(true); 

        foreach (var obj in orbiterProjectileL) { obj.gameObject.SetActive(false); }
        orbiterProjectileP.SetActive(true);
        
        foreach (var obj in explosiveProjectileL) { obj.gameObject.SetActive(false); }
        explosiveProjectileP.SetActive(true);
    }
}



