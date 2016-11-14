using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCamera : MonoBehaviour {
    #region PrivateVariables
    [SerializeField] Transform camRef;
    [SerializeField] Camera myCam;
    [SerializeField] Transform currentNPC, player;
    [SerializeField] Vector3 lookTarget, positionTarget, dialogueOffset, lookOffset, targetPos;
    [SerializeField] float targetFOV = 43f;
    [SerializeField] float fovSpeed, positionSpeed, lookSpeed;


    #endregion
    #region PublicProperties
        public Vector3 LookTarget { get { return lookTarget; } set { lookTarget = value; } }
        public Vector3 TargetPos { get { return targetPos; } set { targetPos = value; } }
    #endregion
    #region UnityFunctions
    void Start () {
	    
    }
    void Update () {
        myCam.fieldOfView = Mathf.Lerp(myCam.fieldOfView, targetFOV, fovSpeed * Time.deltaTime);
        lookTarget = (currentNPC.position + player.position) / 2f;
        lookTarget += lookOffset;
        // transform.LookAt(lookTarget + lookOffset);
        targetPos = ((currentNPC.position + player.position) / 2 )+ dialogueOffset;//Vector3.Lerp(transform.position, lookTarget + dialogueOffset, positionSpeed * Time.deltaTime);

        transform.position = Vector3.Lerp(transform.position, camRef.position, positionSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, camRef.rotation, lookSpeed * Time.deltaTime);
    }
    #endregion
    #region CustomFunctions

    #endregion
}
