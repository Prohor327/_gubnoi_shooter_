using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] private AudioSource _source;   
    [SerializeField] private AudioClip[] _walkClips;

    public void SoundWalk()
    {
        _source.PlayOneShot(_walkClips[Random.Range(0, _walkClips.Length)]);
    }
}