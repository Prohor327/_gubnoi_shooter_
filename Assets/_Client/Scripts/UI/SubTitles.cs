using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class SubTitles : UIElement
{   
    [SerializeField] private GameplayUI _gameplayUI;
    private Label _title;
    private Label _text;
    private Coroutine coroutine = null;
    private SubTitresSO _currentSubTitle;
    private int _indexCurrentText = 0;

    protected override void Initialize()
    {
        base.Initialize();

        _title = _UIElement.Q<Label>("Title");
        _text = _UIElement.Q<Label>("Text");
    }

    public override void Open()
    {
        _gameplayUI.ShowOrHideSubtitres(_UIElement, true);
    }

    public void Printing(SubTitresSO subTitresSO)
    {
        Open();
        
        _text.SetEnabled(true);
        _title.SetEnabled(true);
        _currentSubTitle = subTitresSO;

        NextText();
    }

    private void NextText()
    {
        if (coroutine == null && _indexCurrentText < _currentSubTitle.GetTitle().Length)
        {
            _text.text = null;
            _title.text = null;
            SetTitle(_currentSubTitle.GetTitle()[_indexCurrentText]);
            PrintText(_currentSubTitle.GetText()[_indexCurrentText]);
            _indexCurrentText++;
        }
        else if (_indexCurrentText >= _currentSubTitle.GetTitle().Length) Close();
    }

    private void SetTitle(string title)
    {
        _title.text = title;
    }

    private void PrintText(string text)
    {
        coroutine = StartCoroutine(Text(text));
    }

    private void Close()
    {
        _indexCurrentText = 0;
        _gameplayUI.ShowOrHideSubtitres(_UIElement, false);
    }

    IEnumerator Text(string text)
    {
        foreach (var sym in text)
        {
            _text.text += sym;
            yield return new WaitForSeconds(.1f);
        }
        coroutine = null;
        yield return new WaitForSeconds(.4f);
        NextText();
    }

}
