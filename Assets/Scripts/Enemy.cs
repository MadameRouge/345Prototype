using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehavTree;

[RequireComponent(typeof(NavMeshAgent))]

public class Enemy : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints = new();
    NavMeshAgent agent;
    BehaviourTree tree;
    private GameObject manager;
    public GameObject player;
    public GameObject sword;
    //Attack Timer to prevent the enemy dealing an insane amount of damage instantly
    private int timer;

    //Enemy stats
    public int damage = 5;
    public int maxHealth = 50;
    private int currentHealth;
    void Awake()
    {
        timer = 0;
        Debug.Log("Enemy is active");
        agent = GetComponent<NavMeshAgent>();
        tree = new BehaviourTree("Enemy");
        tree.AddChild(new Leaf("Patrol", new PatrolStrategy(transform, agent, waypoints)));
    }

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
        manager.GetComponent<Manager>().SpawnedCount();
        currentHealth = maxHealth;
    }

    void Update()
    {
        timer += 1;
        float distancetoplayer = Vector3.Distance(this.transform.position, player.transform.position);
        float distance2sword = Vector3.Distance(this.transform.position, sword.transform.position);
        if (distancetoplayer > 5)
        {
            tree.Process();
        }
        else
        {
            this.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);

            if (distancetoplayer < 0.5 && timer >= 300)
            {
                //If the attack timer is low enough, the enemy will deal damage to the player and then begin a attack timer.
                player.GetComponent<PlayerAttack>().TakeDamage(damage);
                timer = 0;
                Debug.Log("Enemy has dealt damage to player");
            }

            if (distance2sword < 0.5 && sword.gameObject.activeInHierarchy == true)
            {
                EnemyHurt(5);
                Debug.Log("EnemyDamaged");
            }
        }
    }

    public void EnemyHurt(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy lost: " + damage + ("Health"));
        if (currentHealth <= 0)
        {
            EnemyDeath();
        }    
    }
    private void EnemyDeath()
    {
        Debug.Log("Enemy has been defeated.");
        manager.GetComponent<Manager>().DefeatedCount();
        Destroy(gameObject);
    }
}