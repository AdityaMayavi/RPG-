using UnityEngine;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float _healthPoints = 100f;

        private bool _isdead;

        public bool IsDead()
        {
            return _isdead;
        }

        internal void TakeDamage(float damage)
        {
            _healthPoints = Mathf.Max(_healthPoints - damage, 0);
            if (_healthPoints == 0)
            {
                Die();
            }
        }

        private void Die()
        {
            if ((_isdead))
            {
                return;
            }
            GetComponent<Animator>().SetTrigger("die");
        }
    }
}