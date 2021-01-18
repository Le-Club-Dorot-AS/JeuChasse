using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int nbHeart;
    public Image[] hearts;
    public Sprite fullHeart;
    // Update is called once per frame
    void Update()
    {
        nbHeart = health;
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < nbHeart)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}