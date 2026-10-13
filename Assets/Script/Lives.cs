using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Lives : MonoBehaviour
{
    [SerializeField]
    private int startingLives;
    [SerializeField]
    private UnityEvent<float> onLoseLife;
    [SerializeField]
    private UnityEvent onDeath;
    [SerializeField]
    private UnityEvent<float>startInvicibility;
    [SerializeField]
    private UnityEvent endInvisibility;
    [SerializeField]
    private float invicibilityDuration = 2f;
    [SerializeField]
    private float fullInvicibilityDuration = 4f;
    private int invicibilityLimit = 3;
    private bool isInvicible;
    private bool isDead;
    private bool IsInvicible => isInvicible;
    private int currentLives;
    public void Initialize()
    {
        currentLives = startingLives;
        isInvicible = false;
        isDead = false;
    }
    public void AddLife(int amount)
    {
        if (currentLives == (invicibilityLimit - 1))
        {
            StartCoroutine(FullInvicibilityCoroutine());
        }
        else
        {
            currentLives += amount;
        }
    }
    public void LoseLife()
    {
        if (isInvicible || isDead) return;
        currentLives--;
        if (currentLives <= 0)
        {
            isDead = true;
            onDeath?.Invoke();
        }
        else
        {
            StartCoroutine(InvicibilityCoroutine());
        }
    }
    private IEnumerator InvicibilityCoroutine()
    {
        isDead = true;
        onLoseLife?.Invoke(invicibilityDuration);
        yield return new WaitForSeconds(invicibilityDuration);
        isDead = false;
    }
    private IEnumerator FullInvicibilityCoroutine()
    {
        isInvicible = true;
        startInvicibility?.Invoke(fullInvicibilityDuration);
        yield return new WaitForSeconds(fullInvicibilityDuration);
        isInvicible = false;
        endInvisibility?.Invoke();
    }
    public void Kill()
    {
        isDead = true;
        currentLives = 0;
        onDeath?.Invoke();
    }



}
