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

    public void displayLoadData()
    {
        currSaves = SavingToXML.LoadData("ConnorTestScene");

        for (int i = 0; i < currSaves.Count; i++)
        {
            DisplayItem newItem = Instantiate(emptyItem, listPanel);

            newItem.transform.SetParent(listPanel, false);

            newItem.SetListItem(currSaves[i]);

        }
    }


}
