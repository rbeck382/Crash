using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
public class PlayerState : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onInitialize;
    [SerializeField]
    private UnityEvent onDie;
    [SerializeField]
    private UnityEvent onFall;
    [SerializeField]
    private UnityEvent onLoseLife;
    [SerializeField]
    public UnityEvent onWin;
    public void Initialize()
    {
        onInitialize?.Invoke();
    }
    public void Die()
    {
        onDie?.Invoke();
    }
    public void Fall()
    {
        onFall?.Invoke();
    }
    public void LoseLife()
    {
        onLoseLife?.Invoke();
    }
    public void Win()
    {
        onWin?.Invoke();
    }
}
