using UnityEngine;

namespace ZombieRunner.Player
{
    public class PlayerCameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _targetObejct; // Reference to the player object
        [SerializeField] private float _smoothSpeed = 0.125f; // Adjusts camera smoothness
        [SerializeField] private Vector3 _offset; // Camera offset relative to the player

        void LateUpdate()
        {
            CameraFollow();
        }

        private void CameraFollow()
        {
            if (_targetObejct != null)
            {
                Vector3 desiredPosition = _targetObejct.position + _offset;
                transform.position = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);

                // Lock camera rotation to follow player's X-axis rotation (looking up/down)
                transform.rotation = Quaternion.Euler(0f, _targetObejct.rotation.eulerAngles.y, 0f);
            }
        }
    }
}