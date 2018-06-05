using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int ValidHitForce=5;
    public int healths = 2;
    private bool attacked = false;
    private Renderer myRenderer;

	// Use this for initialization
	void Start () {
        myRenderer= GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (healths==2)
        {
            myRenderer.material.color = Color.red;
        }
        else if (healths==1)
        {
            myRenderer.material.color = Color.yellow;
        }
        else if (healths<=0)
        {
            myRenderer.material.color = Color.white;
            Invoke("SMStoGM", 1f);
        }       
	}

    private void OnCollisionEnter(Collision collision)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (collision.gameObject==player&&collision.relativeVelocity.magnitude>ValidHitForce&&attacked==false)
        {
            healths -=1 ;
            attacked = true;
        }
        Debug.Log(collision.relativeVelocity.magnitude);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == GameObject.FindGameObjectWithTag("Player") )
        {           
            attacked = false;
        }
    }

    void SMStoGM()
    {
        GameObject.Find("Game Manager").SendMessage("LoadNextLevel");
        Debug.Log("sent sms");
    }
}
