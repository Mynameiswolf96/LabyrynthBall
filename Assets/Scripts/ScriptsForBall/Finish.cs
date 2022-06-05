using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject panelwin;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            panelwin.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
