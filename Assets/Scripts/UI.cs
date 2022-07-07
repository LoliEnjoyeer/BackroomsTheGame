using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText = default;

    private void OnEnable()
    {
        characterController.OnDamage += UpdateHealth;
        characterController.OnHeal += UpdateHealth;
    }

    private void OnDisable()
    {
        characterController.OnDamage -= UpdateHealth;
        characterController.OnHeal -= UpdateHealth;
    }

    private void Start()
    {
        UpdateHealth(100);
    }

    private void UpdateHealth(float currentHealth)
    {
        healthText.text = currentHealth.ToString("00");
    }
}
