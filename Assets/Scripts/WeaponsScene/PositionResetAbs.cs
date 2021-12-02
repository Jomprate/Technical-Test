using UnityEngine;

public abstract class PositionResetAbs : MonoBehaviour
{
    #region Fields
    public Transform initialPos;
    public Vector3 iPos;
    #endregion
    //Awake Method
    public void Awake() {
        var objTransform = this.transform;
        initialPos = objTransform;
        initialPos.position = objTransform.position;
        iPos = initialPos.position;
    }
    //Reset Sphere Positions
    public void ResetPosition() { this.transform.position = iPos; }
}
