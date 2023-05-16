using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public PlayerController playerController;
    public int coins = 0;

    private bool isJumpBoosted = false;
    private float jumpBoostTimeLeft = 0f;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("coin"))
        {
            coins++;
            coinText.text = coins.ToString();
            Destroy(collider.gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && coins >= 15)
        {
            coins -= 15;
            playerController.jumpVelocity = 25;
            isJumpBoosted = true;
            jumpBoostTimeLeft = 2f;
            coinText.text = coins.ToString();
        }

        if (isJumpBoosted)
        {
            jumpBoostTimeLeft -= Time.deltaTime;
            if (jumpBoostTimeLeft <= 0f)
            {
                playerController.jumpVelocity = 15;
                isJumpBoosted = false;
            }
        }
    }
}
