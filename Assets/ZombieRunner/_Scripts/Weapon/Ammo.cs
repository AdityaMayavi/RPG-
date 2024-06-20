using System;
using Unity.VisualScripting;
using UnityEngine;
using ZombieRunner.Player;

namespace zombieRunner.Player
{
    public class Ammo : MonoBehaviour
    {
        [SerializeField] Ammoslot[] ammoSlots;

        [System.Serializable]
        private class Ammoslot
        {
            public AmmoType ammoType;
            public int ammoAmount;
        }

        internal int GetCurrentAmmo(AmmoType ammoType)
        {
            return GetAmmoSlot(ammoType).ammoAmount;
        }

        internal void ReduceCurrentAmmo(AmmoType ammoType)
        {
            GetAmmoSlot(ammoType).ammoAmount--;
        } 
        internal void IncreaseCurrentAmmo(AmmoType ammoType, int ammountAmount)
        {
            GetAmmoSlot(ammoType).ammoAmount += ammountAmount;
        }

        private Ammoslot GetAmmoSlot(AmmoType ammoType)
        {
            foreach (Ammoslot slot in ammoSlots)
            {
                if(slot.ammoType == ammoType)
                {
                    return slot;
                }
            }
            return null;
        }
    }
}