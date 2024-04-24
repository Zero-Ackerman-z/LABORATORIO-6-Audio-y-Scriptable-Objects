using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private PlayerInputActions controls;
    private Rigidbody rb;
    [SerializeField] float velocidadMovimiento = 5f;
    private Vector2 movimientoInput;
    public float velocidadRotacion = 10f; // Ajusta esta velocidad para controlar la suavidad de la rotación
    private UiManager uiManager;
    private void Awake()
    {
        controls = new PlayerInputActions();
        controls.Game.Move.performed += ctx => Movimiento(ctx);
        controls.Game.Sound.performed += ctx => Configuracion(ctx);

    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        uiManager = FindObjectOfType<UiManager>(); // Encontrar el UiManager en la escena

    }

    private void OnEnable()
    {
        controls.Game.Enable();
    }

    private void OnDisable()
    {
        controls.Game.Disable();
    }
    
    private void FixedUpdate()
    {
        // Obtener el vector de movimiento en los ejes X, Y y Z
        Vector3 movimiento = new Vector3(movimientoInput.x, 0f, movimientoInput.y) * velocidadMovimiento * Time.fixedDeltaTime;

        // Mover el Rigidbody en los ejes X, Y y Z
        rb.MovePosition(rb.position + movimiento);
        
        if (movimientoInput != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(movimientoInput.y, movimientoInput.x) * Mathf.Rad2Deg;

            // Invertir el ángulo en el eje Y
            targetAngle *= -1f;

            Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, velocidadRotacion * Time.deltaTime);
        }
    

    }
    public void Movimiento(InputAction.CallbackContext context)
    {
        // Obtener el valor de entrada del movimiento horizontal y vertical
        movimientoInput = context.ReadValue<Vector2>();
    }
    public void Configuracion(InputAction.CallbackContext context)
    {
        if (context.started && uiManager != null)
        {
            uiManager.ToggleSettingsPanel(); // Cambiar entre mostrar y ocultar el panel
        }
    }
}
