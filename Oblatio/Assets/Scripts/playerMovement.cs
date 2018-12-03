using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMovement : MonoBehaviour {

    private Animator anim;
    public gm gm;
    private bool playerMoving;
    private Vector2 lastAction;
    private Rigidbody2D body;

    private GameObject[] eatingEffect;


	// Use this for initialization
	void Start () {
      anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
        playerMoving = false;

        eatingEffect = GameObject.FindGameObjectsWithTag("EatingEffect");


        if (eatingEffect.Length == 0)
        {

            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                //body.MovePosition(new Vector2(Input.GetAxisRaw("Horizontal") * gm.moveSpeed * Time.deltaTime, 0f));
                transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * gm.moveSpeed * Time.deltaTime, 0f, 0f));
                playerMoving = true;
                lastAction = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);

            }

            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                //body.MovePosition(new Vector2(0f, Input.GetAxisRaw("Vertical") * gm.moveSpeed * Time.deltaTime));
                transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * gm.moveSpeed * Time.deltaTime, 0f));
                playerMoving = true;
                lastAction = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }
        }        
     

     anim.SetFloat("XMovement", Input.GetAxisRaw("Horizontal"));
     anim.SetFloat("YMovement", Input.GetAxisRaw("Vertical"));
     anim.SetBool("PlayerMoving", playerMoving);
     anim.SetFloat("LastActionX", lastAction.x);
     anim.SetFloat("LastActionY", lastAction.y);
    }
    
}
