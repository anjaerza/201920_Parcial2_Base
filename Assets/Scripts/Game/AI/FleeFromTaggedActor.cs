using AI;
using UnityEngine;
using UnityEngine.AI;

public class FleeFromTaggedActor : Node
{
    [SerializeField] GameObject taggedPlayer;
    NavMeshAgent agent;
    public override void Execute()
    {
        taggedPlayer = GetComponent<IsTaggedActorNear>().TaggedPlayer;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(-taggedPlayer.transform.position);
    }
}