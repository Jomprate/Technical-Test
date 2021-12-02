using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : OrbitAbstract
{
    new void Update() {
        if (center != null)
        {
            this.gameObject.transform.RotateAround (center.position, axis, rotationSpeed * Time.deltaTime);
            var desiredPosition = (this.gameObject.transform.position - center.position).normalized * radius + center.position;
            this.gameObject.transform.position = Vector3.MoveTowards(  this.gameObject.transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
        }
        
    }
}
