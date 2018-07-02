using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuitButtonHandler : MonoBehaviour, IPointerClickHandler {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.QuitGame();
    }
}
