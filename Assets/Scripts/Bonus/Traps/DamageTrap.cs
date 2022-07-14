using UnityEngine;

namespace Ball
{
    
    public class DamageTrap : MonoBehaviour
    {
        [SerializeField] private float _damage = 3f;
        [SerializeField] private float _expHit = 1f;

        public (float damage, float expHit) GetDamage()//Tuple
        {
            return (_damage, _expHit);
        }

        private void OnCollisionEnter(Collision collision)
        {
            DamageTrap change= new DamageTrap();
            (float damage , float expHit) trapChange = change.GetDamage();
            if (collision.gameObject.TryGetComponent(out IUnit health))
            {
                health.Hit(trapChange.damage);
            }

            if (collision.gameObject.TryGetComponent(out Rigidbody rig))
            {
                rig.AddForce(transform.up * _expHit, ForceMode.VelocityChange);
                rig.AddForce(transform.forward * _expHit, ForceMode.VelocityChange);
            }
            Destroy(gameObject);
        }
        
    }
}