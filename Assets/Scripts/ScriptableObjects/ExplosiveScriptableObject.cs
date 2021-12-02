using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Weapons/Explosive", order = 1)]
    public class ExplosiveScriptableObject : ScriptableObject
    {
        public float explosionRadius;
        public float delay;
        public float explosionForce;
        public float speedOfShoot;

    }
}
