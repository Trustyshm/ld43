using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour {

    public SpriteRenderer Gateway;
    public GameObject button;
    private bool timerBool = false;
    private float timerNext = 10f;
    public AudioSource bgm;
    public GameObject fader;
    private Animator faderAnimator;
    private bool faderBool = false;
    public GameObject bolt;
    public GameObject particles;



    // Use this for initialization
    void Start() {
        Gateway = GetComponent<SpriteRenderer>();
        faderAnimator = fader.GetComponent<Animator>();
    }

    private void Update()
    {
        if (timerBool == true)
        {
            timerNext -= Time.deltaTime;
        }

        if (timerNext <= 0)
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (timerNext <= 1.1)
        {
            faderBool = true;
            faderAnimator.SetBool("Fade", faderBool);
           
        }
    }

    public void OpenGateway()
    {
        Color tmp = Gateway.GetComponent<SpriteRenderer>().color;
        tmp.a = 255f;
        Gateway.GetComponent<SpriteRenderer>().color = tmp;
        button.SetActive(true);
        bolt.SetActive(true);
        particles.SetActive(true);
    }

    public void NextSceneCountdown()
    {
        timerBool = true;
        bgm.Stop();
        
    }
}
