using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyPat : MonoBehaviour
{
public float speed; // La vitesse de déplacement l'ennemie
public Transform[] waypoints; // définit les points que l'ennemie devra rejoindre.
public SpriteRenderer graphs;
public int damageDeal = 1;
public bool isStone = false;

private Transform target; //définit la cible où il va se déplacer
private int destPoint = 0; // 0 réfèrera à sa position initial.

void Start() //définira le départ
{
	target = waypoints[0]; //L'ennemie ne bougera pas
}

void Update() //définira les déplacements
{
       if (!isStone)
       {
           Vector3 dir = target.position - transform.position; //le vecteur est la trajectoire entre un point A et un point B
	       transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

	        if (Vector3.Distance(transform.position, target.position) < 0.3f) // dés que l'ennemie s'approche de la destination, nous refixons une nouveau point de destination pour qu'il ne s'arrête pas.
	        {
		        destPoint = (destPoint + 1) % waypoints.Length; //permettra de faire patrouiller lenemie.
		        target = waypoints[destPoint];
		        graphs.flipX = !graphs.flipX;
	        }
       }
}
    public void stoneEnnemy()
    {
        //Debug.Log("stone");
        isStone = true;
        StartCoroutine(StoneDelay());
    }
    public IEnumerator StoneDelay()
    {
        yield return new WaitForSeconds(2f);
        isStone = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Health playerHealth = collision.transform.GetComponent<Health>();
            playerHealth.TakeDommage(damageDeal);
        }else if (collision.transform.CompareTag("Projectile"))
        {
            stoneEnnemy();
        }
    }

}