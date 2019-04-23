using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAtomInteraction : MonoBehaviour
{

    public InteractionController interactionController;
    public CreateAtomManager creator;
    public GameObject canvas;
    public int indexAtom;

    private void Start()
    {
        this.gameObject.GetComponent<InteractionButton>().OnPerControllerContactBegin = delegate (InteractionController iC)
        {
            if (iC.Equals(interactionController))
            {
                if (canvas.activeInHierarchy)
                {
                    Debug.Log("TOUCHED " + (this.gameObject.name.Substring(0, this.gameObject.name.Length - 7)).ToUpper() + "!");

                    creator.atomType = creator.atomTypes[indexAtom];
                }
                
                
            }
        };

        this.gameObject.GetComponent<InteractionButton>().OnPerControllerContactEnd = delegate (InteractionController iC)
        {
            if (iC.Equals(interactionController))
            {
                Debug.Log("FINISHED TOUCHED " + (this.gameObject.name.Substring(0, this.gameObject.name.Length - 7)).ToUpper() + "!");
            }
        };
    }
}
