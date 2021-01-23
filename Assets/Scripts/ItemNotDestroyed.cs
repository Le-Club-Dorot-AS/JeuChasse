using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemNotDestroyed : MonoBehaviour
{
    public GameObject[] objects;

    void Awake()
    {
        foreach (var element in objects)
        {
            DontDestroyOnLoad(element);
        }
    }

    void RemoveFromDestroy()
    {
        foreach (var element in objects)
        {
                SceneManager.MoveGameObjectToScene(element,SceneManager.GetActiveScene());
        }
    }

}
