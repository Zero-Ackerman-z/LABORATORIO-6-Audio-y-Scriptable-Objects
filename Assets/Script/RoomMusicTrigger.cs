using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMusicTrigger : MonoBehaviour
{
    [SerializeField] private string roomMusicTitle; // El t�tulo de la m�sica asociada a esta habitaci�n
    private string previousBackgroundMusicTitle; // Guarda el t�tulo de la m�sica de fondo antes de reproducir la m�sica de la habitaci�n
    [SerializeField] private FadePanel fadePanel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            previousBackgroundMusicTitle = AudioManager.Instance.GetCurrentBackgroundMusicTitle();

            // Llamar al AudioManager para reproducir la m�sica de esta habitaci�n
            AudioManager.Instance.PlayBackgroundMusic(roomMusicTitle);
            Debug.Log("entrando");
            StartCoroutine(fadePanel.PerformFadeTransition());


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.ResumePreviousBackgroundMusic();
            Debug.Log("saliendo");
            StartCoroutine(fadePanel.PerformFadeTransition());

        }
    }
   
}
