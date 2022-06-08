using UnityEngine;
public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth=20f;
    private float _curHealth;
    private float _sliderValue;
    

    
    private void Awake()
    {
        _curHealth = 20f;
    }

    
    public void  Hit (float damage)
    {
        _curHealth -= damage;
        if (_curHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        gameObject.SetActive(false); 
    }
    private void Update()
    {
        _sliderValue = (_curHealth / maxHealth);

    }

    public void SetHealthAdjustment(int adjustment)
    {
        _curHealth += adjustment;
        if (_curHealth > 20)
        {
            _curHealth = 20;
        }
    }

    private void OnGUI()
    {
        _sliderValue = GUI.HorizontalSlider(new Rect(25, 25, 300, 60), _sliderValue, 0, 1);
    }
}