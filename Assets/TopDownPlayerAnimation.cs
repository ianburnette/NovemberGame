using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TopDownPlayerControls))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class TopDownPlayerAnimation : MonoBehaviour {
    #region PrivateVariables
    TopDownPlayerControls cont;
    Animator anim;
    SpriteRenderer rend;
#endregion
#region PublicProperties

#endregion
#region UnityFunctions
    void Start () {
        cont = GetComponent<TopDownPlayerControls>();
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }
    void Update () {
         SetAnimatorBools();
        AlignLeftRight();
    }
#endregion
#region CustomFunctions
    void SetAnimatorBools()
    {
        bool moving = Mathf.Abs(cont.MovementVector.magnitude) > 0 ? true : false;
        anim.SetBool("moving", moving);
        bool away;
        if (cont.MovementVector.y != 0)
        {
            away = cont.MovementVector.y > 0 ? true : false;
            anim.SetBool("away", away);
        }
    }

    void AlignLeftRight()
    {
        if (cont.MovementVector.x != 0)
            rend.flipX = cont.MovementVector.x > 0 ? false : true;
    }
#endregion
}
