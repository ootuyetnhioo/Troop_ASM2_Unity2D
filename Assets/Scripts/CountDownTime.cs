using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDownTime : MonoBehaviour
{
    [SerializeField] int timeScene = 1;
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] GameObject countdown;
    bool isCoolDown;
    private Coroutine timeCoroutine;

    void Start()
    {
        isCoolDown = false;
        timeCoroutine = StartCoroutine(TimeCoroutine());
    }

    bool IsEnemyDead()
    {
        return enemy.GetComponent<Health>().currentHealth <= 0;
    }

    IEnumerator TimeCoroutine()
    {
        if (!isCoolDown)
        {
            float currentTime = timeScene;
            isCoolDown = true;

            while (currentTime >= 0)
            {
                float minutes = Mathf.FloorToInt(currentTime / 60);
                float seconds = Mathf.FloorToInt(currentTime % 60);

                countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

                yield return new WaitForSeconds(1f);

                currentTime--;
                if(IsEnemyDead())
                {
                    countdown.SetActive(false);
                }
            }

            if (!IsEnemyDead())
            {
                player.GetComponent<Health>().currentHealth = 0;
                player.GetComponent<Health>().TakeDamage(1);
            }

            isCoolDown = false;
        }
    }
}