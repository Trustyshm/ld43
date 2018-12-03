using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignBehavior : MonoBehaviour {

    public GameObject SignPost;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void SignClicked()
    {
        SignPost.SetActive(true);
        Time.timeScale = 0f;
    }

    public void SignClosed()
    {
        SignPost.SetActive(false);
        Time.timeScale = 1f;
    }
}
