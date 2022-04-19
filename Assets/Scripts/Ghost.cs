using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    float alpha = 1;
    [SerializeField] float alphaDecreaseRate;
    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        alpha -= Time.deltaTime * alphaDecreaseRate;
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, alpha);
        if(alpha <= 0)
        {
            Destroy(gameObject);
        }
    }
}
