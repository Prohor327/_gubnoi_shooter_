using UnityEngine;

[RequireComponent(typeof(Unit))]
public class HitBox : MonoBehaviour, IWeaponVisitor
{
    [Header("VFX")]
    [SerializeField] private Decal _particalDecal;
    [SerializeField] private BulletHole bulletHole;

    private Unit _unit;

    private void Start()
    {
        _unit = GetComponent<Unit>();
    }

    public void Visit(Pistol pistol, RaycastHit hit)
    {
        _unit.TakeDamage(pistol.Damage);
        SpawnDecals(hit);
    }

    public void Visit(Shotgun shotgun, RaycastHit hit)
    {
        _unit.TakeDamage(shotgun.Damage);
        SpawnDecals(hit);
    }
    
    public void Visit(Axe axe)
    {
        _unit.TakeDamage(axe.Damage);
    }

    private void SpawnDecals(RaycastHit hit)
    {
        //Instantiate(_particalDecal.gameObject, hit.point, Quaternion.LookRotation(hit.normal), hit.transform);
    }
}