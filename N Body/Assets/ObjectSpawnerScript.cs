using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerScript : MonoBehaviour {

    public GameObject body;

    public GameObject[] bodies = new GameObject[10];


	// Use this for initialization
	void Start () {
		for (int i = 0; i < bodies.Length; i++)
        {
            bodies[i] = Instantiate(body, new Vector3(Random.Range(-1000f, 1000f), Random.Range(-1000f, 1000f), Random.Range(-1000f, 1000f)), Quaternion.identity);
            
            

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
