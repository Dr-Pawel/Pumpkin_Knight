using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Slider healthSlider;

    private void Start()
    {
        healthSlider.maxValue = health.maxHealth;
        healthSlider.value = healthSlider.maxValue;
    }

    public void HealthBarUpdate()
    {
        healthSlider.value = health.CurrentHealth;
    }    
}
