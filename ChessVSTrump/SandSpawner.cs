using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandSpawner : MonoBehaviour
{
    public GameObject sandObject;

    private void Start()
    {
        SpawnSand();
    }

    void SpawnSand()
    {
        GameObject mySand = Instantiate(sandObject, new Vector3(Random.Range(-0.3f, 0f), 1, 0),Quaternion.identity);
        mySand.GetComponent<SandResource>().dropToYPos = Random.Range(0.1f, -0.5f);
        Invoke("SpawnSand", 10);
    }
}
