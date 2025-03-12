using UnityEngine;
using Zenject;

public class Pickable : Interactable
{
    [SerializeField] private AudioClip _pickUpSound;

    private PlayerSound _playerSound;

    [Inject]
    protected override void Construct(Player player)
    {
        base.Construct(player);
        _playerSound = player.Sound;
    }

    public override void OnInteract()
    {
        _playerSound.PlayAudioClip(_pickUpSound);
        OnEndHover();
    }

    public override void OnStartHover()
    {
        playerEvents.OnStartHoverObject.Invoke("[E] Подобрать " + objectName);
    }
}