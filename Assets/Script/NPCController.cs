using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints; // Puntos de destino
    public float movementSpeed = 3f; // Velocidad de movimiento del NPC
    public float waitTime = 1f; // Tiempo de espera en cada punto
    public float rotationSpeed = 2f;
    private int currentWaypointIndex = 0;
    private bool isMoving = true;
    void Start()
    {
        StartCoroutine(MoveNPC());
    }
    IEnumerator MoveNPC()
    {
        while (true)
        {
            if (isMoving)
            {
                // Calcular dirección y distancia al punto de destino
                Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
                float distance = direction.magnitude;

                // Si el NPC llega al punto de destino, detenerse
                if (distance < 0.1f)
                {
                    isMoving = false;
                    yield return new WaitForSeconds(waitTime); // Esperar un tiempo en el punto
                    isMoving = true;
                }
                else
                {
                    // Mover al NPC hacia el punto de destino
                    transform.position += direction.normalized * movementSpeed * Time.deltaTime;
                    // Girar hacia la dirección de movimiento
                    Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
                    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                }
            }
            yield return null;
        }
    }

    void Update()
    {
        // Si el NPC está detenido, cambiar al siguiente punto de destino
        if (!isMoving)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;

        }
    }
    
}
