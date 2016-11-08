using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAssist : MonoBehaviour {
    #region PrivateVariables
    [SerializeField]
    LayerMask groundLayer;
    [SerializeField] Vector3 cameraFocus;
    [SerializeField] bool followHeight;
    [SerializeField] float dist, baseHeight;
    float height;



    #endregion
    #region PublicProperties
    public Vector3 CameraFocus {get{return cameraFocus;}set{cameraFocus = value;}}
    #endregion
    #region UnityFunctions
    void Start () {
	
}
    void Update () {
        float yVal = followHeight ? CastRay() : baseHeight;
        cameraFocus = new Vector3(transform.position.x, yVal, transform.position.z);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
       // Gizmos.DrawSphere(cameraFocus, 1f);
    }
#endregion
#region CustomFunctions
    float CastRay()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down * dist, out hit, groundLayer))
        {
            height = hit.point.y;
        }
        return height;
    }
#endregion
}
