using UnityEngine;
using Zenject;

public class Interactable : MonoBehaviour
{
    [SerializeField] private string _textShowingInUI = "Подобрать";

    private PlayerEvents _playerEvents;

    [Inject]
    private void Construct(Player player)
    {
        _playerEvents = player.Events;
    }

    public virtual void OnInteract()
    {
        _playerEvents.OnEndHoverObject.Invoke();
    }

    public virtual void OnHover() {  }

    public virtual void OnStartHover()
    {
        _playerEvents.OnStartHoverObject.Invoke("[E]" + _textShowingInUI);
    }
    
    public virtual void OnEndHover()
    {
        _playerEvents.OnEndHoverObject.Invoke();
    }
}
