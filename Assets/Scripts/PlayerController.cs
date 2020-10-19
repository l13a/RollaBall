using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 0; //if public, can find in inspector
	private Rigidbody rb;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
    	rb = GetComponent<Rigidbody>(); //get the rigitbody compoenent from the game object player(which exists since you "added compoenent" earlier)
        
    }

    void OnMove(InputValue movementValue)
    {
    	Vector2 movementVector = movementValue.Get<Vector2>(); //get a 2 dim vector from input
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY); //the f after 0.0 shows that this is float
    	rb.AddForce(movement * speed);
    }

}
