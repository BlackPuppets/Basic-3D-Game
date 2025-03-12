using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Clothes;

public class PlayerMovement : MonoBehaviour, IDamageable
{
    private CharacterController characterController;
    [SerializeField] private float startingHealth = 10f;
    [SerializeField] private float currentHealth;
    [SerializeField] private float speed = 25f;
    [SerializeField] private float runningSpeed = 40f;
    [SerializeField] private float turnSpeed = 1f;
    [SerializeField] private float jumpSpeed = 15f;
    [SerializeField] private float playerDamageMultiplier = 1f;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private Slider playerHealth;
    [SerializeField] private ClotheChanger clothesChanger;

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

    public static PlayerMovement instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        characterController = GetComponent<CharacterController>();
        currentHealth = startingHealth;
        if(clothesChanger == null)
            clothesChanger = GetComponentInChildren<ClotheChanger>();
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

    public void ResetLife()
    {
        currentHealth = startingHealth;
        playerHealth.value = currentHealth / startingHealth;
    }

    private void Revive()
    {
        TakeDamage(-startingHealth);
        Respawn();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage * playerDamageMultiplier;
        playerHealth.value = currentHealth / startingHealth;
        EffectsManager.GetInstance().ChangeVinette();
        ShakeCamera.GetInstance().Shake(5,5,0.3f);
        if (currentHealth <= 0)
        {
            Revive();
            //Destroy(gameObject);
        }
    }

    private void Respawn()
    {
        if (CheckpointManager.GetInstance().HasCheckpoint())
        {
            characterController.enabled = false;
            this.transform.position = CheckpointManager.GetInstance().GetPositionFromLastCheckpoint();
            characterController.enabled = true;
        }
    }

    public void ChangePlayerSpeed(float speed, float duration)
    {
        StartCoroutine(ChangePlayerSpeedCoroutine(speed, duration));
    }

    IEnumerator ChangePlayerSpeedCoroutine(float localSpeed, float duration)
    {
        var defaultSpeed = speed;
        speed = localSpeed;
        yield return new WaitForSeconds(duration);
        speed = defaultSpeed;
    }

    public void ChangePlayerClothes(ClothSetup setup, float duration)
    {
        StartCoroutine(ChangePlayerClothesCoroutine(setup, duration));
    }

    IEnumerator ChangePlayerClothesCoroutine(ClothSetup setup, float duration)
    {
        clothesChanger.ChangeClothe(setup);
        yield return new WaitForSeconds(duration);
        clothesChanger.ResetTexture();
    }

    public void ChangePlayerDamageMultiplier(float damageMultiplier, float duration)
    {
        StartCoroutine(ChangePlayerDamageMultiplierCoroutine(damageMultiplier, duration));
    }

    IEnumerator ChangePlayerDamageMultiplierCoroutine(float damageMultiplier, float duration)
    {
        var defaultDamageMultiplier = playerDamageMultiplier;
        playerDamageMultiplier = damageMultiplier;
        yield return new WaitForSeconds(duration);
        playerDamageMultiplier = defaultDamageMultiplier;
    }

}
