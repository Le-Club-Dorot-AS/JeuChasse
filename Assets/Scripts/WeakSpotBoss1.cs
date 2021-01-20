using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSpotBoss1 : MonoBehaviour
{
    public GameObject NomBoss;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            NomBoss.currentHealth = GameObject.parent.currentHealth --;
        }
    }
}
