using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{

	public GameObject lightGameObject;
	public Light lightObj;

    void Awake()
    {
        lightGameObject = transform.Find("Point Light").gameObject;
        // lightGameObject.SetActive(false);
        lightObj = lightGameObject.GetComponent<Light>();
        lightObj.intensity = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
    	// lightGameObject.SetActive(true);
    	float dist = Vector3.Distance(other.transform.position, transform.position);
    	lightObj.intensity = Mathf.Sqrt(.3f * dist);
        Debug.Log(dist);
    }

    //When the Primitive exits the collision, it will change Color
    private void OnTriggerExit(Collider other)
    {
    	// lightGameObject.SetActive(false);
    	lightObj.intensity = 0;
    }
}
