using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow3D : MonoBehaviour {
    #region PrivateVariables
    [SerializeField] CameraAssist assistant;
    [SerializeField] float speed;
    [SerializeField] Vector3 cameraOffset;
    #endregion
#region PublicProperties

#endregion
#region UnityFunctions
void Start () {
	
}
void Update () {
        SetPosition();
}
#endregion
#region CustomFunctions
    void SetPosition()
    {
        Vector3 targetPos = assistant.CameraFocus + cameraOffset;
        transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
    }
#endregion
}
