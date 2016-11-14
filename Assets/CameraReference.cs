using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraReference : MonoBehaviour {
    #region PrivateVariables
    [SerializeField] Transform cam;
    [SerializeField] cameraFollow3D mainCamScript;
    [SerializeField] DialogueCamera dialogueCamScript;
    [SerializeField] Vector3 normalRotation, dialogueRotation;
    #endregion
    #region PublicProperties

    #endregion
    #region UnityFunctions
    void Start () {
	
    }
    void Update () {
	    if (mainCamScript.enabled)
        {
            transform.rotation = Quaternion.Euler(normalRotation);
            transform.position = mainCamScript.TargetPos;
        }
        else if (dialogueCamScript.enabled)
        {
            transform.LookAt(dialogueCamScript.LookTarget);
            transform.position = dialogueCamScript.TargetPos;
        }
    }
    #endregion
    #region CustomFunctions

    #endregion
}
