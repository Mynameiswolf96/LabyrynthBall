using System;
using Ball;
using UnityEngine;
using UnityEngine.UI;


namespace Ball
{
    public class HeroMove : MonoBehaviour, IUnit
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _jumpForce = 200f;
        [SerializeField] private float _maxHealth;
        [SerializeField] private Text _scorePointText;
        private float _curHealth;
        private int _pickupCoin;
        private int _scaleCoins;
        private float _deltaX, _deltaY;
        private Rigidbody _rigidbody;
        private const string _horizontal = "Horizontal";
        private const string _vertical = "Vertical";
        private const string _jump = "Jump";
        public static Action <float> OnHealthChanged;
        public static Action WinDelegate;
        public static Action LoseDelegate;
        private Rigidbody _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _curHealth = _maxHealth;
        }

        private void FixedUpdate()
        {
            _deltaX = Input.GetAxis(_horizontal);
            _deltaY = Input.GetAxis(_vertical);
            Vector3 movement = new Vector3(_deltaX * _speed, _rb.velocity.y, _deltaY * _speed);
            _rb.AddForce(movement);
            if (Input.GetButtonDown(_jump))
            {
                _rigidbody.AddForce(Vector3.up * _jumpForce);
            }
        }
        
        public void SetHealthAdjustment(float adjustmentAmount)
        {
            _curHealth += adjustmentAmount;
            if (_curHealth > 10)
            {
                _curHealth = 10;
            }
            OnHealthChanged?.Invoke(_curHealth);

        }

        public void Hit(float damage)
        {
            _curHealth -= damage;
            OnHealthChanged?.Invoke(_curHealth);
            if (_curHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            gameObject.SetActive(false);

            try
            {
                LoseDelegate?.Invoke();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            GetCoin(other.gameObject);

        }

        public void GetCoin(GameObject coin)
        {
            if (coin.tag == "Coin")
            {
                _pickupCoin++; 
                _scorePointText.text = _pickupCoin.ToString();
                Destroy(coin.gameObject);
            }

            if (_pickupCoin == 5)
            {
                WinDelegate?.Invoke();
            }

        }

    }
}