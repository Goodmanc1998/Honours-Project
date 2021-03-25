using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayItem : MonoBehaviour
{
    public Text posScoreText;
    public Text devScoreText;
    public Text areaScoreText;
    public Text dirLeftScoreText;
    public Text dirCentertScoreText;
    public Text dirRightScoreText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetListItem(SaveData currItem)
    {
        posScoreText.text = "Dev : " + currItem.getPos().ToString();
        devScoreText.text = "Pos : " + currItem.getDev().ToString();
        areaScoreText.text = "Area : " + currItem.getArea().ToString();

        dirLeftScoreText.text = "Dir L : " + currItem.getLooking().x.ToString();
        dirCentertScoreText.text = "Dir C : " + currItem.getLooking().y.ToString();
        dirRightScoreText.text = "Dir R : " + currItem.getLooking().z.ToString();

    }
}
