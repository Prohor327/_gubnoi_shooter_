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

    public virtual void OnInteract() {   }

    public virtual void OnHover() {  }

    public virtual void OnStartHover() {   }
    
    public virtual void OnEndHover()
    {
        playerEvents.OnEndHoverObject.Invoke();
    }
}
