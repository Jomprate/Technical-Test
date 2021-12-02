using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public abstract class ConstantRotAbstract : MonoBehaviour
{
    public int Axis;
    public virtual void Update ()
    {
        Rotate();
    }

    public void Rotate()
    {
        switch (Axis)
        {
            case 0: transform.Rotate (ManagerS1.BaseSpeedRot*Time.deltaTime,   0,0); 
                break;
            case 1: transform.Rotate (0,   ManagerS1.BaseSpeedRot*Time.deltaTime,0); 
                break;
            case 2: transform.Rotate (0,   0,ManagerS1.BaseSpeedRot*Time.deltaTime); 
                break;
        }
    }
}
