using AI;
using UnityEngine;

public class IsActorTagged : SelectWithOption
{
    [SerializeField] bool result;

    protected override bool Check()
    {
        result = false;
        if (GetComponent<PlayerController>().IsTagged)
        {
            result = true;
        }

        return result;
   
    }
}