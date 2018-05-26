using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CamerPan : MonoBehaviour {

    GameObject player;

    public float panSpeed = 10f;

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
        float inputH = CrossPlatformInputManager.GetAxis("RHorizontal");
        float inputV = CrossPlatformInputManager.GetAxis("RVertical");

        Vector3 turnDir = new Vector3(inputV, inputH, 0);


        transform.RotateAround(player.transform.position, turnDir, panSpeed*Time.deltaTime);
    }
}
