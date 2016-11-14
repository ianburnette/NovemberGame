using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ledge : MonoBehaviour {
    #region PrivateVariables
    [SerializeField] Transform upperLedge;
#endregion
#region PublicProperties

#endregion
#region UnityFunctions
    void Start () {
            upperLedge = transform.GetChild(0);
    }
    void Update () {
	
    }
    void OnTriggerEnter(Collider col)
    {
        col.GetComponent<CharacterControls>().ToggleJump(true, upperLedge.position);
    }
    void OnTriggerExit(Collider col)
    {
        col.GetComponent<CharacterControls>().ToggleJump(false, upperLedge.position);
    }
#endregion
#region CustomFunctions

#endregion
}
