using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider slider;
    [SerializeField] Health health;
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void UpdateHealthBar()
    {
        slider.value = health.GetHealth() / health.GetMaxHealth();
    }

}
