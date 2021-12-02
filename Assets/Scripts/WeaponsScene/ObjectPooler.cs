using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    private Dictionary<string, Queue<GameObject>> _poolDictionary;
    
    private readonly string ParabolicProjectileS = "ParabolicProjectile";
    private readonly string OrbiterProjectileS = "OrbiterProjectile";
    private readonly string ExplosiveProjectileS = "ExplosiveProjectile";
    private readonly string SphereWoRigidbodyS = "SphereWoRB";
    private readonly string WeaponSce1S = "WeaponSce1";
    private readonly string WeaponSce2S = "WeaponSce2";
    private readonly string WeaponSce3S = "WeaponSce3";
    private readonly string BulletDecalTagS = "BulletDecal";

    [SerializeField] private GameObject bulletsContainer;
    
    [Header("GameObjects Parents to Move")]
    [SerializeField] private GameObject bulletDecalsP;
    [SerializeField] private GameObject parabolicProjectileP;
    [SerializeField] private GameObject orbiterProjectileP;
    [SerializeField] private GameObject explosiveProjectileP;

    public List<GameObject> ParabolicProjectileL;
    public List<GameObject> OrbiterProjectileL;
    public List<GameObject> ExplosiveProjectileL;

    [SerializeField] private PositionReset _positionReset;
    
    public Transform[] parabolicProjectilesPack;
    public Transform[] orbitProjectilesPack;
    public Transform[] explosiveProjectilesPack;
    
    
    #region Singleton

    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public void Initialize()
    {
        SetNeeded();
        StartProduction();
    }

    private void SetNeeded() {
        parabolicProjectileP = bulletsContainer.transform.GetChild(0).gameObject;
        
        orbiterProjectileP = bulletsContainer.transform.GetChild(1).gameObject;
        explosiveProjectileP = bulletsContainer.transform.GetChild(2).gameObject;
    }
    private void StartProduction()
    {
        _poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);

                CheckGameObjectTag(obj);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            
            _poolDictionary.Add(pool.tag,objectPool);
        }
    }
    //Set in due parents
    private void CheckGameObjectTag(GameObject obj)
    {
        if (obj.CompareTag(ParabolicProjectileS))
        {
            obj.transform.parent = parabolicProjectileP.transform;
            ParabolicProjectileL.Add(obj);
        }

        if (obj.CompareTag(OrbiterProjectileS))
        {
            obj.transform.parent = orbiterProjectileP.transform;
            OrbiterProjectileL.Add(obj);
        }

        if (obj.CompareTag(ExplosiveProjectileS))
        {
            obj.transform.parent = explosiveProjectileP.transform;
            ExplosiveProjectileL.Add(obj);
        }
        
        
    }
    //Lets use GameObjects already instantiated
    public GameObject SpawnFromPool(string wTag,Vector3 position,Quaternion rotation)
    {
        if (!_poolDictionary.ContainsKey(wTag))
        {
            Debug.LogWarning("Pool with tag " + wTag + "Doesn't exist");
            return null;
        }
        
        GameObject objectToSpawn = _poolDictionary[wTag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        
        IPooledObjects pooledObj = objectToSpawn.GetComponent<IPooledObjects>();

        if (pooledObj != null)
        {
            pooledObj.OnObjectsSpawn();
        }
        
        _poolDictionary[wTag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }


    
    public void SetActiveFalseAll()
    {
        foreach (var obj in ParabolicProjectileL) { obj.gameObject.SetActive(false); }
        parabolicProjectileP.SetActive(true); 
        
        foreach (var obj in OrbiterProjectileL) { obj.gameObject.SetActive(false); }
        orbiterProjectileP.SetActive(true);
        
        foreach (var obj in ExplosiveProjectileL) { obj.gameObject.SetActive(false); }
        explosiveProjectileP.SetActive(true);
    }
}



