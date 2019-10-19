using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField] GameObject[] powerUps;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 posicion = new Vector3(Random.Range(-20f, 20f), 0, Random.Range(-20f, 20f));

        GameObject invisibilityCoat1 = Instantiate(powerUps[0], posicion, Quaternion.identity);

        posicion = new Vector3(Random.Range(-20f, 20f), 0, Random.Range(-20f, 20f));

        GameObject invisibilityCoat2 = Instantiate(powerUps[0], posicion, Quaternion.identity);

        posicion = new Vector3(Random.Range(-20f, 20f), 0, Random.Range(-20f, 20f));

        GameObject fastRun1 = Instantiate(powerUps[1], posicion, Quaternion.identity);

        posicion = new Vector3(Random.Range(-20f, 20f), 0, Random.Range(-20f, 20f));

        GameObject fastRun2 = Instantiate(powerUps[1], posicion, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
      

    }
}
