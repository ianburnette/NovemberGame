using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCameraControls : MonoBehaviour {
#region PrivateVariables
    [SerializeField] float camSpeed, zVal;
    [SerializeField] Transform player, levelCenter;

#endregion
#region PublicProperties

#endregion
#region UnityFunctions
void Start () {
	
}
void Update () {
        Vector3 pos = (player.position + levelCenter.position) / 2f;
        pos.z = zVal;
        transform.position = Vector3.Lerp(transform.position, pos, camSpeed * Time.deltaTime);
}
#endregion
#region CustomFunctions

#endregion
}
