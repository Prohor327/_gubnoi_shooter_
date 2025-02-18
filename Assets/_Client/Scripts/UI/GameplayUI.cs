using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class GameplayUI : UIElement
{
    private VisualElement _background;
    private Label _currentInteractableText;
    private Label _magazine;

    [Inject]
    private void Construct(GameMachine gameMachine, Player player)
    {
        gameMachine.OnStartGame += Open;
        gameMachine.OnResumeGame += Open;
        gameMachine.OnEndCutScene += Open;
        player.Events.OnStartHoverObject += ChangeCurrentInteractableText;
        player.Events.OnEndHoverObject += ClearCurrentInteractableText;
        player.Events.OnChangedAmountAmmo += ChangeMagazineText;
    }

    protected override void Initialize()
    {
        base.Initialize();
        _background = _UIElement.Q<VisualElement>("Fon");
        _currentInteractableText = _UIElement.Q<Label>("CurrentInteractable");
        _magazine = _UIElement.Q<Label>("Magazine");
    }

    private void ChangeMagazineText(string text)
    {
        _magazine.text = text;
    }

    private void ChangeCurrentInteractableText(string text)
    {
        _currentInteractableText.text = text;
    }

    private void ClearCurrentInteractableText()
    {
        _currentInteractableText.text = "";
    }
    public override void Open()
    {
        base.Open();
    }

    public void Darkness()
    {
        _background.style.backgroundColor = new Color(0,0,0,255);
    }
}
