using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static HealthBar Instance { get; private set; }
    public float healthToSave;
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthBar;

    private void Awake()
    {
        Instance = this;
        healthToSave = 1f;
    }
    void Update()
    {
        totalHealthBar.fillAmount = playerHealth.currentHealth / 3;
        healthToSave = totalHealthBar.fillAmount;
    }
    public void LoadHealth()
    {
        totalHealthBar.fillAmount = healthToSave;
    }
}
