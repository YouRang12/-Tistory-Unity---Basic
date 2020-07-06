using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusaCtrl : MonoBehaviour {

    private Animator anim;
    private float h, v;
    private Transform tr;

    void Start()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", v);
        anim.SetFloat("Side", h);
    }
}

