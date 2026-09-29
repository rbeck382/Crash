using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private int coinValue = 1;
    public int CoinValue => coinValue;
    [SerializeField]
    private GameObject coinEffectPrefab;
    public void onGrabbed()
    {
        PoolManager.instance.GetObject(coinEffectPrefab, transform.position);
        gameObject.SetActive(false);
    }

}
