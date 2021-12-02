using UnityEngine;

namespace Weapons
{
    public class ExplosiveProjectile : MonoBehaviour
    {
        private Rigidbody _rb;
        private float _countDown;
    
        public float delay = 3f;
        public float explosionRadius = 2f;
        public float explosionForce = 50f;
        public bool hasExploded = false;

        private void Start() {
            hasExploded = false;
            _countDown = delay;
            _rb = GetComponent<Rigidbody>();
        }

        private void StartCounter() => enabled = true;

        public void ModifyProjectileConfig(float delayTime,float expRadius, float expForce) {
            this.delay = delayTime;
            this.explosionRadius = expRadius;
            this.explosionForce = expForce;
        }
        private void Update() {
            _countDown -= Time.deltaTime;
            if (_countDown <= 0f) { Explode(); }
        }
        private void Explode()
        {
            hasExploded = true;
            // ReSharper disable once Unity.PreferNonAllocApi
            var objectsNearby = Physics.OverlapSphere(transform.position, explosionRadius);

            foreach (var objects in objectsNearby) {
                var tempRigidbody = objects.GetComponent<Rigidbody>();
                if (tempRigidbody != null) { tempRigidbody.
                    AddExplosionForce(explosionForce,transform.position,explosionRadius); }
            }
            Invoke(nameof(TurnOffGameObject),3F);
        }

        public void TurnOffGameObject() { hasExploded = false; gameObject.SetActive(false); }
        private void OnCollisionEnter(Collision other)
        {
            ContactPoint contact = other.contacts[0];
            transform.position = contact.point;
            OnGlued();
        }
        private void OnGlued() => StartCounter();
    }
}
