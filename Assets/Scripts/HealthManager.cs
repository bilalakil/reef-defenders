using System;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float InitialHealth { get; private set; }

    private float healthRemainingBacking;
    public event Action OnHealthRemainingChanged;
    public float HealthRemaining
    {
        get => healthRemainingBacking;
        set
        {
            if (Mathf.Approximately(value, healthRemainingBacking)) return;
            healthRemainingBacking = value;
            OnHealthRemainingChanged?.Invoke();
        }
    }

    [SerializeField] private float initialDangerZoneHealth = 5.0f;

    public void Awake()
    {
        InitialHealth = healthRemainingBacking = initialDangerZoneHealth;
    }
    
    public void TakeHit(float damage)
    {
        HealthRemaining -= damage;
        if (HealthRemaining < 0)
        {
            Time.timeScale = 0;
        }
    }
}
