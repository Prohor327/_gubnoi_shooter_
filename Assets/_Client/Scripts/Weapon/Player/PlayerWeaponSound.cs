using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class PlayerWeaponSound : MonoBehaviour
{
    [SerializeField] private AudioClip _shotSound;

    private PlayerSound _playerSound;

    public void Initialize(PlayerSound playerSound)
    {
        _playerSound = playerSound;
    }

    public void SoundShot()
    {
        _playerSound.AudioSource.PlayOneShot(_shotSound);
    }

    public void SoundFootstep()
    {
        _playerSound.SoundFootstep();
    }
}
