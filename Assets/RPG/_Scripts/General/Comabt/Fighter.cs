using RPG.Core;
using RPG.Movement;
using UnityEngine;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] private float _weaponRange = 2f;
        [SerializeField] private float _timeBetweenAttacks = 1f;
        [SerializeField] private float _weaponDamage = 5f;

        private Health _target;
        private float _timeSinceLastAttack = 0;

        private Mover _mover;
        private ActionScheduler _actionScheduler;

        private Animator _animator;

        private void Start()
        {
            _mover = GetComponent<Mover>();
            _actionScheduler = GetComponent<ActionScheduler>();
            _target = GetComponent<Health>();
            Debug.Log(gameObject + _target.name);
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            FightMoveCheck();
        }

        private void FightMoveCheck()
        {
            _timeSinceLastAttack += Time.deltaTime;

            if (_target == null)
            {
                return;
            }

            if (_target.IsDead())
            {
                return;
            }

            if (!GetInRange())
            {
                _mover.MoveTo(_target.transform.position);
            }
            else
            {
                _mover.Cancel();
                //AttackBehaviour();
            }
        }

        private void AttackBehaviour()
        {
            transform.LookAt(_target.transform);
            if (_timeSinceLastAttack > _timeBetweenAttacks)
            {
                //this will trigger the Hit() event
                TriggerAttack();
                _timeSinceLastAttack = 0;
            }
        }

        private void TriggerAttack()
        {
            _animator.SetTrigger("stopAttack");
            _animator.SetTrigger("attack");
        }

        //Animation Event
        public void Hit()
        {
            if (_target == null)
            {
                return;
            }
            _target.TakeDamage(_weaponDamage);
        }

        private bool GetInRange()
        {
            return Vector3.Distance(transform.position, _target.transform.position) < _weaponRange;
        }

        public bool CanAttack(GameObject combatTarget)
        {
            if (combatTarget == null)
            {
                return false;
            }
            Health targetToTest = combatTarget.GetComponent<Health>();
            return targetToTest != null && !targetToTest.IsDead();
        }

        internal void Attack(GameObject combatTarget)
        {
            _actionScheduler.StartAction(this);
            _target = combatTarget.GetComponent<Health>();
            print("Take that  you short");
        }

        public void Cancel()
        {
            StopAttack();
            _target = null;
        }

        private void StopAttack()
        {
            _animator.SetTrigger("attack");
            _animator.SetTrigger("stopAttack");
        }
    }
}