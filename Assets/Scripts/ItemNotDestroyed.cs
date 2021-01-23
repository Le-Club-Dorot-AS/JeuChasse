using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemNotDestroyed : MonoBehaviour
{
    public GameObject[] objects;

    public static ItemNotDestroyed instance;

    void Awake()
    {
        foreach (var element in objects)
        {
            DontDestroyOnLoad(element);
        }
    }

   

}
