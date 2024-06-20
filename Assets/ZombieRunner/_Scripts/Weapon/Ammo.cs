using UnityEngine;

namespace zombieRunner.Player
{
    public class Ammo : MonoBehaviour
    {
        [SerializeField] private int _ammoAmount = 10;

        internal int GetCurrentAmmo()
        {
            return _ammoAmount;
        }

        internal void ReduceCurrentAmmo()
        {
            _ammoAmount--;
        }
    }
}