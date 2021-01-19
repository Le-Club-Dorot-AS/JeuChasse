using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public Text coinsCountText;

    public bool haveInstru1 = false;
    public Image imageInstru1;
    public bool haveInstru2 = false;
    public Image imageInstru2;
    public bool haveInstru3 = false;
    public Image imageInstru3;


    public static Inventory instance;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Inventory dans la scene");
            return;
        }
        instance = this;
    }
    public void AddCoins(int count)
    {
        coinsCount += count;
        coinsCountText.text = coinsCount.ToString();
    }
    public void AddInstru(int num)
    {
        if(num == 1)
        {
            haveInstru1 = true;
            imageInstru1.enabled = true;
        }
        else if (num == 2)
        {
            haveInstru2 = true;
            imageInstru2.enabled = true;
        }
        else if(num == 3)
        {
            haveInstru3 = true;
            imageInstru3.enabled = true;
        }
    }
}
