using System;
using System.IO;
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
        private const int _scoreWin = 5;
        private const string _vertical = "Vertical";
        private const string _jump = "Jump";
        public static Action <float> OnHealthChanged;
        public static Action WinDelegate;
        public static Action LoseDelegate;
        private Rigidbody _rb;
        private SerializableXMLData<SaveData> _serializableXMLData = new SerializableXMLData<SaveData>();
        private SaveData _saveData = new SaveData() { Name = "Bonus", Position = new Vector3(0,0,0) };
        [SerializeField]private GameObject _gameObject;
        
        private void Start()
        {
        
            _rb = GetComponent<Rigidbody>();
            _curHealth = _maxHealth;
            _saveData.Position = new Vector3(_gameObject.transform.position.x, _gameObject.transform.position.y, _gameObject.transform.position.z);
            var path = Path.Combine(Application.streamingAssetsPath, "SerializableXMLSave.xml");
            _serializableXMLData.Save(_saveData, path);
            var save = _serializableXMLData.Load(path);
            Debug.Log(save);
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

            if (_pickupCoin == _scoreWin )
            {
                WinDelegate?.Invoke();
            }

        }

    }
}