using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coffre : MonoBehaviour
{
    private bool isInRange; //est-il à porté d'interaction avec l'objet
    public Text interactUI;
    public Text piecesNeeds;

    public bool etat; //ouvert ou fermer
    public int contenu;//1 = intru1, 2 = instru2, 3 = intru3, 4 = pieces, 5= papier
    private int nbPieces;
    public Text indice;
    public int nbPieceNeedOpen;

    public Animator animator;
    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
        interactUI.enabled = false;
        piecesNeeds.enabled = false;
    }
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E) && !etat && nbPieceNeedOpen<= Inventory.instance.coinsCount) //ouvre coffre
        {
            OpenChest();
            piecesNeeds.text = "";
            piecesNeeds.enabled = false;
        }
        else if(nbPieceNeedOpen <= Inventory.instance.coinsCount)
        {
            piecesNeeds.text = "il vous manque " + piecesNeeds + " pieces";
            piecesNeeds.enabled = true;
        }
    }
    void OpenChest()
    {
        animator.SetTrigger("OpenChest");
        if (contenu == 1 || contenu == 2 || contenu == 3)
        {
            Inventory.instance.AddInstru(contenu);
            //son instru 
        }else if(contenu == 5)
        {
            Inventory.instance.AddPapier(indice.text);
            interactUI.enabled = true;
            //son indice
        }
        else
        {
            nbPieces = Random.Range(5, 21);
            Inventory.instance.AddCoins(nbPieces);
            //son piece
        }
        etat = true;
        animator.SetBool("state", etat);
        GetComponent<BoxCollider2D>().enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            interactUI.enabled = false;
        }

    }
}
