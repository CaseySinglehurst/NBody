using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour {
    public GameObject spawner;

    public ObjectSpawnerScript spawnScript;

    public float mass = 0;
    public float startMovement = 5000f;

    public float gravityConstant = 100f;

    private Rigidbody thisBody;
    
    // Use this for initialization
    void Start () {
        mass = Random.Range(1, 100);
        
        

            thisBody = GetComponent<Rigidbody>();
        thisBody.AddForce(new Vector3(Random.Range(-startMovement, startMovement), Random.Range(-startMovement, startMovement), Random.Range(-startMovement, startMovement)));

        spawner = GameObject.FindGameObjectWithTag("GameController");
        spawnScript = spawner.GetComponent<ObjectSpawnerScript>();
        
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.localScale = Vector3.Lerp(this.gameObject.transform.localScale, new Vector3(Mathf.Pow(mass,0.5f), Mathf.Pow(mass,0.5f), Mathf.Pow(mass,0.5f)), 3 * Time.deltaTime);
        thisBody.mass = mass;
        foreach (GameObject body in spawnScript.bodies)
        {
            if (body != this.gameObject && body != null)
            {
                float gravForce = ((mass * body.GetComponent<BodyController>().mass) /Mathf.Pow(Vector3.Distance(transform.position,body.gameObject.transform.position),2)) * gravityConstant;
                Vector3 direction = Vector3.Normalize(body.gameObject.transform.position - transform.position);
                thisBody.AddForce(direction * gravForce);
            }
        }
        
	}


    void OnCollisionEnter(Collision col)
    {
        float otherMass = col.gameObject.GetComponent<BodyController>().mass;


        
            if (otherMass <= mass)
            {
                thisBody.AddForce(col.gameObject.GetComponent<Rigidbody>().velocity);
                mass += otherMass;
                Destroy(col.gameObject);
            }
        
        
        
        
    }
    
}
