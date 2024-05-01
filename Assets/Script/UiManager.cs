using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] private string sceneName1; // Nombre de la primera escena
    [SerializeField] private string sceneName2; // Nombre de la segunda escena
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
    public void ToggleScene()
    {
        // Obtiene el nombre de la escena actual
        string currentSceneName = SceneManager.GetActiveScene().name;


        // Verifica en qu� escena se encuentra el jugador y carga la otra escena
        if (currentSceneName == sceneName1)
        {
            SceneManager.LoadScene(sceneName2);
        }
        else if (currentSceneName == sceneName2)
        {
            SceneManager.LoadScene(sceneName1);
        }
    }
}
