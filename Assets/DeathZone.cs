using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("Player"))
        {
            Debug.Log("test");
            Health playerHealth = collision.GetComponent<Health>();
            playerHealth.TakeDommage(3);
        }
    }



}
