using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private int hashRun = Animator.StringToHash("isRun");
    private int hashAttack = Animator.StringToHash("isAttack");

    void Start()
    {
        anim = GetComponent<Animator>();

        // 유한상태머신 시작
        StartCoroutine(FSM());
    }

    IEnumerator FSM()
    {
        // 이동하고 3초뒤에 대기상태로 변경
        anim.SetBool(hashRun, true);
        yield return new WaitForSeconds(3.0f);
        anim.SetBool(hashRun, false);

        // 공격하고 3초뒤에 대기상태로 변경
        anim.SetBool(hashAttack, true);
        yield return new WaitForSeconds(3.0f);
        anim.SetBool(hashAttack, false);


    }
}




