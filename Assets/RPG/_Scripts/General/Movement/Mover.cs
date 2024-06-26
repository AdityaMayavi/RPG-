
using RPG.Core;
using System;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour, IAction
    {
        private NavMeshAgent _navMeshAgent;
        private Animator _animator;
        private Ray _lastRay;

        private ActionScheduler _actionScheduler;

        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
            _actionScheduler = GetComponent<ActionScheduler>();
        }

        private void Update()
        {
            UpdateAnimator();
        }

        internal void StartMoveAction(Vector3 destination)
        {
            _actionScheduler.StartAction(this);
            MoveTo(destination);
        }

        internal void MoveTo(Vector3 destination)
        {
            _navMeshAgent.destination = destination; 
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