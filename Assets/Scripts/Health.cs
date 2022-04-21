using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth;
    float health;
    [SerializeField] UnityEvent healthModified;

    [SerializeField] bool isPlayer;
    [SerializeField] float invulnerabilityLength;
    public bool canHit = true;
    [SerializeField] SpriteRenderer spriteToFlash;
    [SerializeField] ParticleSystem deathParticles;
    private void Start()
    {
        health = maxHealth;
    }

    public float GetHealth()
    {
        return health;
    }
    public float GetMaxHealth()
    {
        return maxHealth;
    }
    public void RemoveHealth(float amount)
    {
        health -= amount;
        healthModified.Invoke();
        if (isPlayer)
        {
            StartCoroutine(InvulnerabilityPeriod());
        }
        else
        {
            StartCoroutine(SpriteRed());
        }
        if(health <= 0)
        {
            Die();
        }
    }

    IEnumerator SpriteRed()
    {
        var standardColor = spriteToFlash.color;
        for(int i = 0; i < invulnerabilityLength / 2; i++)
        {
            spriteToFlash.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            spriteToFlash.color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void Die()
    {
        if (!isPlayer)
        {
            Destroy(gameObject);
        }
        else
        {
            LevelTimer.levelRunning = false;
            spriteToFlash.enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            StartCoroutine(LoadGameOver());
        }
    }

    IEnumerator LoadGameOver()
    {
        yield return new WaitForSeconds(3f);
        SceneLoader.LoadGameOver();
    }

    public void AddHealth(float amount)
    {
        health += amount;
        healthModified.Invoke();
    }

    IEnumerator InvulnerabilityPeriod()
    {
        canHit = false;
        for(int i = 0; i < invulnerabilityLength / 2; i++)
        {
            spriteToFlash.enabled = false;
            yield return new WaitForSeconds(0.1f);
            spriteToFlash.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        canHit = true;
    }
}
