using RPG.Control;
using RPG.Core;
using UnityEngine;
using UnityEngine.InputSystem.iOS;
using UnityEngine.Playables;

namespace RPG.Cinematics
{
    public class CinematicsControlRemover : MonoBehaviour
    {
        private GameObject _player;

        private void Start()
        {
            _player = GameObject.FindWithTag("Player");
            GetComponent<PlayableDirector>().played += DisableControl;
            GetComponent<PlayableDirector>().stopped += EnableControl;
        }

        private void Update()
        {
            
        }

        private void DisableControl(PlayableDirector playableDirector)
        {
            print("DisableControl");
            _player.GetComponent<ActionScheduler>().CancelCurrentAction();
            _player.GetComponent<PlayerController>().enabled = false;
        }

        private void EnableControl(PlayableDirector playableDirector)
        {
            print("EnableControl");
            _player.GetComponent<PlayerController>().enabled = false;

        }
    }
}