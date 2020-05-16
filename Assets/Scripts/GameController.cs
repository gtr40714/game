using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public GameObject camera;
	public int speed = 5;
	Vector3 dir = Vector3.zero;

	void moveForward() {
		transform.Translate(transform.forward);
	}

	void moveBackward() {
		transform.Translate(-transform.forward);
	}

	void updateByObject() {
		if(Input.GetKeyDown("w"))
	    {
			dir = transform.forward;
	    }
	    else if(Input.GetKeyUp("w"))
	    {
	    	dir = Vector3.zero;
	    }
	    else if(Input.GetKeyDown("s"))
	    {
			dir = -transform.forward;
	    }
	    else if(Input.GetKeyUp("s"))
	    {
			dir = Vector3.zero;
	    }
	    transform.Translate(dir * Time.deltaTime);
	}
	Vector3 calcLeft()
	{
		Vector3 camLeft = -camera.transform.right;
	    Vector3 left = new Vector3(camLeft.x, 0, camLeft.z);
	    return left;
	}

	Vector3 calcForward() {
		Vector3 cameForward = camera.transform.forward;
	    Vector3 forward = new Vector3(cameForward.x, 0, cameForward.z);
	    return forward;
	}

	void updateByCamera() {
		// Move forward & backward
		if(Input.GetKeyDown("w"))
	    {
			dir = calcForward();
	    }
	    else if(Input.GetKeyUp("w"))
	    {
	    	dir = Vector3.zero;
	    }
	    else if(Input.GetKeyDown("s"))
	    {
			dir = -calcForward();
	    }
	    else if(Input.GetKeyUp("s"))
	    {
			dir = Vector3.zero;
	    }
	    // Move left & right
	    if(Input.GetKeyDown("a"))
	    {
			dir += calcLeft();
	    }
	    else if(Input.GetKeyUp("a"))
	    {
	    	dir = Vector3.zero;
	    }
	    else if(Input.GetKeyDown("d"))
	    {
			dir -= calcLeft();
	    }
	    else if(Input.GetKeyUp("d"))
	    {
			dir = Vector3.zero;
	    }
	    dir = dir.normalized;
	    transform.Translate(dir * speed * Time.deltaTime);
	}

	void Awake() {
		camera = GameObject.FindWithTag("MainCamera");
	}

    // Update is called once per frame
    void Update()
    {
	    // updateByObject();
	    updateByCamera();

	}
}
