using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Weapons/Orbiter", order = 1)]
    public class OrbitScriptableObject : ScriptableObject
    {
        public float speedOfShoot;
        public float smallestRadiusToOrbit;
        public float biggestRadiusToOrbit;

        public float smallestRotationSpeedToOrbit;
        public float biggestRotationSpeedToOrbit;

    }
}
