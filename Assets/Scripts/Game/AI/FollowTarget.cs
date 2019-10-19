using AI;
using UnityEngine;

public class FollowTarget : Node
{
    [SerializeField] GameObject objetivo;
    public override void Execute()
    {
        objetivo = GetComponent<GetNearestTarget>().Target;
        GetComponent<PlayerController>().GoToLocation(objetivo.transform.position);
    }
}