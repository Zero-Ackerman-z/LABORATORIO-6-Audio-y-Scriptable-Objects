using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ZoneTrigger : MonoBehaviour
{
    [SerializeField] private UiManager uiManager;
    private void Start()
    {
        // Obtener la referencia al UIManager
        uiManager = FindObjectOfType<UiManager>();
        if (uiManager == null)
        {
            Debug.LogError("No se pudo encontrar el UIManager.");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (uiManager != null)
            {
                uiManager.MostrarButton(); // Mostrar el botón en el UIManager
            }
            else
            {
                Debug.LogWarning("El UIManager no está asignado en el ZoneTrigger.");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (uiManager != null)
            {
                uiManager.HideButton(); // Ocultar el botón en el UIManager
            }
            else
            {
                Debug.LogWarning("El UIManager no está asignado en el ZoneTrigger.");
            }
        }
    }
}
