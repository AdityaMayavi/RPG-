using UnityEngine;

namespace ZombieRunner.Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private float _hitPoints = 100f;

        internal void TakeDamage(float damage)
        {
            _hitPoints -= damage;

            if(_hitPoints <= 0)
            {
                Debug.Log("Taking Damage" +  _hitPoints);
                Destroy(gameObject);
            }
        }
    }
}