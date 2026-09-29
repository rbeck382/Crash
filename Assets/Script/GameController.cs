using UnityEngine;

public class GameContyroller : MonoBehaviour
{
    [SerializeField]
    private CoinsController coinsController;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform startPosition;
    private void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        coinsController.Initialize();
        player.position = startPosition.position;
    }

}
