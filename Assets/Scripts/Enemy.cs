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
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        
        tree = new BehaviourTree("Enemy");
        tree.AddChild(new Leaf("Patrol", new PatrolStrategy(transform, agent, waypoints)));
    }

    void Update()
    {
        tree.Process();
    }
}
