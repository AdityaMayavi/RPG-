using UnityEngine;
using zombieRunner.Player;

namespace ZombieRunner.Player
{
    public class AmmoPickUp : MonoBehaviour
    {
        [SerializeField] private int _ammoAmount = 5;
        [SerializeField] AmmoType _ammoType;

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {
                FindObjectOfType<Ammo>().IncreaseCurrentAmmo(_ammoType, _ammoAmount);
                Destroy(gameObject);                 
            }
        }
    }
}