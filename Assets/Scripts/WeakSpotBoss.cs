﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSpotBoss : MonoBehaviour
{
 public GameObject damage;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            damage = GameObject.currentHealth - 1;
        }
    }
}
