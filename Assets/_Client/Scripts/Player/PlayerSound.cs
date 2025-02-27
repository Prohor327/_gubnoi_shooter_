using UnityEngine;
using Zenject;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] private AudioClip[] _footstepsGravel;
    [SerializeField] private AudioClip[] _footstepsWood;
    [SerializeField] private AudioClip[] _footstepsTiles;
    [SerializeField] private AudioClip[] _footstepsFloor;
    [SerializeField] private AudioClip _jump;
    [SerializeField] private AudioClip _landing;
    [SerializeField] private float _walkRate;

    private bool _isWalkInUpdate;
    private AudioSource _source;
    private GroundChecker _groundChecker;
    private float _nextStep;
    private Player _player;

    public AudioSource AudioSource => _source;

    public void Initialize(GroundChecker groundChecker, Player player)
    {
        _groundChecker = groundChecker;
        _player = player;
        _player.Events.OnTakenHands += () => { _isWalkInUpdate = true; };
        _player.Events.OnTakenAnyWeapon += () => { _isWalkInUpdate = false; };
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

    private void Update()
    {
        if(_isWalkInUpdate && _player.State == PlayerState.Move)
        {
            Walk();
        }
    }

    private void Walk()
    {
        if(Time.time >= _nextStep)
        {
            _nextStep = Time.time + _walkRate;
            SoundFootstep();
        }
    }

    public void PlayAudioClip(AudioClip clip)
    {
        _source.PlayOneShot(clip);
    }

    public void SoundJump()
    {
        PlayAudioClip(_jump);
    }

    public void SoundLanding()
    {
        PlayAudioClip(_landing);
    }
}