using UnityEngine;
using Zenject;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] private AudioClip[] _footstepsGravel;
    [SerializeField] private AudioClip[] _footstepsWood;
    [SerializeField] private AudioClip[] _footstepsTiles;
    [SerializeField] private AudioClip[] _footstepsFloor;

    private AudioSource _source;
    private GroundChecker _groundChecker;

    public AudioSource AudioSource => _source;

    [Inject]
    private void Construct(GroundChecker groundChecker)
    {
        _groundChecker = groundChecker;
    }

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    public void SoundFootstep()
    {
        switch(_groundChecker.CurrentGroundType)
        {
            case GroundType.None:
            return;

            case GroundType.Gravel:
                _source.PlayOneShot(_footstepsGravel[Random.Range(0, _footstepsGravel.Length)]);
            break;

            case GroundType.Tiles:
                _source.PlayOneShot(_footstepsTiles[Random.Range(0, _footstepsTiles.Length)]);
            break;

            case GroundType.Floor:
                _source.PlayOneShot(_footstepsFloor[Random.Range(0, _footstepsFloor.Length)]);
            break;
            
            case GroundType.Wood:
                _source.PlayOneShot(_footstepsWood[Random.Range(0, _footstepsWood.Length)]);
            break;
        }
    }
}