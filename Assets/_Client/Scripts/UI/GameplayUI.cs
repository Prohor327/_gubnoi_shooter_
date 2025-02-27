using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class GameplayUI : UIElement
{
    private VisualElement _background;
    private List<VisualElement> _playerItems = new List<VisualElement>();
    private Label _currentInteractableText;
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
    
        player.Events.OnTakenAxe += () => ChangeWeaponImage(0, player.Weapons.PreviousWeaponIndex);
        player.Events.OnTakenPistol += () => ChangeWeaponImage(1, player.Weapons.PreviousWeaponIndex);
        player.Events.OnTakenShotgun += () => ChangeWeaponImage(2, player.Weapons.PreviousWeaponIndex);
        player.Events.OnTakenHands += () => ChangeWeaponImage(3, player.Weapons.PreviousWeaponIndex);
    }

    private void ChangeWeaponImage(int weaponIndex, int previousWeaponIndex)
    {
        _playerItems[weaponIndex].style.visibility = Visibility.Visible;
        _playerItems[previousWeaponIndex].style.visibility = Visibility.Hidden;
    }

    protected override void Initialize()
    {
        base.Initialize();
        _playerItems.Add(_UIElement.Q<VisualElement>("Axe"));
        _playerItems.Add(_UIElement.Q<VisualElement>("Pistol"));
        _playerItems.Add(_UIElement.Q<VisualElement>("Shotgun"));
        _playerItems.Add(_UIElement.Q<VisualElement>("Hands"));
        _background = _UIElement.Q<VisualElement>("Background");
        _currentInteractableText = _UIElement.Q<Label>("CurrentInteractable");
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

    public void MakeScreenDark()
    {
        StartCoroutine(nameof(StartDarkenAnimation));
    }

    private IEnumerable StartDarkenAnimation()
    {
        _background.style.transitionDuration = new List<TimeValue>() { new TimeValue(2) };
        _background.style.backgroundColor = new Color(0, 0, 0, 0);
        yield return null;
        _background.style.backgroundColor = new Color(0, 0, 0, 1);
    }
}
