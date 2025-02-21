using UnityEngine;
using Zenject;

public class Interactable : MonoBehaviour
{
    [SerializeField] private string _name = "Патрон";
    [SerializeField] private AudioClip _interactSound;

    private PlayerEvents _playerEvents;
    private PlayerSound _playerSound;

    [Inject]
    private void Construct(Player player)
    {
        _playerEvents = player.Events;
        _playerSound = player.Sound;
    }

    public virtual void OnInteract()
    {
        _playerEvents.OnEndHoverObject.Invoke();
        _playerSound.PlayAudioClip(_interactSound);
    }

    public virtual void OnHover() {  }

    public virtual void OnStartHover()
    {
        _playerEvents.OnStartHoverObject.Invoke("[E] " + _name);
    }
    
    public virtual void OnEndHover()
    {
        _playerEvents.OnEndHoverObject.Invoke();
    }
}
