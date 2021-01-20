using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float distance;
    public LayerMask whatIsSolid;
    public float lifeTime;
    public int damage;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        Invoke("DestroyProjectile", lifeTime);
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        NyanCat testNyan = hitInfo.GetComponent<NyanCat>();
        Snakeron testSnakeron = hitInfo.GetComponent<Snakeron>();
        EnnemyPat ennemy = hitInfo.GetComponent<EnnemyPat>();
        WeakSpot weak = hitInfo.GetComponent<WeakSpot>();
        if (testNyan != null)
        {
            testNyan.TakeDamage(damage);
        }else if(testSnakeron != null)
        {
            testSnakeron.TakeDamage(damage);
        }else if (weak != null)
        {
            //Debug.Log(ennemy);
            if(ennemy != null)
                ennemy.stoneEnnemy();
            else if (testNyan != null)
                testNyan.stoneEnnemy();
            else if (testSnakeron != null)
                testSnakeron.stoneEnnemy();
        }
        DestroyProjectile();
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if(hitInfo.collider != null)
        {
            //Debug.Log(hitInfo);
            if (hitInfo.collider.CompareTag("Ennemy"))
            {
                //Debug.Log(hitInfo.collider.CompareTag("Ennemy"));
                hitInfo.collider.GetComponent<EnnemyPat>().stoneEnnemy();
            }
            if (hitInfo.collider.CompareTag("Boss"))
            {
                if (hitInfo.collider.GetComponent<NyanCat>() != null)
                {
                    hitInfo.collider.GetComponent<NyanCat>().TakeDamage(damage);
                }else if (hitInfo.collider.GetComponent<Snakeron>() != null)
                {
                    hitInfo.collider.GetComponent<Snakeron>().TakeDamage(damage);
                }         
            }
            DestroyProjectile();
        }
        
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
    void DestroyProjectile()
    {
        //SoundManager.PlaySound("ExplosionSound");
        Destroy(gameObject);
    }
}
