using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignLogic : MonoBehaviour
{
    public Vector3 maskPosition;
    public Vector3 maskScale;
    public Vector3 maskEulerAngles;

    public Transform target;
    public Transform anchor;

    static float globalScale = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Button_presed(float mag) {
        Vector3 pos = target.localPosition;
        pos += globalScale * mag * maskPosition;
        target.localPosition = pos;
    }

    public void Button_presed_UseAnchor(float mag) {

        anchor.transform.localEulerAngles = Vector3.zero;
        anchor.transform.localScale = Vector3.one;

        Transform oldParent = target.parent;

        target.SetParent( anchor ); // unity handles all the position, scale, rotation offsets so the target remains unchanged

        Vector3 ang = anchor.localEulerAngles;
        ang += globalScale * mag * maskEulerAngles;
        anchor.localEulerAngles = ang;

        if( maskScale.x != 0f ) {
            Vector3 scal = anchor.localScale;
            scal *= Mathf.Pow( mag, globalScale );
            anchor.localScale = scal;
        }

        target.SetParent( oldParent );

        anchor.transform.localEulerAngles = Vector3.zero;
        anchor.transform.localScale = Vector3.one;

    }

    public void Button_SetGlobalScale( float newValue ) {
        globalScale = newValue;
    }

}
