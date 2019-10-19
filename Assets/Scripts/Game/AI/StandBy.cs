using AI;
using UnityEngine;
using UnityEngine.AI;
public class StandBy : Node
{
    NavMeshAgent agent;
    public override void Execute()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(agent.gameObject.transform.position);


    }
}