using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoalUnlocker : MonoBehaviour
{
    public List<string> atomsGoal;
    public List<int> subindexAtomsGoal;
    private List<string> actualAtomsGoal;
    private List<int> actualSubindexAtomsGoal;
    private Dictionary<string, string> periodicTableConversor;

    // Start is called before the first frame update
    private void Start()
    {
        actualAtomsGoal = new List<string>();
        for (int i = 0; i < atomsGoal.Count; i++)
        {
            actualAtomsGoal.Add("?");
        }
        actualSubindexAtomsGoal = new List<int>();
        foreach (int sub in subindexAtomsGoal)
        {
            actualSubindexAtomsGoal.Add(sub);
        }

        //Fill periodic table conversor dictionary
        periodicTableConversor = new Dictionary<string, string>();

        periodicTableConversor.Add("Hydrogen", "H");
        periodicTableConversor.Add("Oxygen", "O");
    }

    private void Update()
    {
        if (atomsGoal.Count == subindexAtomsGoal.Count)
        {
            this.gameObject.GetComponent<TextMeshProUGUI>().text = "";
            for (int i = 0; i < atomsGoal.Count; i++)
            {
                this.gameObject.GetComponent<TextMeshProUGUI>().text += actualAtomsGoal[i];
                if (subindexAtomsGoal[i] > 1)
                {
                    if (actualSubindexAtomsGoal[i] == 0)
                    {
                        this.gameObject.GetComponent<TextMeshProUGUI>().text += "<sub>" + subindexAtomsGoal[i] + "</sub>";
                    }
                    else
                    {
                        this.gameObject.GetComponent<TextMeshProUGUI>().text += "<sub>?</sub>";
                    }
                }
            }
        }
        else
        {
            this.gameObject.GetComponent<TextMeshProUGUI>().text = "Error";
        }
    }

    //Unlocks goal characters when atoms are created
    public void UnlockGoal(string atomName)
    {
        string atomSymbol = periodicTableConversor[atomName];
        int index = atomsGoal.IndexOf(atomSymbol);

        //When the atom created is the first of it´s type
        if (actualAtomsGoal[index] != atomsGoal[index])
        {
            //Unlock the symbol
            actualAtomsGoal[index] = atomsGoal[index];
            actualSubindexAtomsGoal[index]--;
        }
        //When the atom isn´t the first of it´s type
        else
        {
            if (actualSubindexAtomsGoal[index] > 0)
            {
                actualSubindexAtomsGoal[index]--;
            }
        }
    }
}
