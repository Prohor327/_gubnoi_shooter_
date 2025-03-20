using UnityEngine.SceneManagement;
using AsyncOperation = UnityEngine.AsyncOperation;

public class ScenesOpener
{
    private AsyncOperation _loadingLevel;

    public void OpenMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadLevel(string nameLevel)
    {
        _loadingLevel = SceneManager.LoadSceneAsync(nameLevel);
        _loadingLevel.allowSceneActivation = false;
    }

    public void OpenLevel()
    {
        _loadingLevel.allowSceneActivation = true;  
    }
}