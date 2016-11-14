using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


[RequireComponent(typeof(CharacterController))]
public class CharacterControls : MonoBehaviour {
    #region PrivateVariables
    CharacterController cont;
    [SerializeField]Vector3 movementInput;
    [SerializeField]float movementSpeed, groundOffset, baseGravity, groundCheckDist;
    float currentGravity;
    [SerializeField]LayerMask groundMask;
    [SerializeField]bool grounded;
    //jumping
    [SerializeField]bool jumping;
    [SerializeField]bool canJumpUp, canClimb;
    [SerializeField]Vector3 jumpTarget;
    [SerializeField]float jumpUpTime, jumpHeight, jumpTime, jumpTo, newHeight, jumpResetTime;
    //hanging
    [SerializeField] float hangHeight, standHeight;

    #endregion
    #region PublicProperties
    public bool Grounded{get{return grounded;}set{grounded = value;}}
    public bool Jumping{get{return jumping;}set{jumping = value;}}
    #endregion
    #region UnityFunctions
    void Start () {
        cont = GetComponent<CharacterController>();
        currentGravity = baseGravity;
    }
    void Update () {
        PlayerInput();
        MaintainHeight();
       if (jumping)
            SetJumpHeight();
        ApplyMovement(movementInput.normalized);
        if (grounded && !canJumpUp)
            CheckForNormalJump();
        if (canJumpUp)
            CheckForJumpInput();
        if (canClimb)
            CheckForClimbInput();
    }
    #endregion
    #region CustomFunctions
    void PlayerInput() { movementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); }
    void ApplyMovement(Vector3 input) { cont.Move(input * movementSpeed * Time.deltaTime); }
    void MaintainHeight()
    {
        Vector3 groundHit = FindGround();
        if (groundHit != Vector3.zero && !jumping)
        {
            grounded = true;
        }
        else 
        {
            grounded = false;
        }
        if (groundHit != Vector3.zero)
            cont.transform.position = groundHit + Vector3.up * groundOffset;
        else
            cont.transform.position -= Vector3.up * currentGravity * Time.deltaTime;
    }
    Vector3 FindGround()
    {
        Vector3 result = Vector3.zero;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down * groundCheckDist, out hit, groundCheckDist, groundMask))
        { result = hit.point;
            print("hit is " + hit.transform);
        //    grounded = true;
            Debug.DrawRay(transform.position, Vector3.down * groundCheckDist, Color.red);}
        if (hit.transform == null)
        {
            print("not grounded");
         //   grounded = false;
            result = Vector3.zero;
            Debug.DrawRay(transform.position, Vector3.down * groundCheckDist, Color.green);}

        //if (jumping)
         //   grounded = false;
        return result;
    }
    void CheckForJumpInput()
    {
        if (Input.GetButtonDown("Jump"))
        {
            JumpUp();
        }
    }
    void CheckForClimbInput()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Climb();
        }else if (Input.GetButton("Drop"))
        {
            Drop();
        }
    }
    public void ToggleJump(bool state, Vector3 upperTarget)
    {
       // print("in loop");
        canJumpUp = state;
        if (state)
            jumpTarget = upperTarget;
    }
    void CheckForNormalJump()
    {
        if (Input.GetButtonDown("Jump"))
            Jump();
    }
    void Jump()
    {
        jumping = true;
         newHeight = transform.position.y;
        jumpTo = newHeight + jumpHeight;
        //transform.DOMove(transform.position.y , 1);
        //DOTween.To(() => newHeight, x => newHeight  = x, newHeight + jumpHeight, jumpTime);
       

        DOTween.To(() => newHeight, x => newHeight = x, jumpTo, jumpTime);
        
        Invoke("ResetJump", jumpResetTime);
        // iTween.MoveTo(gameObject, transform.position + Vector3.up * jumpHeight, jumpTime);
    }
    void SetJumpHeight()
    {
        transform.position = new Vector3(transform.position.x, newHeight, transform.position.z);
    }
    void ResetJump()
    {
        jumping = false;
    }
    void JumpUp()
    {
        canJumpUp = false;
        currentGravity = 0;
        cont.enabled = false;
        
        Vector3 target = new Vector3(transform.position.x, jumpTarget.y - hangHeight, transform.position.z);
        Invoke("PrepClimb", jumpUpTime);
        iTween.MoveTo(gameObject, target, jumpUpTime);
    }

    void PrepClimb()
    {
        canClimb = true;
    }
    void Climb()
    {
        canClimb = false;
        Vector3 target = new Vector3(jumpTarget.x, jumpTarget.y+standHeight, jumpTarget.z);
        Invoke("ClimbedUp", jumpUpTime);
        iTween.MoveTo(gameObject, target, jumpUpTime);
    }
    void ClimbedUp()
    {
        canClimb = false;
        cont.enabled = true;
        currentGravity = baseGravity;
    }
    void Drop()
    {
        canClimb = false;
        cont.enabled = true;
        currentGravity = baseGravity;
    }
    #endregion
}
