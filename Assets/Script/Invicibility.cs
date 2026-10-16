using UnityEngine;

[RequireComponent (typeof(Blink))]
public class Invicibility : MonoBehaviour
{
    [SerializeField]
    private float invicibilityDuration;
    [SerializeField]
    private float ghostDuration;
    private bool isInvicible;
    private bool isGhost;
    public bool IsInvicible => isInvicible;
    public bool IsGhost => isGhost;
    private Blink playerBlink;
    private void Awake()
    {
        playerBlink = GetComponent<Blink>();
    }
    public void Initialize()
    {
        isInvicible = false;
        isGhost = false;
    }
    public void Kill()
    {
        isGhost = true;
        isInvicible = false;
    }
    public void ActivateGhost()
    {
        playerBlink.StartBlink(ghostDuration);
        isGhost = true;
        Invoke(nameof(EndGhost), ghostDuration);
    }
    public void EndGhost()
    {
        isGhost = false;
    }
}
