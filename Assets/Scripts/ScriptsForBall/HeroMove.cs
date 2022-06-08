
using UnityEngine;
using UnityEngine.UI;

public class HeroMove : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private float _deltaX;
    public Text TextCoins;
    private float _deltaY;
    
    private Rigidbody _rb;
    public int Scroll = 10;
    public int coin;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (coin == Scroll)
        {
            Time.timeScale = 0;
        }
        _deltaX = Input.GetAxis("Horizontal");
        _deltaY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(_deltaX * _speed, _rb.velocity.y, _deltaY * _speed);
        _rb.AddForce(movement);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
         coin++;

        }
    }
}