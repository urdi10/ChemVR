using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

public class CreateAtomManager : MonoBehaviour
{
    public GameObject atomType = null;
    public List<GameObject> atomTypes;
    public Transform rightHand;
    public InteractionManager interactionManager;
    public GoalUnlocker goalUnlocker;

    private GameObject atom;

    //Creates the selected atom
    public void CreateAtom()
    {
        //If there isn´t a selected atom, it´s impossible to create it
        if (atomType != null)
        {
            atom = GameObject.Instantiate(atomType);
            atom.transform.position = new Vector3(rightHand.position.x, 0.1f, rightHand.position.z + 0.1f);
            SetInteractionBehaviour();
            goalUnlocker.UnlockGoal(atomType.name);
        }        
    }

    //Sets interaction behaviour to the new atom
    private void SetInteractionBehaviour()
    {
        atom.AddComponent<InteractionBehaviour>();
        atom.GetComponent<InteractionBehaviour>().manager = interactionManager;
        atom.GetComponent<InteractionBehaviour>().allowMultiGrasp = true;
    }
}
