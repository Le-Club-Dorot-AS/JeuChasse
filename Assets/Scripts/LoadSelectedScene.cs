using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadSelectedScene : MonoBehaviour
{
<<<<<<< Updated upstream
    public string SceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneName);
=======
    public string sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
>>>>>>> Stashed changes
        }
    }

}
