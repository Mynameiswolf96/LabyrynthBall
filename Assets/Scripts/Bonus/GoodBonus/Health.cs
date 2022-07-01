using UnityEngine;

namespace Ball
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 20f;
        private float _curHealth;
        private float _sliderValue;
        private void Awake()
        {
            _curHealth = 20f;
        }
        
        private void Update()
        {
            _sliderValue = (_curHealth / maxHealth);

        }
        public void SetHealthAdjustment(float health)
        {
            _curHealth += health;
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
}