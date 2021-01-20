using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public AudioClip audioMortBernard = null;
    private AudioSource perso2_AudioSource;
    // Update is called once per frame
    void Update()
    {
        perso2_AudioSource = GetComponent<AudioSource>();
        perso2_AudioSource.PlayOneShot(audioMortBernard);

        if (Input.GetKeyDown(KeyCode.R))
        {
          
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }       
    }
}
