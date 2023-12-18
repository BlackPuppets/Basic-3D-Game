using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IDamageable
{
    private CharacterController characterController;
    [SerializeField] private float health = 10f;
    [SerializeField] private float speed = 25f;
    [SerializeField] private float runningSpeed = 40f;
    [SerializeField] private float turnSpeed = 1f;
    [SerializeField] private float jumpSpeed = 15f;
    [SerializeField] private float gravity = -9.8f;

    [SerializeField] private KeyCode jumpKeyCode = KeyCode.Space;
    [SerializeField] private KeyCode runKeyCode = KeyCode.LeftShift;

    private float vSpeed = 0f;

    public delegate void OnIdle();
    public event OnIdle OnIdleEvent;

    public delegate void OnRunning();
    public event OnRunning OnRunningEvent;

    public delegate void OnRunningFast();
    public event OnRunningFast OnRunningFastEvent;

    public delegate void OnJumping();
    public event OnJumping OnJumpingEvent;

    public delegate void OnDeath();
    public event OnDeath OnDeathEvent;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);

        CheckInput();

        characterController.Move(ApplySpeed() * Time.deltaTime);
    }

    private void CheckInput()
    {
        if (characterController.isGrounded)
        {
            vSpeed = 0;
            if (Input.GetKeyDown(jumpKeyCode))
            {
                vSpeed = jumpSpeed;
                OnJumpingEvent();
                return;
            }

            if (Input.GetAxis("Vertical") != 0)
            {
                if (Input.GetKey(runKeyCode))
                {
                    OnRunningFastEvent();
                    return;
                }
                OnRunningEvent();

            }
            else
                OnIdleEvent();
        }
    }

    private Vector3 ApplySpeed()
    {
        Vector3 currentSpeed = new Vector3();
        if(Input.GetKey(runKeyCode))
            currentSpeed = transform.forward * Input.GetAxis("Vertical") * runningSpeed;
        else
            currentSpeed = transform.forward * Input.GetAxis("Vertical") * speed;
        vSpeed -= gravity * Time.deltaTime;
        currentSpeed.y = vSpeed;

        return currentSpeed;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
