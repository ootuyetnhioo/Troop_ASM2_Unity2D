using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private EnemyPatrol enemyPatrol;
    public GameObject player;
    [SerializeField] private Transform enemy;

    private float _characterCurrentSpeed;

    void Start()
    {
        enemyPatrol = FindObjectOfType<EnemyPatrol>();
    }

    private bool PlayerInteractionArea()
    {
        float distance = Vector3.Distance(enemyPatrol.leftEdge.position, enemyPatrol.rightEdge.position);
        return Vector3.Distance(transform.position, player.transform.position) < distance;
    }

    private Vector2 WhichDirectionPlayer()
    {
        float value = transform.position.x - player.transform.position.x;

        if (value < 0)
        {
            return new Vector2(-1, 1);
        }
        else if (value > 0)
        {
            return new Vector2(1, 1);
        }

        return Vector2.zero;
    }

    public void CharacterMove()
    {
        if (PlayerInteractionArea())
        {
            Vector2 localScale = WhichDirectionPlayer();
            short velocityValue = 0;

            if (localScale.x < 0)
            {
                velocityValue = -1;
            }
            else if (localScale.x > 0)
            {
                velocityValue = 1;
            }

            transform.localScale = localScale;

            Vector3 newPosition = transform.position + new Vector3(_characterCurrentSpeed * Time.deltaTime * velocityValue, 0, 0);
            transform.position = newPosition;
        }
    }
}