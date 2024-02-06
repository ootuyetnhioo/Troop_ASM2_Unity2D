using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [SerializeField] float speedNPC = 5f;
    [SerializeField] float targetPosition;
    [SerializeField] Transform playerTransform;
    [SerializeField] private AudioClip runningSound;

    public int ironCount;
    public int goldCount;
    public Canvas canvasNPC;
    [SerializeField] Text ironText;
    [SerializeField] Text goldText;

    Rigidbody2D rb;
    Animator anima;
    Transform target;
    public bool isInteract = false;
    private bool isSoundPlay = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        ShowIronGold();
    }

    void Update()
    {
        if (isInteract == true)
        {
            FlipSprite();
            TargetFollow();
        }
    }

    public void TargetFollow()
    {
        if (Vector2.Distance(transform.position, target.position) > targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speedNPC * Time.deltaTime);
            anima.SetBool("NPC_Run", true);
            float npcX = transform.position.x;
            if (npcX != 0)
            {
                RunningSound();
            }
            else
            {
                StopRunningSound();
            }
        }
        else
        {
            anima.SetBool("NPC_Run", false);
        }
    }

    public void FlipSprite()
    {
        if (playerTransform.localScale.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.position = Vector2.MoveTowards(transform.position, target.position - new Vector3(targetPosition, 0, 0), speedNPC * Time.deltaTime);
            float npcX = transform.position.x;
            if (npcX != 0)
            {
                RunningSound();
            }
            else
            {
                StopRunningSound();
            }
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.position = Vector2.MoveTowards(transform.position, target.position + new Vector3(targetPosition, 0, 0), speedNPC * Time.deltaTime);
            float npcX = transform.position.x;
            if (npcX != 0)
            {
                RunningSound();
            }
            else
            {
                StopRunningSound();
            }
        }

        if (playerTransform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (playerTransform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void ShowIronGold()
    {
        ironText.text = ironCount.ToString();
        goldText.text = goldCount.ToString();
    }
    private void StopRunningSound()
    {
        if (isSoundPlay)
        {
            isSoundPlay = false;
        }
    }
    private void RunningSound()
    {
        if (!isSoundPlay)
        {
            isSoundPlay = true;
            SoundManager.instance.PlaySound(runningSound);
        }
    }
}