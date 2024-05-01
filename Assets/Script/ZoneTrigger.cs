using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ZoneTrigger : MonoBehaviour
{
    [SerializeField] private GameObject button;
    private void Start()
    {
        // Desactivar el botón al inicio
        button.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            button.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            button.SetActive(false);
        }
    }
}
