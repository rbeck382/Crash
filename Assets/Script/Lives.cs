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
    [SerializeField]
    private int invicibilityLimit = 3;
    [SerializeField]
    private AvatarController avatarController;
    private int currentLives;
    public bool IsDead => currentLives <= 0;
    public void Initialize()
    {
        currentLives = startingLives;
        avatarController.SetActiveAvatar(currentLives);
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
            avatarController.SetActiveAvatar(currentLives);
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
            avatarController.SetActiveAvatar(currentLives);
        }
    }
    public void Kill()
    {
        currentLives = 0;
        avatarController.SetActiveAvatar(currentLives);
        onDeath?.Invoke();
    }



}
