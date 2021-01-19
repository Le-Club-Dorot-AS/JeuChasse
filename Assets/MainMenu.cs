using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string LevelToLoad;

    public GameObject settingswindow;

    public void StartGame()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
    public void SettingsButton()
    {
        settingswindow.SetActive(true);
    }
    public void CloseSettingsWindow()
    {
        settingswindow.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }



}

