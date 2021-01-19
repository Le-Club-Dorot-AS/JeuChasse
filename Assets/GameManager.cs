using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] objects;

    private void Awake()
    {
        foreach (var element in objects)
        {
            DontDestroyOnLoad(element);
        }
    }
}
