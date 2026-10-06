using System;
using UnityEngine;
using UnityEngine.Events;

public class GameContyroller : MonoBehaviour
{
    [SerializeField]
    private CoinsController coinsController;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform startPosition;
    [SerializeField]
    private UnityEvent onGameStart;
    private void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        coinsController.Initialize();
        player.position = startPosition.position;
        onGameStart?.Invoke();
    }

}
