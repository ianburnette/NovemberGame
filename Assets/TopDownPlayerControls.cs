using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerControls : MonoBehaviour {
    #region PrivateVariables
    [SerializeField]
    float speed;
    Rigidbody2D rb;
    float x, y;
    [SerializeField] Vector2 movementVector;


    #endregion
    #region PublicProperties
    public Vector2 MovementVector {get{return movementVector;}set{movementVector = value;}}
    #endregion
    #region UnityFunctions
    void Start () {
        rb = GetComponent<Rigidbody2D>();
}
void Update () {
        GetInput();
        MovePlayer();
}
    #endregion
    #region CustomFunctions
    void GetInput()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
    }
    void MovePlayer()
    {
        movementVector = new Vector2(x, y);
        movementVector.Normalize();
        rb.velocity = (movementVector * speed * Time.deltaTime);
    }
#endregion
}
