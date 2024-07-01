using UnityEngine;
using UnityEngine.Playables;

namespace RPG.Cinematics
{
    public class CinematicsTrigger : MonoBehaviour
    {
        private PlayableDirector _playableDirector;

        private bool _alreadyTrigged = false;

        private void Start()
        {
            _playableDirector = GetComponent<PlayableDirector>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!_alreadyTrigged && other.gameObject.tag =="Player")
            {
                _alreadyTrigged = true; 
                _playableDirector.Play();

            }
        }
    }
}