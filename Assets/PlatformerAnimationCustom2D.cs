using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerAnimationCustom2D : MonoBehaviour {
    #region PrivateVariables
    [SerializeField] private PlatformerMotor2D motor;
    [SerializeField] private Transform visualTransform;
    [SerializeField] private Animator anim;
    [SerializeField] bool isJumping;
    [SerializeField] private bool facingLeft;
    [SerializeField] SpriteRenderer mySprite;
    //slopes
    [SerializeField] float rotationSpeed;
    [SerializeField] Vector2 groundNormal;
    #endregion
    #region PublicProperties

    #endregion
    #region UnityFunctions
    void Start()
    {

    }
    void Update()
    {
        SetSpeed();
        SetDirection();
        AlignToGround();
        SetJumping();
    }
    #endregion
#region CustomFunctions
    void SetSpeed()
    {
        anim.SetFloat("hor_speed", Mathf.Abs(motor.velocity.x));
    }
    void SetDirection() {
        if (motor.velocity.x != 0)
            mySprite.flipX = motor.velocity.x > 0 ? false : true;
    }
    void AlignToGround()
    {
        if (motor.onSlope)
            groundNormal = motor.groundNormal;
        else
            groundNormal = Vector2.zero;

        Quaternion tempRotation = Quaternion.FromToRotation(Vector2.up, groundNormal);
        visualTransform.rotation = Quaternion.Lerp(visualTransform.rotation, tempRotation, rotationSpeed * Time.deltaTime);
        
    }
    void SetJumping()
    {
        if (motor.motorState == PlatformerMotor2D.MotorState.Jumping || motor.motorState == PlatformerMotor2D.MotorState.Falling || motor.motorState == PlatformerMotor2D.MotorState.FallingFast)
        {
            anim.SetBool("in_air", true);
            anim.SetFloat("vert_speed", motor.velocity.y);
        }
        else
        {
            anim.SetBool("in_air", false);
            anim.SetFloat("vert_speed", 0f);
        }
    }
#endregion
}
