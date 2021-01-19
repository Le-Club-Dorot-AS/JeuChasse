﻿using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadSelectedScene : MonoBehaviour
{
    public string SceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
