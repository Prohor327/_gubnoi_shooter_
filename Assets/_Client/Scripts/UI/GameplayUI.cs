using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class GameplayUI : UIElement
{
    private VisualElement _background;
    private Label _currentInteractableText;
    private Label _currentTakeableText;
    private Label _magazine;

    [Inject]
    private void Construct(GameMachine gameMachine, Player player)
    {
        gameMachine.OnStartGame += Open;
        gameMachine.OnResumeGame += Open;
        gameMachine.OnEndCutScene += Open;

        player.Events.OnStartHoverObject += OnStartHoverObject;
        player.Events.OnEndHoverObject += ClearCurrentInteractableText;

        player.Events.OnChangedAmountAmmo += ChangeMagazineText;

        //player.Events.OnTakenItem += () => ChangeCurrentInteractableText("[F] Отпустить предмет \n[ЛКМ] Бросить предмет");
    }

    protected override void Initialize()
    {
        base.Initialize();
        _background = _UIElement.Q<VisualElement>("Background");
        _currentInteractableText = _UIElement.Q<Label>("CurrentInteractable");
        _currentTakeableText = _UIElement.Q<Label>("CurrentTakeable");
        _magazine = _UIElement.Q<Label>("Magazine");
    }

    private void ChangeMagazineText(string text)
    {
        _magazine.text = text;
    }

    private void OnStartHoverObject(string text)
    {
        ChangeCurrentInteractableText(text);
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
        StartCoroutine(nameof(InDarkness));
    }

    IEnumerable InDarkness()
    {
        _background.style.transitionDuration = new List<TimeValue>() { new TimeValue(2) };
        _background.style.backgroundColor = new Color(0, 0, 0, 0);
        yield return null;
        _background.style.backgroundColor = new Color(0, 0, 0, 1);
    }
}
