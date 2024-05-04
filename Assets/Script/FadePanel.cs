using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadePanel : MonoBehaviour
{
    public Image fadePanel;
    public float fadeDuration = 0.01f;
    
    private void Start()
    {
        fadePanel.gameObject.SetActive(false); // Activar el panel antes de comenzar el Fade In
    }

    // Coroutine para el Fade In
    public IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        Color startColor = fadePanel.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1f); // Establecer el valor alfa a 1 (totalmente opaco)

        fadePanel.gameObject.SetActive(true); // Activar el panel antes de comenzar el Fade In

        while (elapsedTime <= fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadePanel.color = Color.Lerp(startColor, endColor, elapsedTime / fadeDuration);
            yield return null;
        }
    }

    // Coroutine para el Fade Out
    public IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color startColor = fadePanel.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f); // Establecer el valor alfa a 0 (totalmente transparente)

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadePanel.color = Color.Lerp(startColor, endColor, elapsedTime / fadeDuration);
            yield return null;
        }

        fadePanel.gameObject.SetActive(false); // Desactivar el panel una vez que se haya desvanecido
    }
    public IEnumerator PerformFadeTransition()
    {
        yield return StartCoroutine(FadeIn()); // Esperar a que termine FadeIn antes de comenzar FadeOut
        yield return new WaitForSeconds(0.1f); // Esperar un segundo entre FadeIn y FadeOut
        yield return StartCoroutine(FadeOut());
    }
}
