using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class SubTitles : UIElement
{   
    [SerializeField] private GameplayUI _gameplayUI;
    private Label _title;
    private Label _text;
    private Coroutine coroutine = null;
    private SubTitlesSO _currentSubTitle;
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

    public void Printing(SubTitlesSO subTitlesSO)
    {
        Open();
        
        _text.SetEnabled(true);
        _title.SetEnabled(true);
        _currentSubTitle = subTitlesSO;

        NextText();
    }

    private void NextText()
    {
        if (coroutine == null && _indexCurrentText < _currentSubTitle.Title.Length)
        {
            _text.text = null;
            _title.text = null;
            SetTitle(_currentSubTitle.Title[_indexCurrentText]);
            PrintText(_currentSubTitle.Text[_indexCurrentText]);
            _indexCurrentText++;
        }
        else if (_indexCurrentText >= _currentSubTitle.Title.Length) Close();
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
