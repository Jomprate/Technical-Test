using System;
using System.Collections.Generic;
using Managers;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.InputSystem;
using Weapons;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;
// ReSharper disable HeapView.BoxingAllocation
// ReSharper disable ParameterHidesMember


public class RobotShoot : MonoBehaviour
{
    public static RobotShoot instance;
    
    public static bool WeaponsActive;
    
    public static int WeaponActiveId = 0;
    

    private static Enums.SelectedProjectile _selectedProjectile;

    private SaveManager _saveManager;
    private ParabolicProjectile _parabolicProjectile;
    private OrbitProjectile _orbitProjectile;
    [SerializeField] private OrbitScriptableObject orbitScriptableObject;
    private ExplosiveProjectile _explosiveProjectile;
    [SerializeField] private ExplosiveScriptableObject explosiveScriptableObject;
    

    [Header("FRONT")]
    [SerializeField] private GameObject frontShootPointsP;
    [HideInInspector] public List<Transform> firePointsTransforms;

    [Header(" ")]
    [SerializeField] private Camera cam;
    [SerializeField] private float range;

    private Vector3 _destination;
    private float ExplosiveProjectileSpeed;
    [SerializeField] private float OrbitProjectileSpeed;
    
    private Vector3 _directionWithoutSpread;
    private Vector3 _directionWithSpread;
    private Vector3[] _directionWithoutSpreadFront = new Vector3[4];
    private Vector3[] _directionWithSpreadFront = new Vector3[4];
    private const float Spread = 0f;

    private RaycastHit _hit;

    public bool leftButtonClicked;
    

    [SerializeField] private GameObject cursor;
    [SerializeField] private LayerMask layer;

    [SerializeField] private GameObject[] weaponsPackages;
    [SerializeField] private Camera playerCamera;

    public void Initialize(ParabolicProjectile parabolicProjectile,OrbitProjectile orbitProjectile,ExplosiveProjectile explosiveProjectile,OrbitScriptableObject orbitScriptableObject,ExplosiveScriptableObject explosiveScriptableObject)
    {
        InputManager.PlayerInputs.Player.Back.performed += ctx => ChangeWeaponActive(3);
        instance = this;
        _saveManager = SaveManager.Instance;
        
        CustomVoids.GetListFromHierarchyTR(true,frontShootPointsP.transform,firePointsTransforms);
        this._parabolicProjectile = parabolicProjectile;
        this._orbitProjectile = orbitProjectile;
        this._explosiveProjectile = explosiveProjectile;
        this.orbitScriptableObject = orbitScriptableObject;
        this.explosiveScriptableObject = explosiveScriptableObject;
        
        InputManager.PlayerInputs.Player.LeftButton.performed += ctx => { OneShot(); };
        
        WeaponsActive = true;
    }

    private void OneShot()
    {
        Debug.Log("OneShot");
        RaycastChecker();
    }

    #region Change weapon Active
    public void ChangeWeaponActive(int id) {
        switch (id)
        {
            case 0:
                WeaponActiveId = 0;
                playerCamera.gameObject.SetActive(false);
                ManagerS2.PlayerCanMove = false;
                LookWithMouse.CursorState(false);
                LookWithMouse.instance.enabled = false;
                weaponsPackages[0].SetActive(true);
                weaponsPackages[1].SetActive(false);
                weaponsPackages[2].SetActive(false);
                
                break;
            case 1: WeaponActiveId = 1;
                _orbitProjectile.ModifyOrbitValues(orbitScriptableObject.smallestRadiusToOrbit,
                    orbitScriptableObject.biggestRadiusToOrbit,
                    orbitScriptableObject.smallestRotationSpeedToOrbit,
                    orbitScriptableObject.biggestRotationSpeedToOrbit);
                playerCamera.gameObject.SetActive(true);
                ManagerS2.PlayerCanMove = true;
                LookWithMouse.CursorState(true);
                LookWithMouse.instance.enabled = true;
                weaponsPackages[0].SetActive(false);
                weaponsPackages[1].SetActive(true);
                weaponsPackages[2].SetActive(false);
                
                break;
            case 2:
                WeaponActiveId = 2;
                _explosiveProjectile.ModifyProjectileConfig(explosiveScriptableObject.delay,
                    explosiveScriptableObject.explosionRadius,explosiveScriptableObject.explosionForce);
                playerCamera.gameObject.SetActive(true);
                ManagerS2.PlayerCanMove = true;
                LookWithMouse.CursorState(true);
                LookWithMouse.instance.enabled = true;
                weaponsPackages[0].SetActive(false);
                weaponsPackages[1].SetActive(false);
                weaponsPackages[2].SetActive(true);
                
                break;
            case 3:
                WeaponActiveId = 3;
                playerCamera.gameObject.SetActive(true);
                ManagerS2.PlayerCanMove = true;
                LookWithMouse.CursorState(true);
                LookWithMouse.instance.enabled = true;
                weaponsPackages[0].SetActive(false);
                weaponsPackages[1].SetActive(false);
                weaponsPackages[2].SetActive(false);
                break;
        }
    }
    #endregion
    

    // ReSharper disable Unity.PerformanceAnalysis
    private void RaycastChecker()
    {
        #region WeaponsActive

        if (!WeaponsActive) return;
            var rayMouse = cam.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(rayMouse,out var hit,1000f, layer)) {
                _destination = hit.point;
                var transform1 = transform;
                var position = transform1.position;
                Debug.DrawRay( position,  transform1.forward * 10000);
                Debug.DrawLine( position, hit.point, Color.red);
                _hit = hit;
            }
                
            for (var i = 0; i < firePointsTransforms.Count; i++)
            {
                _directionWithoutSpreadFront[i] = _destination - firePointsTransforms[i].position;
            }

            var xF = Random.Range(-Spread, Spread);
            var yF = Random.Range(-Spread, Spread);
            for (var i = 0; i < firePointsTransforms.Count; i++)
            {
                _directionWithSpreadFront[i] = _directionWithoutSpreadFront[i] + new Vector3(xF, yF, 0);
            }

            // ReSharper disable once HeapView.BoxingAllocation
            var valueF = Enum.GetName(typeof(Enums.SelectedProjectile), value: WeaponActiveId);
                
            Debug.Log("Shooting" + valueF);

            switch (WeaponActiveId)
            {
                case 0: 
                    Debug.Log(_saveManager.GetParabolicProjectileQ());
                    if (_saveManager.GetParabolicProjectileQ() <= 0)
                    {
                        Debug.Log("Dont have Parabolic Projectiles in inventory");
                    }
                    else {
                        _parabolicProjectile.EnableBehaviour(true);
                        _saveManager.SubstractParabolicProjectiles(1);
                    }
                    break;
                case 1: 
                    if (_saveManager.GetOrbiterProjectileQ() <= 0) {
                        Debug.Log("Dont have Orbiter Projectiles in inventory");
                    }
                    else {
                        _parabolicProjectile.EnableBehaviour(false);
                        OrbitProjectileSpeed = orbitScriptableObject.speedOfShoot;
                        ShotSpecificFirePoint(valueF,1,OrbitProjectileSpeed); 
                        Debug.Log("Orbiter Projectile Shot");
                        _saveManager.SubstractOrbiterProjectiles(1);
                    }
                    break;
                case 2: _saveManager.Load();
                    if (_saveManager.GetExplosiveProjectileQ() <= 0)
                    {
                        Debug.Log("Dont have Explosive Projectiles in inventory");
                    }
                    else
                    { 
                        _parabolicProjectile.EnableBehaviour(false);
                        ExplosiveProjectileSpeed = explosiveScriptableObject.speedOfShoot;
                        ShotSpecificFirePoint(valueF,2,ExplosiveProjectileSpeed);
                        SaveManager.Instance.ModifyExplosiveProjectileQ(false,1);
                    }
                    break;
                    
                case 3: _saveManager.Load();
                        

                    break;
            }
            return;
        #endregion

    }

    #region Shoot

    private void ShotSpecificFirePoint(string tagValue , int firePointID,float speed) {
        switch (firePointID) {
            case 0: SpawnProjectile(firePointsTransforms[0],tagValue,speed); break;
            case 1: SpawnProjectile(firePointsTransforms[1],tagValue,speed); break;
            case 2: SpawnProjectile(firePointsTransforms[2],tagValue,speed); break;
        }
    }

    private void SpawnProjectile(Transform firePointT ,string bulletTag,float speed)
    {
        if (_hit.collider == null) return;
            var position = firePointT.position;
            var projectile = ObjectPooler.Instance.SpawnFromPool(bulletTag, position, Quaternion.identity);
            var position1 = _hit.transform.position;
            projectile.transform.forward = position1;
            projectile.transform.LookAt( position1 * -1);
            projectile.GetComponent<Rigidbody>().velocity = (_hit.point - transform.position).normalized * speed;
    }
    
    
    
    
    #endregion

    

    

}
