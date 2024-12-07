using UnityEngine;
using UnityEngine.UIElements;

public abstract class UI : MonoBehaviour
{
    [SerializeField] private VisualTreeAsset _UIElementAsset;

    protected VisualElement _UIElement;
    private VisualElement _Document;

    private void Start()
    {
        _Document = GetComponent<UIDocument>().rootVisualElement;

        Initialize();
    }

    protected virtual void Initialize()
    {
        _UIElement = _UIElementAsset.CloneTree();
    }

    protected virtual void Open()
    {
        _Document.Clear();
        _Document.Add(_UIElement);
    }
}
