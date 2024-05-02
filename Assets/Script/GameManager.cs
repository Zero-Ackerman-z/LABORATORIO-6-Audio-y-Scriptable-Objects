using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string sceneName1; // Nombre de la primera escena
    [SerializeField] private string sceneName2; // Nombre de la segunda escena
    private static GameManager instance;
    [SerializeField] private UiManager uiManager; // Nombre de la segunda escena

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
    // Start is called before the first frame update
    private void Start()
    {
        // Obtener la referencia al UIManager
        uiManager = FindObjectOfType<UiManager>();
        if (uiManager == null)
        {
            Debug.LogError("No se pudo encontrar el UIManager.");
        }
    }
    public void ToggleScene()
    {
        // Obtiene el nombre de la escena actual
        string currentSceneName = SceneManager.GetActiveScene().name;


        // Verifica en qué escena se encuentra el jugador y carga la otra escena
        if (currentSceneName == sceneName1)
        {
            SceneManager.LoadScene(sceneName2);
            uiManager.HideButton();
        }
        else if (currentSceneName == sceneName2)
        {
            SceneManager.LoadScene(sceneName1);
            uiManager.HideButton();
        }
    }
}
