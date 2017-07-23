using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCont : MonoBehaviour {

    private float speed = 5f;
    private GameObject crossHair;
    public GameObject wbPrefab;
    public Transform wbSpawn;

	// Use this for initialization
	void Start () {
        crossHair = GameObject.Find("reticle");
        toggleRetVis(true);
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            toggleRetVis(true);
            aim();
        }

        else
        {
            toggleRetVis(false);
            movement();
        }
        
        if(Input.GetKeyUp(KeyCode.Space))
        {
            fire();
        }
    }

    //controls reticle movement
    void aim()
    {
        if (Input.GetKey(KeyCode.D))
        {
            crossHair.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            crossHair.transform.Translate(-Vector2.right * speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.W))
        {
            crossHair.transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            crossHair.transform.Translate(-Vector2.up * speed * Time.deltaTime);
        }

    }

    void fire()
    {
        var wb = (GameObject)Instantiate(wbPrefab, wbSpawn.position, wbSpawn.rotation);
        wb.GetComponent<Rigidbody2D>().velocity = wb.transform.up * 6;
        Destroy(wb, 2.0f);
    }


    //controls reticle visibility and resets position
    void toggleRetVis(bool hideMe)
    {
        crossHair.GetComponent<Renderer>().enabled = hideMe;

        if (hideMe == false)
        {
            crossHair.transform.position = Vector2.Lerp(crossHair.transform.position, transform.position, 1);
        }
        
    }

    //controls sprite movement
    void movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector2.up * speed * Time.deltaTime);
        }

    }

}
