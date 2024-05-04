using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NPCInteraction : MonoBehaviour
{
    public GameObject interactionMessage; // Referencia al objeto del cuadro de mensaje en el Canvas
    public float messageDisplayTime = 3f; // Tiempo en segundos que se mostrará el mensaje antes de desaparecer
    public DialogueSet dialogueSet; // Referencia al conjunto de diálogos del NPC
    [SerializeField] private TextMeshProUGUI dialogueTextComponent; // Componente de texto para mostrar el diálogo
    private bool interactionInProgress = false; // Variable para controlar si la interacción está en progreso
    private int currentDialogueIndex = 0; // Índice del diálogo actual

    private void Start()
    {
        interactionMessage.SetActive(false); // Asegurarse de que el cuadro de mensaje esté oculto al inicio
    }

    // Método para manejar la interacción con el NPC
    public void InteractWithNPC()
    {
        // Verificar si ya hay una interacción en curso o si el jugador está fuera del rango de interacción
        if (interactionInProgress)
        {
            return;
        }

        // Mostrar el cuadro de mensaje con el diálogo actual del NPC
        ShowInteractionMessage(dialogueSet.dialogues[currentDialogueIndex]);

        // Actualizar el índice del diálogo para el siguiente ciclo
        currentDialogueIndex = (currentDialogueIndex + 1) % dialogueSet.dialogues.Length;

        // Restablecer la variable de interacción en curso
        interactionInProgress = true;

        // Esperar un tiempo antes de ocultar el mensaje
        StartCoroutine(HideInteractionMessage());
    }    

    // Método para mostrar el cuadro de mensaje en el Canvas con un diálogo específico
    private void ShowInteractionMessage(DialogueSet.Dialogue dialogue)
    {
        interactionInProgress = true; // Marcar la interacción como en curso
        interactionMessage.SetActive(true); // Activar el objeto del cuadro de mensaje en el Canvas

        // Mostrar el diálogo en el cuadro de mensaje
        if (dialogueTextComponent != null)
        {
            dialogueTextComponent.text = dialogue.dialogueText;
        }
        else
        {
            Debug.LogError("No se encontró un componente TextMeshProUGUI en el objeto interactionMessage.");
        }
    }

    // Corrutina para ocultar el cuadro de mensaje después de cierto tiempo
    private IEnumerator HideInteractionMessage()
    {
        // Esperar el tiempo especificado
        yield return new WaitForSeconds(messageDisplayTime);

        // Ocultar el cuadro de mensaje
        interactionMessage.SetActive(false); // Desactivar el objeto del cuadro de mensaje en el Canvas

        // Marcar la interacción como completada
        interactionInProgress = false;
    }
}
