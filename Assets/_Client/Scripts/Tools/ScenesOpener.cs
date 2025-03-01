using UnityEngine.SceneManagement;

public class ScenesOpener
{
    public void OpenMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OpenLevel(string nameLevel)
    {
        SceneManager.LoadScene(nameLevel);
    }
}