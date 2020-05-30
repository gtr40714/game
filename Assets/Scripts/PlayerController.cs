using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMovable
{
	public Vector3 dir = Vector3.zero;
	public float speed = 5;
}

public class PlayerUtility
{
	public static void updateDirection(BaseMovable movable)
	{
		// Vector3 dir = Vector3.zero;
		if(Input.GetKeyDown("w"))
	    {
			// dir = transform.forward;
			movable.dir = Vector3.forward;
	    }
	    else if(Input.GetKeyUp("w"))
	    {
	    	movable.dir = Vector3.zero;
	    }
	    else if(Input.GetKeyDown("s"))
	    {
			// dir = -transform.forward;
	    	movable.dir = -Vector3.forward;
	    }
	    else if(Input.GetKeyUp("s"))
	    {
			movable.dir = Vector3.zero;
	    }
	    if(Input.GetKeyDown("a"))
	    {
			movable.dir += Vector3.left;
	    }
	    else if(Input.GetKeyUp("a"))
	    {
	    	movable.dir = Vector3.zero;
	    }
	    else if(Input.GetKeyDown("d"))
	    {
			movable.dir -= Vector3.left;
	    }
	    else if(Input.GetKeyUp("d"))
	    {
			movable.dir = Vector3.zero;
	    }
	    movable.dir = movable.dir.normalized;
	}
}

public class Player : BaseMovable
{
}

public class PlayerController : MonoBehaviour
{

	CharacterController controller;
	// Vector3 dir = Vector3.zero;
	Player player = new Player();

	void updateByObject() {
		
	   	PlayerUtility.updateDirection(player);
	    controller.Move(player.dir * player.speed * Time.deltaTime);
	}
	
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
       updateByObject();
    }
}
