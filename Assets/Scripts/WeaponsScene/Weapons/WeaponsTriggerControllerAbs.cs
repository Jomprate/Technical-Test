using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponsTriggerControllerAbs : MonoBehaviour
{
    private RobotShoot _robotShoot;
    [SerializeField] private int ColliderID;

    private void Start()
    {
        _robotShoot = RobotShoot.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (ColliderID)
        {
            case 0: _robotShoot.ChangeWeaponActive(0);
                break;
            case 1: _robotShoot.ChangeWeaponActive(1);
                break;
            case 2: _robotShoot.ChangeWeaponActive(2);
                break;
            
        }

    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
