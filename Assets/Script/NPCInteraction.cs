using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NPCInteraction : MonoBehaviour
{
    public GameObject interactionMessage; // Referencia al objeto del cuadro de mensaje en el Canvas
    public float messageDisplayTime = 3f; // Tiempo en segundos que se mostrar� el mensaje antes de desaparecer
    public DialogueSet dialogueSet; // Referencia al conjunto de di�logos del NPC
    [SerializeField] private TextMeshProUGUI dialogueTextComponent; // Componente de texto para mostrar el di�logo
    private bool interactionInProgress = false; // Variable para controlar si la interacci�n est� en progreso
    private int currentDialogueIndex = 0; // �ndice del di�logo actual

    private void Start()
    {
        interactionMessage.SetActive(false); // Asegurarse de que el cuadro de mensaje est� oculto al inicio
    }

    // M�todo para manejar la interacci�n con el NPC
    public void InteractWithNPC()
    {
        // Verificar si ya hay una interacci�n en curso o si el jugador est� fuera del rango de interacci�n
        if (interactionInProgress)
        {
            return;
        }

        // Mostrar el cuadro de mensaje con el di�logo actual del NPC
        ShowInteractionMessage(dialogueSet.dialogues[currentDialogueIndex]);

        // Actualizar el �ndice del di�logo para el siguiente ciclo
        currentDialogueIndex = (currentDialogueIndex + 1) % dialogueSet.dialogues.Length;

        // Restablecer la variable de interacci�n en curso
        interactionInProgress = true;

        // Esperar un tiempo antes de ocultar el mensaje
        StartCoroutine(HideInteractionMessage());
    }    

    // M�todo para mostrar el cuadro de mensaje en el Canvas con un di�logo espec�fico
    private void ShowInteractionMessage(DialogueSet.Dialogue dialogue)
    {
        interactionInProgress = true; // Marcar la interacci�n como en curso
        interactionMessage.SetActive(true); // Activar el objeto del cuadro de mensaje en el Canvas

        // Mostrar el di�logo en el cuadro de mensaje
        if (dialogueTextComponent != null)
        {
            dialogueTextComponent.text = dialogue.dialogueText;
        }
        else
        {
            Debug.LogError("No se encontr� un componente TextMeshProUGUI en el objeto interactionMessage.");
        }
    }

    // Corrutina para ocultar el cuadro de mensaje despu�s de cierto tiempo
    private IEnumerator HideInteractionMessage()
    {
        // Esperar el tiempo especificado
        yield return new WaitForSeconds(messageDisplayTime);

        // Ocultar el cuadro de mensaje
        interactionMessage.SetActive(false); // Desactivar el objeto del cuadro de mensaje en el Canvas

        // Marcar la interacci�n como completada
        interactionInProgress = false;
    }
}
