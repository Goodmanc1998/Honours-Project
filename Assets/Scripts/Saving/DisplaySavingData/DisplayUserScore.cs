using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayUserScore : MonoBehaviour
{

    public string sceneName;

    SaveData currentData;

    List<SaveData> savedScores = new List<SaveData>();

    public Text devScore;
    public Text posScore;
    public Text areaScore;


    public Text leftTime;
    public Text centerTime;
    public Text rightTime;

    // Start is called before the first frame update
    void Start()
    {
        savedScores = SavingToXML.LoadData(sceneName);

        DisplayScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DisplayScore()
    {
        currentData = savedScores[savedScores.Count - 1];

        devScore.text = "Developing Score : " + currentData.getDev();
        posScore.text = "Possible Score : " + currentData.getPos();
        areaScore.text = "Area Score : " + currentData.getArea();

        leftTime.text = "Left : " + currentData.getLooking().x;
        centerTime.text = "Center : " + currentData.getLooking().y;
        rightTime.text = "Right : " + currentData.getLooking().z;


    }
}
