using UnityEngine;

namespace RPG.Player
{
    public class PlayerCameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
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