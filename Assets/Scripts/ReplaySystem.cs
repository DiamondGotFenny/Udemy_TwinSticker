using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {
    /// <summary>
    /// this replay system only works in Level 01 because of the use of Time.frameCount and Time.time;
    /// </summary>
    private Rigidbody myrigidbody;
    private const int bufferFrames = 1000; //this actually is the maximum time we can record/store.
    myKeyFrame[] keyframes = new myKeyFrame[bufferFrames];
    GameManager gameManager;

    private int bufferSize = bufferFrames;
    private int lastRecordedFrame = 0, nextRecordedFrame = 0;

    // Use this for initialization
    void Start () {
        myrigidbody = GetComponent<Rigidbody>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager.recording)
        {
            Record();
        }
        else
        {
            PlayBack();
        }
    }

    void PlayBack()
    {
        myrigidbody.isKinematic = true;

        if (Time.frameCount<bufferSize||(lastRecordedFrame!=0&&lastRecordedFrame<bufferSize))
        {//Never reached the end of the cycle
            bufferSize = Time.frameCount;
            lastRecordedFrame = Time.frameCount;
        }

        int frame = Time.frameCount % bufferSize;
       // print("Reading time " + frame);
        transform.position = keyframes[frame].position;
        transform.rotation = keyframes[frame].roation;
    }

    private void Record()
    {
        myrigidbody.isKinematic = false;
        bufferSize = bufferFrames;
        nextRecordedFrame = Time.frameCount;

        if (lastRecordedFrame>0)
        {
            nextRecordedFrame = lastRecordedFrame++;
        }

        int frame = nextRecordedFrame % bufferSize;
        float time = Time.time;
       // print("writing time " + frame);
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
