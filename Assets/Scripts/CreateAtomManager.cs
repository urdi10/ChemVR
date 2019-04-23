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

    private GameObject atom;

    public void CreateAtom()
    {
        if (atomType != null)
        {
            atom = GameObject.Instantiate(atomType);
            atom.transform.position = new Vector3(rightHand.position.x, 0.1f, rightHand.position.z + 0.1f);
            SetInteractionBehaviour();

            Debug.Log("ATOM CREATED!");
        }        
    }

    private void SetInteractionBehaviour()
    {
        atom.AddComponent<InteractionBehaviour>();
        atom.GetComponent<InteractionBehaviour>().manager = interactionManager;
        atom.GetComponent<InteractionBehaviour>().allowMultiGrasp = true;
    }

    /*private void CreateAtomIncreasingSize(string name, float maxSize)
    {
        //Comprueba click para empezar a crear esfera
        if (!leftClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                atom = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                atom.name = name;
                atom.transform.localScale = new Vector3(1, 1, 1);
                atom.transform.localPosition = new Vector3(0, initialHeight, 0);
                initialHeight++;
                leftClick = true;
            }
        }

        //Comprueba si se sigue pulsando para ampliar la esfera o se suelta para dejarla definitiva
        else
        {


            //Esfera definitiva
            if (Input.GetMouseButtonUp(0))
            {
                atom.AddComponent<Rigidbody>();
                leftClick = false;
            }

            else
            {
                if (atom.transform.localScale.x < maxSize)
                {
                    atom.transform.localScale = atom.transform.localScale * 1.005f;
                    
                    //Comprobar si se ha pasado de tamaño
                    if (atom.transform.localScale.x > maxSize)
                    {
                        atom.transform.localScale = new Vector3(maxSize, maxSize, maxSize);
                    }
                }
            }
        }
    }*/
}
