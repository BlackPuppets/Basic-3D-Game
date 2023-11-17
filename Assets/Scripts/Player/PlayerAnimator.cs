using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement playerMovement;

    private const string IDLE = "a_Idle";
    private const string RUNNING = "a_Running";
    private const string RUNNING_FAST = "a_Running";
    private const string JUMPING = "a_Jumping";
    private const string DEAD = "a_Dead";

    private void Awake()
    {
        animator = GetComponent<Animator>();

        playerMovement = GetComponent<PlayerMovement>();
        playerMovement.OnIdleEvent += OnIdleAnimation;
        playerMovement.OnRunningEvent += OnRunningAnimation;
        playerMovement.OnRunningFastEvent += OnRunningFastAnimation;
        playerMovement.OnJumpingEvent += OnJumpingAnimation;
        playerMovement.OnDeathEvent += OnDeathAnimation;
    }

    private void OnIdleAnimation()
    {
        animator.Play(IDLE);
        animator.speed = 1;
    }

    private void OnRunningAnimation()
    {
        animator.Play(RUNNING);
        animator.speed = 1;
    }

    private void OnRunningFastAnimation()
    {
        animator.Play(RUNNING_FAST);
        animator.speed = 2;
    }

    private void OnJumpingAnimation()
    {
        animator.Play(JUMPING);
        animator.speed = 1;
    }

    private void OnDeathAnimation()
    {
        animator.Play(DEAD);
        animator.speed = 1;
    }
}
