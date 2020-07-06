using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    // 총알의 파괴력
    public float damage = 20.0f;

    // 총알 발사 속도
    public float speed = 1000.0f;

	// Use this for initialization
	void Start ()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
	}

}
