using UnityEngine;

namespace RPG.General.CameraFollow
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        void  LateUpdate()
        {
            FollowPlayer(); 
        }

        private void FollowPlayer()
        {
            transform.position = _target.position;
        }
    }
}