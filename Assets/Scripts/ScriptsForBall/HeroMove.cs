using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private float _deltaX;
    private float _deltaY;
    private Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        _deltaX  = Input.GetAxis("Horizontal");
        _deltaY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(_deltaX * _speed, _rb.velocity.y, _deltaY * _speed);
        _rb.AddForce(movement);
    }
}
