using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


    GameObject spawner;
    ObjectSpawnerScript spawnScript;
    public Material biggestMaterial, otherMaterial;

	// Use this for initialization
	void Start () {
        spawner = GameObject.FindGameObjectWithTag("GameController");
        spawnScript = spawner.GetComponent<ObjectSpawnerScript>();
    }
	
	// Update is called once per frame
	void LateUpdate () {
        GameObject currentBiggest;

        bool firstHasBeenAssigned = false;
        currentBiggest = null;
        float currentBiggestMass = 0;

        foreach (GameObject body in spawnScript.bodies)
        {
            if (body != null)
            {
                body.transform.GetComponent<Renderer>().material = otherMaterial;
                if (!firstHasBeenAssigned)
                {
                    currentBiggest = body;
                    currentBiggestMass = body.GetComponent<BodyController>().mass;
                    firstHasBeenAssigned = true;
                }
                float currentMass = body.GetComponent<BodyController>().mass;
                if (currentMass >= currentBiggestMass)
                {
                    currentBiggest = body;
                    currentBiggestMass = currentMass;
                }
            }
        }
        if (currentBiggest != null)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(currentBiggest.transform.position.x, currentBiggest.transform.position.y, currentBiggest.transform.position.z - 1000), 1 * Time.deltaTime);
        }
        currentBiggest.transform.GetComponent<Renderer>().material = biggestMaterial;

	}
    

}
