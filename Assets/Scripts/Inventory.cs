using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public Text coinsCountText;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public AudioSource audioSource4;

    public bool haveInstru1 = false;
    public Image imageInstru1;
    public bool haveInstru2 = false;
    public Image imageInstru2;
    public bool haveInstru3 = false;
    public Image imageInstru3;

    public Text TabIndice;
    public int nbIndice;
    public int nbInstru;

    public static Inventory instance;
    private void Awake()
    {
        imageInstru1.enabled = false;
        imageInstru2.enabled = false;
        imageInstru3.enabled = false;
        TabIndice.enabled = false;
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Inventory dans la scene");
            return;
        }
        instance = this;
    }
    public void Update()
    {
        if (haveInstru1)
        {
            imageInstru1.enabled = true;
        }
        else if (haveInstru2)
        {
            imageInstru2.enabled = true;
        }
        else if (haveInstru3)
        {
            imageInstru3.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Z) && nbIndice>0)
        {
            if (TabIndice.enabled == true)
            {
                TabIndice.enabled = false;
            }
            else
            {
                TabIndice.enabled = true;
            }
        }
        if (nbInstru == 1)
        {
            audioSource1.mute = false;
        }else if(nbInstru == 2)
        {
            audioSource1.mute = true;
            audioSource2.mute = false;
        }
        else if(nbInstru == 3)
        {
            audioSource2.mute = true;
            audioSource3.mute = false;
        }
        else
        {
            audioSource2.mute = true;
            audioSource3.mute = true;
            audioSource1.mute = true;
        }
    }
    public void AddCoins(int count)
    {
        coinsCount += count;
        coinsCountText.text = coinsCount.ToString();
    }
    public void RemoveCoins(int count)
    {
        coinsCount -= count;
        coinsCountText.text = coinsCount.ToString();
    }
    public void AddInstru(int num)
    {
        if(num == 1)
        {
            haveInstru1 = true;
            imageInstru1.enabled = true;
            nbInstru++;
        }
        else if (num == 2)
        {
            haveInstru2 = true;
            imageInstru2.enabled = true;
            nbInstru++;
        }
        else if(num == 3)
        {
            haveInstru3 = true;
            imageInstru3.enabled = true;
            nbInstru++;
        }
    }
    public void AddPapier(string indice)
    {
        TabIndice.text += indice+"\n";
        nbIndice++;
        TabIndice.enabled = true;
    }
}
