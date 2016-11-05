using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class LayerSetter : MonoBehaviour {
    #region PrivateVariables
    [SerializeField]
    SpriteRenderer rend;
    [SerializeField]
    float mult = -100;
#endregion
#region PublicProperties

#endregion
#region UnityFunctions
    void Start () {
         rend = GetComponent<SpriteRenderer>();
    }
    void Update () {
         rend.sortingOrder = Mathf.RoundToInt(transform.position.y * mult);
    }
#endregion
#region CustomFunctions

#endregion
}
