using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

public class LoadMenu : MonoBehaviour
{

    public List<GameObject> atoms;
    public InteractionManager interactionManager;
    public InteractionController rHandInteractionController;
    public CreateAtomManager creator;
    private GameObject atom;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < atoms.Count; i++)
        {
            atom = GameObject.Instantiate(atoms[i]);
            atom.transform.SetParent(this.gameObject.transform);
            float previewSeparation = -0.2f / (atoms.Count + 1);
            float zOrigin = 0.1f + previewSeparation;
            float posY = zOrigin + i * previewSeparation;
            atom.transform.localPosition = new Vector3(-0.03f, posY, 0);
            atom.transform.localEulerAngles = Vector3.zero;
            SetInteractionButton(i);
            //atom.transform.localScale = new Vector3(50, 50, 50);
        }
    }

    private void SetInteractionButton(int index)
    {
        atom.AddComponent<InteractionButton>();
        atom.GetComponent<InteractionButton>().manager = interactionManager;

        atom.AddComponent<SelectAtomInteraction>();
        atom.GetComponent<SelectAtomInteraction>().interactionController = rHandInteractionController;
        atom.GetComponent<SelectAtomInteraction>().creator = creator;
        atom.GetComponent<SelectAtomInteraction>().canvas = this.gameObject;
        atom.GetComponent<SelectAtomInteraction>().indexAtom = index;
    }
}
