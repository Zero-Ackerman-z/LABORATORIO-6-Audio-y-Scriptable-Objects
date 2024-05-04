using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMusicTrigger : MonoBehaviour
{
    [SerializeField] private string roomMusicTitle; // El título de la música asociada a esta habitación
    private string previousBackgroundMusicTitle; // Guarda el título de la música de fondo antes de reproducir la música de la habitación
    [SerializeField] private FadePanel fadePanel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            previousBackgroundMusicTitle = AudioManager.Instance.GetCurrentBackgroundMusicTitle();

            // Llamar al AudioManager para reproducir la música de esta habitación
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
