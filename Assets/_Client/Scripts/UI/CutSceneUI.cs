using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class CutSceneUI : UIElement
{
    private VisualElement _background;

    [Inject]
    private void Constuct(GameMachine gameMachine)
    {
        gameMachine.OnStartCutScene += Open;
    }
    
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
