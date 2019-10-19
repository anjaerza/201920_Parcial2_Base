using AI;
using UnityEngine;

public class IsTaggedActorNear : SelectWithOption
{
    [SerializeField] GameObject taggedPlayer;

    public GameObject TaggedPlayer { get => taggedPlayer; set => taggedPlayer = value; }

    protected override bool Check()
    {
     
        bool resultado = false;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach(GameObject objetivo in players)
        {
            if(objetivo.GetComponent<PlayerController>().IsTagged)
            {
                taggedPlayer = objetivo;
            }
        }

        if (taggedPlayer!=null && Vector3.Distance(transform.position, TaggedPlayer.transform.position) <= 10f)
        {
            resultado = true;
            Debug.Log("Está Cerca al tagged");
        }

            return resultado;
    }
}