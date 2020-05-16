using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{

	public GameObject lightGameObject;
	public Light light;

    void Awake()
    {
        lightGameObject = transform.Find("Point Light").gameObject;
        // lightGameObject.SetActive(false);
        light = lightGameObject.GetComponent<Light>();
        light.intensity = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
    	// lightGameObject.SetActive(true);
    	float dist = Vector3.Distance(other.transform.position, transform.position);
    	light.intensity = Mathf.Sqrt(.3f * dist);
    	 Debug.Log(dist);
    }

    //When the Primitive exits the collision, it will change Color
    private void OnTriggerExit(Collider other)
    {
    	// lightGameObject.SetActive(false);
    	light.intensity = 0;
    }
}
