using System;
using ScriptableObjects;
using UnityEngine;
using Weapons;

namespace Managers
{   
    [DefaultExecutionOrder(-95)]
    public class ManagerS2 : MonoBehaviour
    {
        public static ManagerS2 instance;
        
        public static bool PlayerCanMove = true;
        
        [SerializeField] private RobotShoot robotShoot;
        [SerializeField] private ObjectPooler objectPooler;
        [SerializeField] private ParabolicProjectile parabolicProjectile;
        [SerializeField] private OrbitProjectile orbitProjectile;
        [SerializeField] private ExplosiveProjectile explosiveProjectile;
        
        [SerializeField] private GameObject bulletContainer;
        [SerializeField] public SaveManager saveManager;
        [SerializeField] public static SaveManager SaveManagerS;

        [SerializeField] private Collider[] weaponsCollider; 


        [SerializeField] private OrbitScriptableObject orbitScriptableObject;
        [SerializeField] private ExplosiveScriptableObject explosiveScriptableObject;
        


        private void Awake()
        {
            
        }

        private void Start()
        {
            instance = this;
            saveManager = SaveManager.Instance;
            SaveManagerS = saveManager;
            saveManager.AddParabolicProjectile(10000);
            saveManager.AddOrbitterProjectiles(10000);
            saveManager.AddExplosiveProjectiles(10000);
            saveManager.Save();
            
            ChangeGameState(Enums.StateWeaponsScene.Initialization);
        }

       
        
        private void ChangeGameState(Enums.StateWeaponsScene gameState)
        {
            switch (gameState)
            {
                case Enums.StateWeaponsScene.Initialization:
                    InputManager.Awake();
                    
                    objectPooler.Initialize();
                    robotShoot.Initialize(parabolicProjectile,orbitProjectile,explosiveProjectile,
                        orbitScriptableObject,explosiveScriptableObject);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameState), gameState, null);
            }
        }
    
        
        
    }
}
