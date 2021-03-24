using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySavingData : MonoBehaviour
{
    public DisplayItem emptyItem;

    List<SaveData> currSaves = new List<SaveData>();

    public Transform listPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void displayTest()
    {
        displayLoadData("ConnorTestScene");
    }

    public void displayHazardOne()
    {
        displayLoadData("HazardSceneOne");
    }

    public void displayHazardTwo()
    {
        displayLoadData("HazardSceneTwo");
    }

    public void displayLoadData(string dataName)
    {
        removeChildren();

        currSaves = SavingToXML.LoadData(dataName);

        for (int i = 0; i < currSaves.Count; i++)
        {
            DisplayItem newItem = Instantiate(emptyItem, listPanel);

            newItem.transform.SetParent(listPanel, false);

            newItem.SetListItem(currSaves[i]);

        }
    }

    public void removeChildren()
    {
        for (int i = 0; i < listPanel.childCount; i++)
        {
            Transform child = listPanel.GetChild(i);

            Destroy(child.gameObject);
        }
    }


}
