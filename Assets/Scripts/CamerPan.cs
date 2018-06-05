using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CamerPan : MonoBehaviour {

    GameObject player;

    public float panSpeed = 50f;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}

    private void LateUpdate()
    {
        transform.LookAt(player.transform.position);        
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        float inputH = CrossPlatformInputManager.GetAxis("RHorizontal");
        float inputV = CrossPlatformInputManager.GetAxis("RVertical");
        Debug.Log(inputH+inputV);
        Vector3 turnDir = new Vector3(inputV, inputH, 0);

        transform.RotateAround(player.transform.position, turnDir, panSpeed*Time.deltaTime);

        //transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
    }
}
