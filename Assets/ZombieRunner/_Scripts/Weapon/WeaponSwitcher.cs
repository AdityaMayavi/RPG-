using System;
using UnityEngine;

namespace ZombieRunner.Player
{
    public class WeaponSwitcher : MonoBehaviour
    {
        [SerializeField] private int _currentWeapon;

        private void Start() 
        {
            SetActiveWeapon();
        }
        private void Update()
        {
            int previousWeapon = _currentWeapon;

            ProcessKeyInput();
            ProcessScrollWheel();

            if (previousWeapon != _currentWeapon)
            {
                SetActiveWeapon();
            }
        }

        private void ProcessKeyInput()
        {
            if(Input.GetKeyUp(KeyCode.Alpha1))
            {
                _currentWeapon = 0;
            }
            if(Input.GetKeyUp(KeyCode.Alpha2))
            {
                _currentWeapon = 1;
            }
            if(Input.GetKeyUp(KeyCode.Alpha3))
            {
                _currentWeapon = 2;
            }
        }

        private void ProcessScrollWheel()
        {
            if(Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                if(_currentWeapon >= transform.childCount - 1)
                {
                    _currentWeapon = 0;
                }
                else
                {
                    _currentWeapon++;
                }
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                if (_currentWeapon <= 0)
                {
                    _currentWeapon = transform.childCount - 1;
                }
                else
                {
                    _currentWeapon--;
                }
            }
        }

        private void SetActiveWeapon()
        {
            int weaponIndex = 0;

            foreach (Transform weapon in transform)
            {
                if(weaponIndex == _currentWeapon)
                {
                    weapon.gameObject.SetActive(true);
                }
                else
                {
                    weapon.gameObject.SetActive(false);
                }
                weaponIndex++;
            }
        }
    }
}