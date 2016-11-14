using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using Yarn.Unity.Example;

public class PlayerTalking : MonoBehaviour {
    #region PrivateVariables
    [SerializeField] NPC currentNpcToTalkTo;
    [SerializeField] Behaviour[] toDisableWhileInDialogue;
    bool inDialogue = false;
    #endregion
    #region PublicProperties
    public NPC CurrentNPCtoTalkTo { get { return currentNpcToTalkTo; } set { currentNpcToTalkTo = value; } }
    #endregion
    #region UnityFunctions
    void Start () {
	
}
void Update () {
	if (Input.GetButtonDown("Interact") && currentNpcToTalkTo != null && !inDialogue)
        {
            FindObjectOfType<DialogueRunner>().StartDialogue(currentNpcToTalkTo.talkToNode);
            foreach (Behaviour behav in toDisableWhileInDialogue)
                behav.enabled = false;
            inDialogue = true;
            //currentNpcToTalkTo.
        }
}

    public void ReEnableBehaviors()
    {
        inDialogue = false;
        foreach (Behaviour behav in toDisableWhileInDialogue)
            behav.enabled = true;
    }
#endregion
#region CustomFunctions

#endregion
}
