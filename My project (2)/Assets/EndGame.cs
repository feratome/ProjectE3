using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public ParticleSystem objectToActivate;
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration = 1f;
    public float visibleDuration = 5f;

    private bool triggered;
    private float currentFadeTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            objectToActivate.Play();
            StartCoroutine(FadeAndDisplay());
            Debug.Log("in the trigger zone");
        }
    }

    private IEnumerator FadeAndDisplay()
    {
        currentFadeTime = 0f;

        while (currentFadeTime < fadeDuration)
        {
            currentFadeTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, currentFadeTime / fadeDuration);
            fadeCanvasGroup.alpha = alpha;
            yield return null;
        }

        fadeCanvasGroup.alpha = 1f;
        yield return new WaitForSeconds(visibleDuration);

        fadeCanvasGroup.alpha = 1f;
        triggered = false;
    }
}