using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private PlayerInputActions controls;
    private Rigidbody rb;
    [SerializeField] float velocidadMovimiento = 5f;
    private Vector2 movimientoInput;
    public float velocidadRotacion = 10f; // Ajusta esta velocidad para controlar la suavidad de la rotación
    private UiManager uiManager;
    public float raycastDistance = 5f; // Distancia del raycast
    [SerializeField] private Puerta Door;
    LayerMask mask;
    [SerializeField] private string walkSoundEffectName; // Nombre del efecto de sonido al salir
    private AudioManager audioManager; // Referencia al AudioManager
    private bool isWalking; // Indica si el jugador está caminando actualmente

    private void Awake()
    {
        controls = new PlayerInputActions();
        controls.Game.Move.performed += ctx => Movimiento(ctx);
        controls.Game.Sound.performed += ctx => Configuracion(ctx);
        controls.Game.Interact.performed += ctx => Interactuar(ctx);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        uiManager = FindObjectOfType<UiManager>(); // Encontrar el UiManager en la escena
        mask = LayerMask.GetMask("raycas-detect");
        audioManager = FindObjectOfType<AudioManager>(); // Obtener referencia al AudioManager

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
        Vector3 movimiento = new Vector3(movimientoInput.y, 0f, movimientoInput.x) * velocidadMovimiento * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movimiento);

        if (movimientoInput != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(movimientoInput.y, movimientoInput.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, velocidadRotacion * Time.deltaTime);
        }
        Vector3 raycastStart = transform.position;
        Vector3 raycastEnd = transform.position + transform.forward * raycastDistance;

        // Dibujar una línea para visualizar el raycast
        Debug.DrawLine(raycastStart, raycastEnd, Color.blue);
        

    }
    public void Interactuar(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
            {
                Door.OpenDoor();
            }
        }
    }
    public void Movimiento(InputAction.CallbackContext context)
    {
        // Obtener el valor de entrada del movimiento horizontal y vertical
        movimientoInput = context.ReadValue<Vector2>();
        // Si el jugador está caminando y el AudioManager no es nulo, reproducir el sonido de caminar
        if (movimientoInput != Vector2.zero && audioManager != null)
        {
            audioManager.PlaySoundEffect("Caminar");
        }
        // Si el jugador deja de caminar y el AudioManager no es nulo, detener el sonido de caminar
        else if (movimientoInput == Vector2.zero && audioManager != null)
        {
            audioManager.StopSoundEffect("Caminar");
        }
    }
    
    public void Configuracion(InputAction.CallbackContext context)
    {
        if (context.started && uiManager != null)
        {
            uiManager.ToggleSettingsPanel(); // Cambiar entre mostrar y ocultar el panel
        }
    }

}
