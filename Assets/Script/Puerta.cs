using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public bool doorOpen = false;
    public float doorOpenAngle = 95f;
    public float doorCloseAngle = 0.0f;
    public float smooth = 3.0f;
    private float autoCloseTimer = 2f;

    [SerializeField] private string exitSoundEffectName; // Nombre del efecto de sonido al salir
    [SerializeField] private string SoundEffectName; // Nombre del efecto de sonido al salir
    private string previousSoundEffectName; // Guarda el título de la música de fondo antes de reproducir la música de la habitación
    void Update()
    {
        if (doorOpen)
        {
            OpenDoor();
            Quaternion targetRotation = Quaternion.Euler(0, doorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
            autoCloseTimer -= Time.deltaTime;
            if (autoCloseTimer <= 0)
            {
                // Cerrar la puerta cuando el temporizador alcance cero
                CloseDoor();
            }

        }
        else
        {
            Quaternion targetRotation = Quaternion.Euler(0, doorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
        }
        
    }

    public void OpenDoor()
    {
        previousSoundEffectName = AudioManager.Instance.GetsoundEffectTitle();

        doorOpen = true;
        AudioManager.Instance.PlaySoundEffect(SoundEffectName);
        
    }

    public void CloseDoor()
    {
        doorOpen = false;
        autoCloseTimer = 2f; // Establecer el temporizador en 2 segundos
        AudioManager.Instance.PlaySoundEffect(exitSoundEffectName);
    }
   
}

