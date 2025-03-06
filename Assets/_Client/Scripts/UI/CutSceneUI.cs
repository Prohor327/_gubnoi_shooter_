using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class CutSceneUI : UIElement
{
    private VisualElement _background;

    protected override void Initialize()
    {
        base.Initialize();

        _background = _UIElement.Q<VisualElement>("Background");
    }

    public override void Open()
    {
        base.Open();
    }

    public void MakeScreenDark()
    {
        _background.style.backgroundColor = new Color(0, 0, 0, 1);
    }
}
