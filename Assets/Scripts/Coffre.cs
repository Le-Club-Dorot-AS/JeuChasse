using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        if (isInRange && Input.GetKeyDown(KeyCode.E) && !etat) //ouvre coffre
        {
            if(Inventory.instance.coinsCount < nbPieceNeedOpen)
            {
                piecesNeeds.text = "il vous manque " + nbPieceNeedOpen + " pieces";
                piecesNeeds.enabled = true;
                StartCoroutine(ErrorMessageDelay());
            }
            else
            {
                OpenChest();
                nbPieces = Random.Range(5, 11);
                piecesNeeds.text = "";
                piecesNeeds.enabled = false;
                Inventory.instance.RemoveCoins(nbPieceNeedOpen);
                Inventory.instance.AddCoins(nbPieces);
            }
        }

        if (Inventory.instance.haveInstru1 == true && Inventory.instance.haveInstru2 == true && Inventory.instance.haveInstru3 == false)
        {
            StartCoroutine(LoadScene());
        }
        else if (Inventory.instance.haveInstru1 == true && Inventory.instance.haveInstru2 == true && Inventory.instance.haveInstru3 == true)
        {
            StartCoroutine(LoadScene3());

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
            nbPieces = Random.Range(5, 11);
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
    public IEnumerator ErrorMessageDelay()
    {
        yield return new WaitForSeconds(2f);
        piecesNeeds.enabled = false;
    }

    public IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Level2");
    }

    public IEnumerator LoadScene3()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Level3");
    }
}
