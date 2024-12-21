using UnityEngine;
using UnityEngine.UIElements;

public abstract class UIElement : MonoBehaviour
{
    [SerializeField] private VisualTreeAsset _asset;

    protected VisualElement _container;

    private VisualElement _document;

    private void Start()
    {
        _document = GetComponent<UIDocument>().rootVisualElement;

        Initialize();
    }

    protected virtual void Initialize()
    {
        _container = _asset.CloneTree();
    }

    public virtual void Open()
    {
        _document.Clear();
        _document.Add(_container);
    }
}
