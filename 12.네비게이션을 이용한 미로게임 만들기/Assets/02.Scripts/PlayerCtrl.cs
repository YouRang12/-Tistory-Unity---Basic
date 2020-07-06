using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour {
    private NavMeshAgent nv;
    public Transform targetTr;

    private Animator anim;
    private int hashRun = Animator.StringToHash("Run");
    private int hashFinish = Animator.StringToHash("isFinish");

    IEnumerator Start () {
        nv = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        yield return new WaitForSeconds(3.0f);

        nv.SetDestination(targetTr.position);
        anim.SetTrigger(hashRun);
	}
	
    void OnTriggerEnter (Collider coll)
    {
        if (coll.CompareTag("TARGET"))
        {
            nv.isStopped = true;
            anim.SetTrigger(hashFinish);
            Invoke("ReloadScene", 3.0f);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.sceneCount - 1);
    }
}
