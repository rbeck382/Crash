using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Blink : MonoBehaviour
{
    private List<Renderer> renderers = new List<Renderer>();
    [SerializeField]
    private float blinkInterval = 0.1f;
    private void Awake()
    {
        renderers.AddRange(GetComponentsInChildren<Renderer>());
    }
    private void EnableRenderers (bool enable)
    {
        foreach (var renderer in renderers)
        {
            renderer.enabled = enable;
        }
    }
    public void StartBlink(float duration)
    {
        StartCoroutine(BlinkCoroutine(duration));
    }
    private IEnumerator BlinkCoroutine(float duration)
    {
        bool isActive = true;
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            EnableRenderers (isActive);
            isActive = !isActive;
            yield return new WaitForSeconds (blinkInterval);
            elapsedTime += blinkInterval;
        }
        EnableRenderers(true);
    }
    public void StopBlink()
    {
        StopAllCoroutines();
        EnableRenderers(true);
    }
}
