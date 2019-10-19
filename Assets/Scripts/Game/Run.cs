using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
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
                Destroy(portador.GetComponent<FastRun>());

                GetComponent<SphereCollider>().enabled = true;
                GetComponent<SphereCollider>().enabled = true;

                Vector3 posicion = new Vector3(Random.Range(-20f, 20f), 0.3f, Random.Range(-20f, 20f));
                transform.position = posicion;

                portador.GetComponent<PlayerController>().HasFastRun = false;

            }

            run = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.GetComponent<PlayerController>().IsTagged == true && other.GetComponent<PlayerController>().HasFastRun == false)
        {

            portador = other.gameObject;
            other.gameObject.AddComponent<FastRun>();
            currentTime = 0;
            GetComponent<SphereCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            other.GetComponent<PlayerController>().HasFastRun = true;
            run = true;
        }

    }
}