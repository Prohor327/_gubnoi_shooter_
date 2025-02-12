using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class GameplayUI : UIElement
{
    private VisualElement _fon;
    protected override void Initialize()
    {
        base.Initialize();
        _fon = _UIElement.Q<VisualElement>("Fon");
    }

    public override void Open()
    {
        base.Open();
    }

    public void Darkness()
    {
        _fon.style.backgroundColor = new Color(0,0,0,255);
    }
}
