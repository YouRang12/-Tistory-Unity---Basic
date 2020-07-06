using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iTweenMgr : MonoBehaviour {

    public GameObject obj1, obj2, obj3;

    void Start()
    {
        iTween.MoveTo(obj1, iTween.Hash("y", 10.0f
                                        , "time", 2.0f
                                        , "oncomplete", "MoveObj2"
                                        , "oncompletetarget", this.gameObject));
        Hashtable ht = new Hashtable();
        ht.Add("path", iTweenPath.GetPath("Fly"));
        ht.Add("time", 20.0f);
        ht.Add("easetype", iTween.EaseType.linear);
        ht.Add("orienttopath", true);
        ht.Add("looktarget", obj2.transform.position);
        ht.Add("looktime", 0.2f);

        iTween.MoveTo(Camera.main.gameObject, ht);

    }

    void MoveObj2()
    {
        iTween.MoveBy(obj2, iTween.Hash("y", 10.0f
                                        , "time", 1.0f
                                        , "oncomplete", "MoveObj3"
                                        , "oncompletetarget", this.gameObject));
    }

    void MoveObj3()
    {
        Hashtable ht = new Hashtable();
        ht.Add("y", 200.0f);
        ht.Add("delay", 4.0f);
        ht.Add("time", 2.0f);
        ht.Add("easetype", iTween.EaseType.easeInBounce);
        iTween.MoveFrom(obj3, ht);
    }
}


