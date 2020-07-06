using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 인스펙터 뷰에 노출됨
[System.Serializable]
public class PlayerAnim
{
    public AnimationClip idle;
    public AnimationClip runF;
    public AnimationClip runB;
    public AnimationClip runL;
    public AnimationClip runR;
}

public class PlayerController : MonoBehaviour {

    private float h = 0.0f;
    private float v = 0.0f;
    private float r = 0.0f;

    private Transform tr;

    // 이동 속도 변수
    public float moveSpeed = 10.0f;

    // 회전 속도 변수
    public float rotSpeed = 80.0f;

    public PlayerAnim playerAnim;

    [HideInInspector]
    public Animation anim;

	// Use this for initialization
	void Start () {
        tr = GetComponent<Transform>();

        anim = GetComponent<Animation>();

        anim.clip = playerAnim.idle;
        anim.Play();
	}
	
	// Update is called once per frame
	void Update () {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");

        Debug.Log("h=" + h.ToString());
        Debug.Log("v=" + v.ToString());

        // 전후좌우 이동 방향 벡터 계산
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        // 이동 방향 * 속도 * 변위값 * Time.deltaTime, 기준좌표)
        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.Self);

        // 회전축 * 속도 * Time.deltaTime * 변위값
        tr.Rotate(Vector3.up * rotSpeed * Time.deltaTime * r);

        // 전진 애니메이션
        if(v >= 0.1f)
        {
            // 애니메이션 이름, 시간 적용
            anim.CrossFade(playerAnim.runF.name, 0.3f);
        }
        // 후진 애니메이션
        else if(v <= -0.1f)
        {
            anim.CrossFade(playerAnim.runB.name, 0.3f);
        }
        // 오른쪽 이동 애니메이션
        else if(h >= 0.1f)
        {
            anim.CrossFade(playerAnim.runR.name, 0.3f);
        }
        // 왼쪽 이동 애니메이션
        else if(h <= -0.1f)
        {
            anim.CrossFade(playerAnim.runL.name, 0.3f);
        }
        // 정지시 Idle 애니메이션
        else
        {
            anim.CrossFade(playerAnim.idle.name, 0.3f);
        }
	}
}



