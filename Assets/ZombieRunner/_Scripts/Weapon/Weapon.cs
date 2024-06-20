using System.Collections;
using UnityEngine;
using zombieRunner.Player;
using ZombieRunner.Enemy;
using ZombieRunner.Player;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera _fpCamera;
    [SerializeField] private float _weaponRange = 100f;
    [SerializeField] private float _damage = 30f;

    [SerializeField] private ParticleSystem _muzzleFlash;
    [SerializeField] private GameObject _hiteffect;
    [SerializeField] private float _timeBetweenShots = 0.5f;

    [SerializeField] private Ammo _ammoSlot;
    [SerializeField] private AmmoType _ammoType;

    private bool _canShoot = true;

    private void OnEnable()
    {
        _canShoot = true;
    }

    void Start()
    {
        
    }

    void Update()
    {
        WeaponShoot();
    }

    private void WeaponShoot()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Z) && _canShoot == true)
        {
            StartCoroutine(ShootRoutine());
        }
    }

    IEnumerator ShootRoutine()
    {
        _canShoot = false;
        if (_ammoSlot.GetCurrentAmmo(_ammoType) > 0)
        {
            PlayMuzzleFlash();
            _ammoSlot.ReduceCurrentAmmo(_ammoType);
            ProcessRayCast();
        }
        yield return new WaitForSeconds(_timeBetweenShots);
        _canShoot = true;
    }

    private void ProcessRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(_fpCamera.transform.position, _fpCamera.transform.forward, out hit, _weaponRange))
        {
            Debug.Log("Hitted a Object: " + hit.transform.name);
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            if (target == null)
            {
                return;
            }

            target.TakeDamage(_damage);
            Debug.Log("Shooting Enemy" + target.name);
        }
        else
        {
            return;
        }
    }

    private void PlayMuzzleFlash()
    {
        _muzzleFlash.Play();
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(_hiteffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _weaponRange);
    }
}
