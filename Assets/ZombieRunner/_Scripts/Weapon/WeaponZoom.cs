using UnityEngine;
using Cinemachine;

namespace zombieRunner.Player
{
    public class WeaponZoom : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _fpsCamera;
        [SerializeField] private float _zoomOutFOV = 60f;
        [SerializeField] private float _zoomInFOV = 20f;

        //TODO : Mouse Senitivity
        [SerializeField] private float _zoomOutSensitivty = 2f;
        [SerializeField] private float _zoomInSensitivty = 0.5f;

         private bool _zoomedInToggle = false;

        private void Update()
        {
            FPSCameraZoom();
        }

        private void FPSCameraZoom()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("Taking input");
                if (_zoomedInToggle == false)
                {
                    _zoomedInToggle = true;
                    _fpsCamera.m_Lens.FieldOfView = _zoomInFOV;
                    Debug.Log("Camera Zoomed in");
                }
                else
                {
                    _zoomedInToggle = false;
                    _fpsCamera.m_Lens.FieldOfView = _zoomOutFOV;
                    Debug.Log("Camera Zoomed out");

                }
            }
        }
    }
}      