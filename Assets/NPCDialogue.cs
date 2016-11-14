using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity.Example;

public class NPCDialogue : MonoBehaviour {
    #region PrivateVariables
    Collider dialogueCol;
    [SerializeField] GameObject bubble;
    bool promptShowing;
#endregion
#region PublicProperties

#endregion
#region UnityFunctions
    void Start () {
          dialogueCol = GetComponent<Collider>();
        promptShowing = false;
        bubble.SetActive(false);
    }
    void Update () {
	
    }

    void OnTriggerEnter(Collider col)
    {
        string myName = "";
        bool nameStarted = false;
        foreach (char n in transform.name)
        {
            if (n == '_' && !nameStarted)
                nameStarted = true;
            else if (nameStarted)
                myName += n;
        }
        ExampleDialogueUI.staticDialogueUI.PositionBubble(myName);
        ExampleDialogueUI.staticDialogueUI.SetEllipses();
        promptShowing = true;
        bubble.SetActive(true);
        col.GetComponent<PlayerTalking>().CurrentNPCtoTalkTo = this.transform.GetComponent<NPC>();
    }

    void OnTriggerExit(Collider col)
    {
        promptShowing = false;
        bubble.SetActive(false);
        col.GetComponent<PlayerTalking>().CurrentNPCtoTalkTo = null;
        ExampleDialogueUI.staticDialogueUI.SetEllipses();
    }
#endregion
#region CustomFunctions

#endregion
}
