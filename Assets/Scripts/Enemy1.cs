using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehavTree;

[RequireComponent(typeof(NavMeshAgent))]

public class Enemy : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints = new();
    public GameObject player;
    public GameObject sword;
    NavMeshAgent agent;
    BehaviourTree tree;
    private int timer;
    void Awake()
    {
        timer = 0;
        Debug.Log("Hi");
        agent = GetComponent<NavMeshAgent>();

        tree = new BehaviourTree("Enemy");
        tree.AddChild(new Leaf("Patrol", new PatrolStrategy(transform, agent, waypoints)));
    }

    void Update()
    {
        timer += 1;
        float distancetoplayer = Vector3.Distance(this.transform.position, player.transform.position);
        float distance2sword = Vector3.Distance(this.transform.position, sword.transform.position);
        //Debug.Log(distancetoplayer);
        //do spherecast2d, if player is in it, change target. if not, go back to waypoints
        if (distancetoplayer > 5)
        {
            tree.Process();
        }
        else
        {
            //go to player
            //Debug.Log("Hi im near");
            this.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);

            if (distancetoplayer < 0.5 && timer >= 300)
            {
                Debug.Log("PlayerDamage");
                //hurtplayer
                timer = 0;
            }

            if (distance2sword < 0.5 && sword.gameObject.activeInHierarchy == true)
            {
                Debug.Log("EnemyDamage");

            }


        }


    }

   
}