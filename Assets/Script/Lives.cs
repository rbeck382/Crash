using UnityEngine;
using UnityEngine.Events;

public class Lives : MonoBehaviour
{
    [SerializeField]
    private int startingLives;
    [SerializeField]
    private UnityEvent onLoseLife;
    [SerializeField]
    private UnityEvent onDeath;
    [SerializeField]
    private UnityEvent startInvicibility;
    private int invicibilityLimit = 3;
    private int currentLives;
    public bool IsDead => currentLives <= 0;
    public void Initialize()
    {
        currentLives = startingLives;
    }
    public void AddLife(int amount)
    {
        if (currentLives == (invicibilityLimit - 1))
        {
            startInvicibility?.Invoke();
        }
        else
        {
            currentLives += amount;
        }
    }
    public void LoseLife()
    {
        currentLives--;
        if (currentLives <= 0)
        {
            onDeath?.Invoke();
        }
        else
        {
            onLoseLife?.Invoke();
        }
    }
    public void Kill()
    {
        currentLives = 0;
        onDeath?.Invoke();
    }



}
