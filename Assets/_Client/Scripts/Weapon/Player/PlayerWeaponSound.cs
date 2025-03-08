using UnityEngine;
using Zenject;

[RequireComponent(typeof(AudioSource))]
public class PlayerWeaponSound : MonoBehaviour
{
    [SerializeField] private AudioClip _shotSound;
    [SerializeField] private AudioClip _shotWithounBulletsSound;
    [SerializeField] private AudioClip _openGate;
    [SerializeField] private AudioClip _closeGate;
    [SerializeField] private AudioClip _loadBullet;
    [SerializeField] private AudioClip _putAwayMagazine;
    [SerializeField] private AudioClip _putMagazine;
    [SerializeField] private AudioClip _pistolGate;

    private AudioSource _source;
    private PlayerSound _playerSound;

    public void Initialize(PlayerSound playerSound)
    {
        _playerSound = playerSound;
        _source = GetComponent<AudioSource>();
    }

    public void SoundShot()
    {
        _source.PlayOneShot(_shotSound);
    }

    public void SoundShotWithoutBullets()
    {
        if(!_source.isPlaying)
        {
            _source.PlayOneShot(_shotWithounBulletsSound);
        }
    }

    public void SoundOpenGate()
    {
        _source.PlayOneShot(_openGate);
    }
    
    public void SoundCloseGate()
    {
        _source.PlayOneShot(_closeGate);
    }

    public void SoundLoadBullet()
    {
        _source.PlayOneShot(_loadBullet);
    }

    public void SoundPutAwayMagazine()
    {
        _source.PlayOneShot(_putAwayMagazine);
    }

    public void SoundPutMagazine()
    {
        _source.PlayOneShot(_putMagazine);
    }

    public void SoundPistolGate()
    {
        _source.PlayOneShot(_pistolGate);
    }

    public void SoundFootstep()
    {
        _playerSound.SoundFootstep();
    }
}
