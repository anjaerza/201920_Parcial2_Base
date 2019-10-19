using AI;
using UnityEngine;
public class GetNearestTarget : Node
{
    GameObject[] players;
    [SerializeField]GameObject target;

    public GameObject Target { get => target; set => target = value; }

    public override void Execute()
    {
        players = GameObject.FindGameObjectsWithTag("Player");

        Target = players[0];

        foreach(GameObject jugador in players)
        {
            if(jugador.transform.position != transform.position && Vector3.Distance(jugador.transform.position,transform.position) < Vector3.Distance(Target.transform.position, transform.position))
            {
                Target = jugador;
                //Debug.Log("el jugador " + gameObject.name + " está cerca de " + target.name);
            }
                
        }
    }
}