using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0; //if public, can find in inspector
    public TextMeshProUGUI countText;//reference to the UI text gameobject
    public GameObject winTextOject;
	private Rigidbody rb;
    //store the num of scores
    private int count;
    private float movementX;
    private float movementY;


    // Start is called before the first frame update
    void Start()
    {
    	rb = GetComponent<Rigidbody>(); //get the rigitbody compoenent from the game object player(which exists since you "added compoenent" earlier)
        count = 0;
        
        SetCountText();
        winTextOject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
    	Vector2 movementVector = movementValue.Get<Vector2>(); //get a 2 dim vector from input
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText(){//method to display count
        countText.text = "Count: " + count.ToString();
        if(count >= 8){
            winTextOject.SetActive(true);
        }
    }

    void FixedUpdate()//same update??
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY); //the f after 0.0 shows that this is float
    	rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other){//when triggered, do this
        //deactive the SEPECIFIC tagged gameobjects when in contact (no collision)
        if(other.gameObject.CompareTag("PickUp")){
            other.gameObject.SetActive(false);//but dont know which game object(only the rotating cubes) to ddisable? use unity tag system
            count = count + 1;
            SetCountText();
        }
       
    }

}
