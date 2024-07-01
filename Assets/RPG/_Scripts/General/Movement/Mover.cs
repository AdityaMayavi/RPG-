using RPG.Core;
using System;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour, IAction
    {

        [SerializeField] private Transform _transform;
        [SerializeField] private float _maxSpeed = 6f;

        private NavMeshAgent _navMeshAgent;
        private Animator _animator;
        private Ray _lastRay;

        private ActionScheduler _actionScheduler;
        private Health _health;

        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
            _actionScheduler = GetComponent<ActionScheduler>();
            _health = GetComponent<Health>();
        }

        private void Update()
        {
            _navMeshAgent.enabled = !_health.IsDead();
            UpdateAnimator();
        }

        internal void StartMoveAction(Vector3 destination, float speedFraction)
        {
            _actionScheduler.StartAction(this);
            MoveTo(destination, speedFraction);
        }

        internal void MoveTo(Vector3 destination,float speedFraction)
        {
            _navMeshAgent.destination = destination;
            _navMeshAgent.speed = _maxSpeed * Mathf.Clamp01(speedFraction);
            _navMeshAgent.isStopped = false;
        }

        public void Cancel()
        {
            _navMeshAgent.isStopped = true;
        }

        private void UpdateAnimator()
        {
            Vector3 velociy  = _navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velociy);
            float speed = localVelocity.z;
            _animator.SetFloat("ForwardSpeed", speed);
        }  
    }
}