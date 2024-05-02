using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel; // Referencia al panel de configuración en el Canvas
    private static UiManager instance;
    [SerializeField] private Button button;
    private void Awake()
    {
        // Verificar si ya existe una instancia de VolumeSettings
        if (instance == null)
        {
            // Si no hay ninguna instancia, establecer esta como la instancia
            instance = this;
            DontDestroyOnLoad(gameObject); // Mantener este objeto entre las escenas
        }
        else
        {
            // Si ya hay una instancia, destruir este objeto
            Destroy(gameObject);
        }
    }
    public void Start()
    {
        HideSettingsPanel();
        HideButton();
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
    // Método para ocultar el botón
    public void HideButton()
    {
        if (button != null)
        {
            button.gameObject.SetActive(false);
        }
    }

    // Método para mostrar el botón
    public void MostrarButton()
    {
        if (button != null)
        {
            button.gameObject.SetActive(true);
        }
    }
}
