using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{

	public Transform target;

	void Update() {
		if(target) transform.LookAt(target, Vector3.up);
	}

    private void OnTriggerEnter(Collider other)
    {
    	target = other.transform;
    }

    //When the Primitive exits the collision, it will change Color
    private void OnTriggerExit(Collider other)
    {
    	target = null;
    }
}
