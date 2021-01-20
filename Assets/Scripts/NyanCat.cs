using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NyanCat : MonoBehaviour
{
    public int maxhealth;
    public int currentHealth;
    public int damage;
    public int range;
    public GameObject player;
    //public GameObject HealthBar;
    //public HealthBar bossBar;
    public GameObject bossChest;
    public float speed;
    public bool isStone;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        isStone = false;
        currentHealth = maxhealth;
        //bossBar.setMaxHealth(maxhealth);
        bossChest = GameObject.FindGameObjectWithTag("BossChest");
        bossChest.SetActive(false);
    }
    private void Update()
    {
        if (currentHealth <= 0)
        {
            //SoundManager.PlaySound("DeadSound");
            Inventory.instance.AddCoins(20);
            Destroy(gameObject);
            //bossChest.SetActive(true);
        }
        if (player.GetComponent<Player>().isBossFight)
        {
            if (!isStone)
            {
                Vector3 posPlayer = player.transform.position;
                transform.position = Vector2.MoveTowards(transform.position, posPlayer, speed * Time.deltaTime);
            }
            //transform.RotateAround(transform.position, new Vector3(0, 0, 2), 20 * Time.deltaTime);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Health playerHealth = collision.transform.GetComponent<Health>();
            playerHealth.TakeDommage(damage);
            Vector3 back = new Vector3(transform.position.x * 10, 0f, 0f);
            transform.position = Vector2.MoveTowards(transform.position, back, speed * Time.deltaTime);
        }
        else if (collision.transform.CompareTag("Projectile"))
        {
            Projectile proj = collision.transform.GetComponent<Projectile>();
            TakeDamage(proj.damage);
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
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //bossBar.SetHealth(currentHealth);
    }
}
