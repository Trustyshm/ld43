using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GodText : MonoBehaviour {

    public GameObject bossPanel;
    public GameObject killed;
    public GameObject knowingly;
    public GameObject button;
    public GameObject what;

    public Image bossPanelImage;
    public float timer;
    private bool one = false;
    private bool two = false;
    private bool three = false;
    private bool four = false;

    private bool doOnceOne = false;
    private bool doOnceTwo = false;

    private bool stopButton = false;

    public Animator anim;


	// Use this for initialization
	void Start () {
        bossPanelImage = bossPanel.GetComponent<Image>();
        timer = 7f;
        TextAppearer();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        
        timer -= Time.deltaTime;

        if (timer <= 5 && doOnceOne == false)
        {
            KilledAppearer();
            doOnceOne = true;
        }

        if (timer <= 2 && doOnceTwo == false)
        {
            KnowinglyAppearer();
            
            doOnceTwo = true;
        }

        anim.SetBool("StopButton", stopButton);
    }


    void TextAppearer()
    {
        bossPanel.SetActive(true);
        killed.SetActive(false);
        knowingly.SetActive(false);
        what.SetActive(false);
    }

    void KilledAppearer()
    {
        killed.SetActive(true);
    }

    void KnowinglyAppearer()
    {
        knowingly.SetActive(true);
        button.SetActive(true);
    }

    public void TextOne()
    {
        if (one == false)
        {
            knowingly.SetActive(false);
            killed.SetActive(false);
            stopButton = true;
            what.SetActive(true);
            one = true;
        }

        if (one && !two)
        {

        }
        

    }
}
