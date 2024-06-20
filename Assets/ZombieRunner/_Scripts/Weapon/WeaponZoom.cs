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

        private void OnDisable()
        {
            ZoomOut();
        }

        private void FPSCameraZoom()
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (_zoomedInToggle == false)
                {
                    ZoomIn();
                }
                else
                {
                    ZoomOut();

                }
            }
        }

        private void ZoomOut()
        {
            _zoomedInToggle = false;
            _fpsCamera.m_Lens.FieldOfView = _zoomOutFOV;
        }

        private void ZoomIn()
        {
            _zoomedInToggle = true;
            _fpsCamera.m_Lens.FieldOfView = _zoomInFOV;
        }
    }
}      