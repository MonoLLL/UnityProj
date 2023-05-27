using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthBar;
    void Start()
    {
        totalHealthBar.fillAmount = playerHealth.currentHealth / 3;
    }
    void Update()
    {
        totalHealthBar.fillAmount = playerHealth.currentHealth / 3;
    }
}
