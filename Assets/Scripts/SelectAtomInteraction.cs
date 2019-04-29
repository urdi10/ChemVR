using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectAtomInteraction : MonoBehaviour
{

    public InteractionController interactionController;
    public CreateAtomManager creator;
    public GameObject canvas;
    public int indexAtom;

    private void Start()
    {
        //Behaviour executed when the right hand interaction controller contacts the preview GameObject
        this.gameObject.GetComponent<InteractionButton>().OnPerControllerContactBegin = delegate (InteractionController iC)
        {
            //Checks if the InteractionController that has contacted the GameObject is the right hand interaction controller
            if (iC.Equals(interactionController))
            {
                //Checks if the atom´s menu is active in the hierarchy of the scene
                if (canvas.activeInHierarchy)
                {
                    //Select the preview´s asociated atom in the creation manager
                    creator.atomType = creator.atomTypes[indexAtom];

                    //Uppercase the selected preview´s text
                    this.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = this.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text.ToUpper();
                    this.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().outlineColor = new Color32(255, 255, 255, 255);
                    this.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().faceColor = new Color32(0, 0, 0, 255);

                    //Lowercase the non-selected previews´ text
                    int index = this.gameObject.transform.GetSiblingIndex();
                    int nOptions = this.gameObject.transform.parent.childCount;
                    for(int i = 0; i < nOptions; i++)
                    {
                        if (i != index)
                        {
                            string name = this.transform.parent.GetChild(i).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text;
                            name = name.Substring(0, 1) + name.Substring(1, name.Length - 1).ToLower();
                            this.transform.parent.GetChild(i).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = name;
                            this.transform.parent.GetChild(i).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().outlineColor = new Color32(0, 0, 0, 255);
                            this.transform.parent.GetChild(i).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().faceColor = new Color32(255, 255, 255, 255);

                        }
                    }
                }
                
                
            }
        };
    }
}
