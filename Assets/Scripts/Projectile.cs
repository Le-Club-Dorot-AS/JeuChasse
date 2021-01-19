using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
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
        if(testNyan != null)
        {
            testNyan.TakeDamage(damage);
        }else if(testSnakeron != null)
        {
            testSnakeron.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

    }
    void DestroyProjectile()
    {
        //SoundManager.PlaySound("ExplosionSound");
        Destroy(gameObject);
    }
}
