using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; //reference for player
    private Vector3 offset; //store the offset
    // Start is called before the first frame update
    void Start()
    {
        //offset needs to be calculated once at the start
        offset = transform.position - player.transform.position; //camera's position - players
    }

    // Update is called once per frame
    void LateUpdate()//will call after all the updates are done
    {
        transform.position = player.transform.position + offset;//only match position, not rotation
    }
}
