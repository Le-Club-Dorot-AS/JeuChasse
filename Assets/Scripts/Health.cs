using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int nbHeart;
    public Image[] hearts;
    public Sprite fullHeart;

    public float invincibilityTimeAfterHit = 1f;
    public float invincibilityFlashDelay = 0.2f;
    public bool isInvincible = false;
    public SpriteRenderer graphics;
    // Update is called once per frame
    void Update()
    {
        nbHeart = health;
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < nbHeart)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    public void TakeDommage(int damage)
    {
        if (!isInvincible)
        {
            health -= damage;
            isInvincible = true;
            StartCoroutine(InvinciblilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
        
    }
    public IEnumerator InvinciblilityFlash()
    {
        while (isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }
    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvincible = false;
    }
}