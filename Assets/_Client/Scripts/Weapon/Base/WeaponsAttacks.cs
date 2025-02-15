using System;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;
using Zenject;

namespace WeaponsAttacks
{
    public abstract class Attack
    {
        public abstract void PerformAttack();
    }

    public class OverlapAttack : Attack
    {
        public event Action<IWeaponVisitor> AcceptVisit;

        private OverlapSettings _settings;

        public OverlapAttack(OverlapSettings overlapSettings)
        {
            _settings = overlapSettings;
        }

        public override void PerformAttack()
        {
            Collider[] hitColliders = new Collider[_settings.MaxAmountColliders];
            int amountColliders = Physics.OverlapSphereNonAlloc(_settings.OverlapPoint.position, _settings.AttackRange, hitColliders);
            TryPerformAttack(hitColliders, amountColliders);
        }

        private void TryPerformAttack(Collider[] colliders, int amountColliders)
        {
            for(int i = 0; i < amountColliders; i++)
            {
                TryAcceptWeaponVisitor(colliders[i]);
            }
        }

        protected virtual void TryAcceptWeaponVisitor(Collider collider)
        {
            if(collider.gameObject.TryGetComponent(out IWeaponVisitor weaponVisitor))
            {
                AcceptVisit?.Invoke(weaponVisitor);
            }
        }
    }

    public class RaycastAttack : Attack
    {
        public event Action<IWeaponVisitor, RaycastHit> AcceptVisit;

        private RaycastSetting _settings;

        public RaycastAttack(RaycastSetting raycastSetting)
        {
            _settings = raycastSetting;
        }

        public override void PerformAttack()
        {
            if (Physics.Raycast(_settings.Direction.position, _settings.Direction.forward, out RaycastHit hit, _settings.Distance))
            {
                HitScan(hit);
            }
        }

        private void HitScan(RaycastHit hit)
        {
            if(hit.transform.gameObject.TryGetComponent<IWeaponVisitor>(out IWeaponVisitor weaponVisitor))
            {
                AcceptVisit?.Invoke(weaponVisitor, hit);
            }
        }
    }

    public class ProjectileAttack : Attack
    {
        private ProjectileWeaponSettings _settings;

        public ProjectileAttack(ProjectileWeaponSettings settings)
        {
            _settings = settings;
        }

        public override void PerformAttack()
        {
            // GameObject projectile = MonoBehaviour.Instantiate(_settings.Projectile.gameObject,
            //  _settings.SpawnPointProjectile.position, Quaternion.identity);
            //projectile.GetComponent<Projectile>().Run(_settings.SpawnPointProjectile.TransformDirection(Vector3.right * _settings.ForceRunProjectile));
        }
    }


    [Serializable]
    public class WeaponSettings {   }

    [Serializable]
    public class DamagingWeaponSetting : WeaponSettings
    {
        [SerializeField] private float _damage;

        public float Damage => _damage;
    }

    [Serializable]
    public class OverlapSettings : DamagingWeaponSetting
    {
        [SerializeField] private int _maxAmountColliders;
        [SerializeField] private float _attackRange;
        [SerializeField] private Transform _overlapPoint;

        public int MaxAmountColliders => _maxAmountColliders;
        public float AttackRange => _attackRange;
        public Transform OverlapPoint => _overlapPoint;
    }

    [Serializable]
    public class RaycastSetting : DamagingWeaponSetting
    {
        protected Transform _direction;
        [SerializeField] private float _distance;

        public Transform Direction => _direction;
        public float Distance => _distance;
    }

    [Serializable]
    public class PlayerRaycastSettings : RaycastSetting
    {
        public void SetDirection(Transform direction)
        {
            _direction = direction;
        }
    }

    [Serializable]
    public class ProjectileWeaponSettings : WeaponSettings
    {
        [SerializeField] protected Transform _spawnPointProjectile;
        //[SerializeField] private Projectile _projectile;
        [SerializeField] private float _forceRunProjectile;

        public Transform SpawnPointProjectile => _spawnPointProjectile;
        //public Projectile Projectile => _projectile;
        public float ForceRunProjectile => _forceRunProjectile;
    }

    [Serializable]
    public class HeartCancerProjectileWeaponSettings : ProjectileWeaponSettings
    {
        public void SetSpawnPointProjectile(Transform point)
        {
            _spawnPointProjectile = point;
        }
    }
}