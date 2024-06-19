using UnityEngine;
using ZombieRunner.Enemy;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera _fpCamera;
    [SerializeField] private float _range = 100f;
    [SerializeField] private float _damage = 30f;

    [SerializeField] private ParticleSystem _muzzleFlash;
    [SerializeField] private GameObject _hiteffect;
    
    void Start()
    {
        
    }

    void Update()
    {
        WeaponShoot();
    }

    private void WeaponShoot()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRayCast();
    }

    private void ProcessRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(_fpCamera.transform.position, _fpCamera.transform.forward, out hit, _range))
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
        Destroy(impact, 1f);
    }
}
