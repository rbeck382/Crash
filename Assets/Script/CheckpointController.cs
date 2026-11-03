using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    [SerializeField]
    private Transform startPoint;
    [SerializeField]
    private Transform player;
    private CharacterController characterController;
    private Transform currentCheckPoint;
    public Transform CurrentCheckpoint { set { currentCheckPoint = value; } }
    private void Awake()
    {
        currentCheckPoint = startPoint;
        characterController = player.GetComponent<CharacterController>();
    }
    public void MovePlayerToCheckpoint()
    {
        characterController.enabled = false;
        player.position = currentCheckPoint.position;
        characterController.enabled = true;
    }

}
