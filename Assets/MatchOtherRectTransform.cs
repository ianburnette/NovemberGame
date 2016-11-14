using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchOtherRectTransform : MonoBehaviour {
#region PrivateVariables
    [SerializeField] RectTransform rectToMatch, myRect;
#endregion
#region PublicProperties

#endregion
#region UnityFunctions
void Start () {
        //myRect = GetComponent<RectTransform>();
}
void Update () {
        myRect.sizeDelta = rectToMatch.sizeDelta;
        myRect.position = rectToMatch.position;
}
#endregion
#region CustomFunctions

#endregion
}
