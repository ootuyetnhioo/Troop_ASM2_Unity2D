using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickupGold : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    [SerializeField] private int coinPickup = 100;

    private bool wasCollected = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && !wasCollected)
        {
            wasCollected = true;
            FindObjectOfType<Coins>().AddToScoreGold(coinPickup);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
