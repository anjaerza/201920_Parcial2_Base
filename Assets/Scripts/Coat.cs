using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coat : MonoBehaviour
{
    [SerializeField] private float currentTime;
    private const float MAXTIME = 10;
    GameObject portador;
    bool run = false;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (run)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= MAXTIME)
            {
                Destroy(portador.GetComponent<Invisibility>());

                GetComponent<SphereCollider>().enabled = true;
                GetComponent<SphereCollider>().enabled = true;

                Vector3 posicion = new Vector3(Random.Range(-20f, 20f), 0.3f, Random.Range(-20f, 20f));
                transform.position = posicion;

                portador.GetComponent<PlayerController>().HasCoat = false;
                portador.tag="Player";


            }
            run = false;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.GetComponent<PlayerController>().IsTagged == false && other.GetComponent<PlayerController>().HasCoat == false)
        {

            portador = other.gameObject;
            other.gameObject.AddComponent<Invisibility>();
            currentTime = 0;
            GetComponent<SphereCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            other.GetComponent<PlayerController>().HasCoat = true;
            run = true;
        }
            
    }
}
