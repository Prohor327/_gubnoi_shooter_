using UnityEngine;

public class Security : MonoBehaviour, IInteract
{
    public void CursorOnObject()
    {
        print("Security");
    }

    public void Interact()
    {
        print("Say");
    }
}
