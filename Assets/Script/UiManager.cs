using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public GameObject settingsPanel; // Referencia al panel de configuraci�n en el Canvas

    public void Start()
    {
        HideSettingsPanel();
    }

    // M�todo para mostrar u ocultar el panel de configuraci�n
    public void ToggleSettingsPanel()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(!settingsPanel.activeSelf);
        }
    }

    // M�todo para ocultar el panel de configuraci�n
    public void HideSettingsPanel()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false);
        }
    }
}
