using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected Animator characterAnimator;
    [SerializeField]
    private GameObject hitParticles;
    public GameObject HitParticles => hitParticles;
    private Collider enemyCollider;
    protected bool isAlive = true;
    private void Awake()
    {
        enemyCollider = GetComponent<Collider>();
    }
    protected virtual void OnEnable()
    {
        isAlive = true; 
        enemyCollider.enabled = true;
    }
    public void Die()
    {
        isAlive = false;
        enemyCollider.enabled=false;
    }
}
