using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform tr;

    public float moveSpeed = 5.0f;

    void Start()
    {
        tr = GetComponent<Transform>(); 
    }

    void Update()
    {
        float v = Input.GetAxis("Vertical"); // -1.0f ~ 0.0f ~ +1.0f
        float h = Input.GetAxis("Horizontal"); // -1.0f ~ 0.0f ~ +1.0f
        float r = Input.GetAxis("Mouse X");

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        tr.Translate(moveDir.normalized * Time.deltaTime * moveSpeed);
        tr.Rotate(Vector3.up * r * Time.deltaTime * 60.0f);
    }
}



