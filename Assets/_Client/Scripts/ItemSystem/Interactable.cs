using UnityEngine;
using Zenject;

public class Interactable : MonoBehaviour
{
    [SerializeField] protected string objectName = "Патрон";

    protected PlayerEvents playerEvents;

    [Inject]
    protected virtual void Construct(Player player)
    {
        playerEvents = player.Events;
    }

    public virtual void OnInteract()
    {
        playerEvents.OnEndHoverObject.Invoke();
    }

    public virtual void OnHover() {  }

<<<<<<< Updated upstream
    public virtual void OnStartHover()
    {
        _playerEvents.OnStartHoverObject.Invoke("[E] " + _name);
    }
=======
    public virtual void OnStartHover() {   }
>>>>>>> Stashed changes
    
    public virtual void OnEndHover()
    {
        playerEvents.OnEndHoverObject.Invoke();
    }
}
