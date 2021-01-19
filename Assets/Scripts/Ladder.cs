using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
	private bool isInRange; //est-il à porté d'interaction avec l'objet
	private Player playerMovement;
	public BoxCollider2D plateforme; //surface au dessus de l'échelle

    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

   	    if(isInRange && playerMovement.isClimbing && Input.GetKeyDown(KeyCode.E)) //sortie échelle
        {
        	playerMovement.isClimbing = false;
        	plateforme.isTrigger = false;
        	return;
        }
        
        if(isInRange && Input.GetKeyDown(KeyCode.E)) //entrée échelle
        {
        	playerMovement.isClimbing = true;
        	plateforme.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
    	if (collision.CompareTag("Player"))
    	{
    		isInRange = true;

    	}

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
    	if (collision.CompareTag("Player"))
    	{
    		isInRange = false;
    		playerMovement.isClimbing = false;
    		plateforme.isTrigger = false;
    	}

    }
}
