using Unity.VisualScripting;
using UnityEngine;
using Zenject;

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

    private PlayerSound _playerSound;

    public void Initialize(PlayerSound playerSound)
    {
        _playerSound = playerSound;
    }

    public void SoundShot()
    {
        _playerSound.AudioSource.PlayOneShot(_shotSound);
    }

    public void SoundShotWithoutBullets()
    {
        if(!_playerSound.AudioSource.isPlaying)
        {
            _playerSound.AudioSource.PlayOneShot(_shotWithounBulletsSound);
        }
    }

    public void SoundOpenGate()
    {
        _playerSound.AudioSource.PlayOneShot(_openGate);
    }
    
    public void SoundCloseGate()
    {
        _playerSound.AudioSource.PlayOneShot(_closeGate);
    }

    public void SoundLoadBullet()
    {
        _playerSound.AudioSource.PlayOneShot(_loadBullet);
    }

    public void SoundPutAwayMagazine()
    {
        _playerSound.AudioSource.PlayOneShot(_putAwayMagazine);
    }

    public void SoundPutMagazine()
    {
        _playerSound.AudioSource.PlayOneShot(_putMagazine);
    }

    public void SoundPistolGate()
    {
        _playerSound.AudioSource.PlayOneShot(_pistolGate);
    }

    public void SoundFootstep()
    {
        _playerSound.SoundFootstep();
    }
}
