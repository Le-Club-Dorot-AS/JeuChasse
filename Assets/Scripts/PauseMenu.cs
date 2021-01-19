using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    void Paused()
    {
        pauseMenuUI.SetActive(true); //activer menu pause/ l'afficher
        Time.timeScale = 0;   //arrêter le temps
        gameIsPaused = true; //changer le statut du jeu (donc la variable en haut)
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false); //désactiver menu pause
        Time.timeScale = 1;   //reprendre le temps
        gameIsPaused = false; //rechanger le statut du jeu (donc la variable en haut)
    }
}

