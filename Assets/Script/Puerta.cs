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
    [SerializeField] private string exitSoundEffectName;

    [SerializeField] private string EnterSoundEffectName;
    void Update()
    {
        if (doorOpen)
        {
            Quaternion targetRotation = Quaternion.Euler(0, doorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
            autoCloseTimer -= Time.deltaTime;
            if (autoCloseTimer <= 0)
            {
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
        doorOpen = true;
        AudioManager.Instance.PlaySoundEffect(EnterSoundEffectName); // Reanudar el efecto de sonido anterior
    }

    public void CloseDoor()
    {
        doorOpen = false;
        autoCloseTimer = 2f; // Establecer el temporizador en 2 segundos
        AudioManager.Instance.PlaySoundEffect(exitSoundEffectName);
    }

}




