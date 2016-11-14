using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterControls))]
public class CharacterAnimation : MonoBehaviour {
    #region PrivateVariables
    [SerializeField] CharacterControls charCont;
    [SerializeField] float velDeadZone, rotationSpeed;
    [SerializeField] Transform modelTransform;
    [SerializeField] Vector3 currVel, nonYvel;
    [SerializeField] Animator anim;
    #endregion
    #region PublicProperties

    #endregion
    #region UnityFunctions
    void OnEnable () {
        StartCoroutine("CalcVelocity");
    }
    void Update () {
        SetRotation();
        SetAnimatorVariables();
    }
    #endregion
    #region CustomFunctions
    void SetRotation()
    {
        if (currVel.magnitude > velDeadZone)
        {
            Vector3 adjustedVel = -nonYvel;
            modelTransform.rotation = Quaternion.Lerp(modelTransform.rotation, Quaternion.LookRotation(adjustedVel, Vector3.up), rotationSpeed * Time.deltaTime);// Quaternion.FromToRotation(modelTransform.rotation.eulerAngles, adjustedVel);
        }
    }
    IEnumerator CalcVelocity()
    {
        while (Application.isPlaying)
        {
            Vector3 prevPos = transform.position;                           // Position at frame start
            yield return new WaitForEndOfFrame();                           // Wait till it the end of the frame
            currVel = (prevPos - transform.position) / Time.deltaTime;      // Calculate velocity: Velocity = DeltaPosition / DeltaTime
            nonYvel = new Vector3(currVel.x, 0, currVel.z);
        }
    }
    void SetAnimatorVariables()
    {
       // if (!charCont.Jumping)
            anim.SetBool("Grounded", charCont.Grounded);
       // else
       //     anim.SetBool("Grounded", charCont.Jumping);
        anim.SetFloat("Speed", nonYvel.magnitude);
        anim.SetFloat("Yvelocity", currVel.y);
    }
    #endregion
}

