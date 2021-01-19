﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snakeron : MonoBehaviour
{
    public int health;
    public float speed; // La vitesse de déplacement l'ennemie
    public Transform[] waypoints; // définit les points que l'ennemie devra rejoindre.
    public SpriteRenderer graphs;
    public GameObject player;
    public int damageDeal = 1;
    private int random;
    private bool isShooting;
    private float timeBetweenAttacks;
    public GameObject projectile;
    public Transform firePoint;

    private Transform target; //définit la cible où il va se déplacer
    private int destPoint = 0; // 0 réfèrera à sa position initial.

    void Start() //définira le départ
    {
        target = waypoints[0]; //L'ennemie ne bougera pas
    }

    void Update() //définira les déplacements
    {
        if(random > 70 && isShooting)
        {
            random = 0;
            player = GameObject.FindGameObjectWithTag("Player");
            AttackPlayer();
        }
        else
        {
            Vector3 dir = target.position - transform.position; //le vecteur est la trajectoire entre un point A et un point B
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, target.position) < 0.3f) // dés que l'ennemie s'approche de la destination, nous refixons une nouveau point de destination pour qu'il ne s'arrête pas.
            {
                destPoint = (destPoint + 1) % waypoints.Length; //permettra de faire patrouiller lenemie.
                target = waypoints[destPoint];
                graphs.flipX = !graphs.flipX;
                random = Random.Range(0, 100);
                isShooting = true;
            }
        }    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Health playerHealth = collision.transform.GetComponent<Health>();
            playerHealth.TakeDommage(damageDeal);
        }
    }
    private void AttackPlayer()
    {
        if (!isShooting)
        {
            ///Attack code here
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            ///End of attack code

            isShooting = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        isShooting = false;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
