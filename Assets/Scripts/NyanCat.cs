using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NyanCat : MonoBehaviour
{
    public int health;
    public int damage;
    public int range;
    public GameObject player;
    public GameObject bossChest;
    public float speed;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bossChest = GameObject.FindGameObjectWithTag("BossChest");
        bossChest.SetActive(false);
    }
    private void Update()
    {
        if (health <= 0)
        {
            //SoundManager.PlaySound("DeadSound");
            Inventory.instance.AddCoins(20);
            Destroy(gameObject);
            bossChest.SetActive(true);
        }
        if (player.GetComponent<Player>().isBossFight)
        {
            Vector3 posPlayer = player.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, posPlayer, speed * Time.deltaTime);
            transform.RotateAround(transform.position, new Vector3(0, 0, 2), 20 * Time.deltaTime);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Health playerHealth = collision.transform.GetComponent<Health>();
            playerHealth.TakeDommage(damage);
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
