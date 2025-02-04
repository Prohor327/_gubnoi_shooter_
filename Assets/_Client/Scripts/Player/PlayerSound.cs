using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] private AudioClip[] _walkClips;

    private AudioSource _source;

    public AudioSource AudioSource => _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    public void SoundFootstep()
    {
        _source.PlayOneShot(_walkClips[Random.Range(0, _walkClips.Length)]);
    }
}