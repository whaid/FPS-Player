using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour {

    private Animator anim;
    private AudioSource soundReload;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        soundReload = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        anim.SetBool("isWalking", false);

        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
        {
            anim.SetBool("isWalking", true);
        }

        if (anim.GetBool("isWalking") && Input.GetButtonDown("Fire3"))
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", true);
        }

        if(anim.GetBool("isRunning") && Input.GetButtonUp("Fire3"))
        {
            anim.SetBool("isRunning", false);
        }
    }
}
