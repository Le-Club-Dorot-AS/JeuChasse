using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class OpeningDoor : MonoBehaviour
{
    public GameObject go;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            go.active = !go.active;          
        }
    }
}
