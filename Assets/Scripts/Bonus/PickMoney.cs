
using UnityEngine;

public class PickMoney : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DestroyObject(gameObject);
        }
    }
}