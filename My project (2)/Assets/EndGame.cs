using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject objectToActivate;
    public Renderer fadeQuadRenderer;
    public GameObject cube;
    public float fadeDuration = 1f;
    public float visibleDuration = 5f;
    public Light pointLight; // Assigned light component
    public float targetLightIntensity = 2f; // Desired intensity of the point light

    private bool triggered;
    private float currentFadeTime;
    private bool isFadingOut;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            objectToActivate.SetActive(true);
            StartCoroutine(FadeAndDisplay());
        }
    }

    private IEnumerator FadeAndDisplay()
    {
        Color initialColor = fadeQuadRenderer.material.color;
        Color targetColor = new Color(1f, 1f, 1f, 1f);
        fadeQuadRenderer.material.color = new Color(1f, 0f, 0f, 0f);

        isFadingOut = false;
        currentFadeTime = 0f;

        while (currentFadeTime < fadeDuration || !isFadingOut)
        {
            currentFadeTime += Time.deltaTime;

            if (currentFadeTime >= fadeDuration)
            {
                isFadingOut = true;
                currentFadeTime = fadeDuration;
            }

            float t = currentFadeTime / fadeDuration;
            Color currentColor = Color.Lerp(new Color(1f, 0f, 0f, 0f), targetColor, t);
            fadeQuadRenderer.material.color = currentColor;

            // Set the desired intensity of the point light
            float intensity = Mathf.Lerp(pointLight.intensity, targetLightIntensity, t);
            pointLight.intensity = intensity;

            yield return null;
        }

        yield return new WaitForSeconds(visibleDuration);

        fadeQuadRenderer.material.color = targetColor;
        cube.SetActive(true);
        triggered = false;
    }
}
