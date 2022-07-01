using System;
using Ball;
using UnityEngine;
using UnityEngine.UI;

public class UIHP : MonoBehaviour
{
    [SerializeField] private Text HPText;


    public void Awake()
    {
        Subscribe();
        HPText.text = "10";
        HPText.color = Color.green;
    }

    public void Subscribe()
    {
        HeroMove.OnHealthChanged += OnHealthChanged;
    }

    private void OnHealthChanged(float health)
    {
        HPText.text = health.ToString();
        if (health < 5)
        {
            HPText.color = Color.red;
        }

        if (health > 5)
        {
            HPText.color = Color.green;
        }
    }

    private void OnDestroy()
    {
        HeroMove.OnHealthChanged -= OnHealthChanged;
    }
}
