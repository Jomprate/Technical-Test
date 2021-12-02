using System;
using UnityEngine;

public abstract class PositionResetAbs : MonoBehaviour
{
    public Transform initialPos;
    public Vector3 iPos;
    

    public void Awake() {
        var objTransform = this.transform;
        initialPos = objTransform;
        initialPos.position = objTransform.position;
        iPos = initialPos.position;
    }

    public void ResetPosition()
    {
        this.transform.position = iPos;
    }
}
