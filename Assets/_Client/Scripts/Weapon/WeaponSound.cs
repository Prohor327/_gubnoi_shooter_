using UnityEngine;

public class WeaponSound : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _shotSound;

    public void SoundShot()
    {
        _source.PlayOneShot(_shotSound);
    }
}
