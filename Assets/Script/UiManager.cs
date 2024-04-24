using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public GameObject settingsPanel; // Referencia al panel de configuración en el Canvas

    public void Start()
    {
        HideSettingsPanel();
    }

    // Método para mostrar u ocultar el panel de configuración
    public void ToggleSettingsPanel()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(!settingsPanel.activeSelf);
        }
    }

    // Método para ocultar el panel de configuración
    public void HideSettingsPanel()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false);
        }
    }
}
