using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LeaderboardManager manager;

    [Header("Основной контроллер")]
    public float gravity;
    public Vector2 velocity;
    public float jumpVelocity = 20;
    public float groundHeight = 10;
    public bool isGrounded = false;

    public bool isHoldingJump = false;
    public float maxHoldJumpTime = 0.4f;
    public float holdJumpTimer = 0.0f;

    public float jumpGroundThreshold = 1;

    public GameObject deathPanel;
    public GameObject[] backGround;

    public Count count;

    [Header("Подкаты")]
    public Transform rollObj;
    public float rollAngle = 27f; // Угол поворота по оси Z в градусах
    public float rollSpeed = 5f; // Скорость поворота
    public float rollDuration = 1.5f; // Длительность ускорения в секундах
    public KeyCode rollKey = KeyCode.S; // Клавиша для запуска подкатов

    private bool isRolling = false;
    private float rollTimer = 0f;
    private float initialSpeed;

    [Header("Анимации")]
    public Animator animatorcONTROLLER;

    private const string ScoreKey = "score";

    void Start()
    {
        initialSpeed = GetComponent<Rigidbody2D>().velocity.magnitude;
    }

    void Update()
    {
        Vector2 pos = transform.position;
        float groundDistance = Mathf.Abs(pos.y - groundHeight);

        if (isGrounded || groundDistance <= jumpGroundThreshold)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGrounded = false;
                velocity.y = jumpVelocity;
                isHoldingJump = true;
                holdJumpTimer = 0;
                animatorcONTROLLER.SetBool("fly", true);
            }
            if (Input.GetKeyDown(rollKey) && !isRolling)
            {
                isRolling = true;
                rollTimer = 0f;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if(!isRolling)
            {
                isHoldingJump = false;
            }
        }

        if (isRolling)
        {
            gravity = 0f;

            float rollProgress = Mathf.Clamp01(rollTimer / rollDuration);
            float rollAngleCurrent = Mathf.Lerp(0f, rollAngle, rollProgress);
            float rollSpeedCurrent = Mathf.Lerp(initialSpeed * 2f, initialSpeed * 2f, rollProgress);

            rollObj.rotation = Quaternion.Euler(0f, 0f, rollAngleCurrent);
            GetComponent<Rigidbody2D>().velocity = transform.right * rollSpeed;

            rollTimer += Time.deltaTime;

            isGrounded = false;

            if (rollTimer >= rollDuration)
            {
                gravity = -15f;
                isGrounded = true;
                isRolling = false;
                rollObj.rotation = Quaternion.identity;
                GetComponent<Rigidbody2D>().velocity = transform.right * initialSpeed;
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        if (!isGrounded)
        {
            if (isHoldingJump)
            {
                holdJumpTimer += Time.fixedDeltaTime;
                if (holdJumpTimer >= maxHoldJumpTime)
                {
                    isHoldingJump = false;
                }
            }


            pos.y += velocity.y * Time.fixedDeltaTime;
            if (!isHoldingJump)
            {
                velocity.y += gravity * Time.fixedDeltaTime;
            }

            if (pos.y <= groundHeight)
            {
                pos.y = groundHeight;
                isGrounded = true;
            }
        }


        transform.position = pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            isGrounded = true;
            animatorcONTROLLER.SetBool("fly", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Death"))
        {
            OnDeath();
        }
        if(collision.gameObject.CompareTag("JB"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(time());
        }
    }
    void OnDeath()
    {
        PlayerPrefs.SetInt(ScoreKey,count.count);
        manager.InsertScore(PlayerPrefs.GetString("player_name") , PlayerPrefs.GetInt("score"));

        deathPanel.SetActive(true);
        gameObject.GetComponent<Rigidbody2D>().simulated = false;
        for (int i = 0; i < backGround.Length; i++)
        {
            backGround[i].GetComponent<BackgroundHelper>().enabled = false;
        }
        gameObject.GetComponent<MoveCharacter>().enabled = false;
        count.isCount = false;
        count.death.text = count.count.ToString();
    }
    IEnumerator time()
    {
        jumpVelocity = 25;
        yield return new WaitForSeconds(3f);
        jumpVelocity = 15;
        yield break;
    }
}
