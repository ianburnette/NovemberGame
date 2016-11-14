using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraFollow3D : MonoBehaviour {
    #region PrivateVariables
    [SerializeField] Transform camRef;
    [SerializeField] CameraAssist assistant;
    [SerializeField] float speed, zoomSpeed, rotationSpeed;
    [SerializeField] Vector3 cameraOffset, targetRotation, targetPos;
    [SerializeField] float[] zoomLevels, fovLevels;
    [SerializeField] Text camDescription;
    Camera cam;
    public float targetZoom, targetFOV;

    #endregion
    #region PublicProperties
        public Vector3 TargetPos { get { return targetPos; } set { targetPos = value; } }
    #endregion
    #region UnityFunctions
    void Start () {
        cam = GetComponent<Camera>();
}
void Update () {
        SetPositionAndRotation();
     //   GetZoom();
      //  SetText();
}
#endregion
#region CustomFunctions
    void SetPositionAndRotation()
    {
        targetPos = assistant.CameraFocus + cameraOffset;
        transform.position = Vector3.Lerp(transform.position, camRef.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, camRef.rotation, rotationSpeed * Time.deltaTime);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, targetFOV, zoomSpeed * Time.deltaTime);
        //transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
        //transform.LookAt(assistant.transform);
        // transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), rotationSpeed * Time.deltaTime);
    }

    void GetZoom()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ChangeZoom(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            ChangeZoom(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            ChangeZoom(2);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            ChangeZoom(3);
        if (Input.GetKeyDown(KeyCode.Alpha5))
            ChangeZoom(4);
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleOrthographic();
        }
        SetZoom();
    }
    void ChangeZoom(int zoomLevel)
    {
        if (zoomLevels.Length >= zoomLevel)
            targetZoom = zoomLevels[zoomLevel];
        if (fovLevels.Length >= zoomLevel)
            targetFOV = fovLevels[zoomLevel];
    }
    void SetZoom()
    {
        if (cam.orthographic == true)
        {
            if (cam.orthographicSize < targetZoom - .1f || cam.orthographicSize > targetZoom + .1f)
                cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, zoomSpeed * Time.deltaTime);
        }
        else if (cam.fieldOfView < targetFOV - .1f || cam.fieldOfView > targetFOV + .1f)
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, targetFOV, zoomSpeed * Time.deltaTime);
            //print("in zoom loop");
        }

    }
    void ToggleOrthographic()
    {
        if (cam.orthographic)
            cam.orthographic = false;
        else
            cam.orthographic = true;
    }
    void SetText()
    {
        if (cam.orthographic)
            camDescription.text = "Orthographic";
        else
            camDescription.text = "Perspective";
    }
#endregion
}
