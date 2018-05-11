using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

    private Rigidbody myrigidbody;
    private const int bufferFrames = 100;
    myKeyFrame[] keyframes = new myKeyFrame[bufferFrames];

	// Use this for initialization
	void Start () {
        myrigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Record();
    }

    void PlayBack()
    {
        myrigidbody.isKinematic = true;
        int frame = Time.frameCount % bufferFrames;
        print("Reading time " + frame);
        transform.position = keyframes[frame].position;
        transform.rotation = keyframes[frame].roation;
    }

    private void Record()
    {
        myrigidbody.isKinematic = false;
        int frame = Time.frameCount % bufferFrames;
        float time = Time.time;
        print("writing time " + frame);
        keyframes[frame] = new myKeyFrame(time, transform.position, transform.rotation);
    }
}

/// <summary>
/// A structure for storing time, position and rotation;
/// </summary>
public struct myKeyFrame
{
    public float frameTime;
    public Vector3 position;
    public Quaternion roation;

    public myKeyFrame (float aTime, Vector3 aPosition, Quaternion aRoation)
    {
        frameTime = aTime;
        position = aPosition;
        roation = aRoation;
    }
}
