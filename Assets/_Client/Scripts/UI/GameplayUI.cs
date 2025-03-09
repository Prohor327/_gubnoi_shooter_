using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class GameplayUI : UIElement
{
    private VisualElement _background;
    private VisualElement _target;
    private VisualElement _axeImage;
    private VisualElement _handsImage;
    private VisualElement _pistolImage;
    private VisualElement _shotgunImage;
    private VisualElement _currentPlayerItemImage;
    private Label _interactableText;
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
    
        player.Events.OnTakenAxe += () => {
            ChangePlayerItemImage(_axeImage);
            HideTarget();
        };
        player.Events.OnTakenPistol += () => {
            ChangePlayerItemImage(_pistolImage);
            ShowPistolTarget();
        };
        player.Events.OnTakenShotgun += () => {
            ChangePlayerItemImage(_shotgunImage);
            ShowShotgunTarget();
        };
        player.Events.OnTakenHands += () => {
            ChangePlayerItemImage(_handsImage);
            HideTarget();
        };
    }

    private void ChangePlayerItemImage(VisualElement image)
    {   
        if(_currentPlayerItemImage != null)
        {
            _currentPlayerItemImage.style.visibility = Visibility.Hidden;
        }
        image.style.visibility = Visibility.Visible;
        _currentPlayerItemImage = image;
    }

    protected override void Initialize()
    {
        base.Initialize();
        _axeImage = _UIElement.Q<VisualElement>("Axe");
        _pistolImage = _UIElement.Q<VisualElement>("Pistol");
        _shotgunImage = _UIElement.Q<VisualElement>("Shotgun");
        _handsImage = _UIElement.Q<VisualElement>("Hands");
        _background = _UIElement.Q<VisualElement>("Background");
        _target = _UIElement.Q<VisualElement>("Target");
        _interactableText = _UIElement.Q<Label>("CurrentInteractable");
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
        _interactableText.text = text;
    }

    private void ClearCurrentInteractableText()
    {
        _interactableText.text = "";
    }

    public override void Open()
    {
        base.Open();
    }

    private void HideTarget()
    {
        _target.style.visibility = Visibility.Hidden;
    }

    private void ShowPistolTarget()
    {
        _target.style.visibility = Visibility.Visible;
        _target.style.rotate = new StyleRotate(new Rotate(0f));
    }

    private void ShowShotgunTarget()
    {
        _target.style.visibility = Visibility.Visible;
        _target.style.rotate = new StyleRotate(new Rotate(45f));
    }

    public void ShowOrHideSubtitres(VisualElement element, bool _bool)
    {
        if(_bool) _UIElement.Add(element);
        else _UIElement.Remove(element);
    }    
}
