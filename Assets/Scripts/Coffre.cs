using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coffre : MonoBehaviour
{
    private bool isInRange; //est-il à porté d'interaction avec l'objet
    public Text interactUI;
    public bool etat; //ouvert ou fermer
    public int contenu;//1 = intru1, 2 = instru2, 3 = intru3, 4 = pieces
    public int nbPieces;

    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E) && !etat) //ouvre coffre
        {
            if (contenu == 1 || contenu == 2 || contenu == 3) {
                Inventory.instance.AddInstru(contenu);
            }
            else
            {
                nbPieces = Random.Range(5, 21);
                Inventory.instance.AddCoins(nbPieces);
            }
            etat = true;
            animator.SetBool("etat", etat);
        }
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
