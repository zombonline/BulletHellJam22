using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth;
    float health;
    [SerializeField] UnityEvent healthModified;

    [SerializeField] bool invulnerableFrames;
    [SerializeField] float invulnerabilityLength;
    public bool canHit = true;
    [SerializeField] SpriteRenderer spriteToFlash;

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
        if (invulnerableFrames)
        {
            StartCoroutine(InvulnerabilityPeriod());
        }
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
