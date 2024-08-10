using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour
{
    public GameObject playerSword;
    public Transform swordHolder;
    public Transform attackPoint;
    public GameObject enemy;

    public int playerMaxHealth = 100;
    public int playerCurrentHealth;
    public int playerAttackDamage = 10;
    public int playerAttackCooldown = 1;
    public float playerAttackRange = 4f;

    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }
    void Update()
    {

        if(Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("Player swings weapon");
            playerSword.SetActive(true);
        }
        else
        {
            playerSword.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        playerCurrentHealth -= damage;
        Debug.Log("Player took: " + damage + " damage.");
        if (playerCurrentHealth <= 0)
        {
            PlayerDeath();
        }
    }

    private void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, playerAttackRange);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().EnemyHurt(playerAttackDamage);
            Debug.Log("Player hit the enemy and dealt: " + playerAttackDamage);
        }
    }

    private void PlayerDeath()
    {
        Debug.Log("Player has died, moving to defeat screen.");
        SceneManager.LoadScene("DefeatScene");
    }
}