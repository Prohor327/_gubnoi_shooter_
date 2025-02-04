using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class WeaponSound : MonoBehaviour
{
    [SerializeField] private AudioClip _shotSound;

    private PlayerSound _playerSound;

    [Inject]
    private void Construct(PlayerSound playerSound)
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
