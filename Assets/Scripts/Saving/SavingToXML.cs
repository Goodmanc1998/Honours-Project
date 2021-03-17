using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class SavingToXML
{

    public static List<SaveData> LoadData(string fileName)
    {

        string directory = getDirectory();

        
        if (!System.IO.File.Exists(directory + fileName + ".xml"))
            return null;

        Debug.Log("Start Load");

        XmlReader xmlReader = XmlReader.Create(directory + fileName + ".xml");

        List<SaveData> saves = new List<SaveData>();

        SaveData currData = null;

        while (xmlReader.Read())
        {
            if(xmlReader.IsStartElement("UserScore"))
            {
                currData = new SaveData();

                currData.setDev(int.Parse(xmlReader["Dev"]));
                Debug.Log(currData.getDev().ToString());

                currData.setPos(int.Parse(xmlReader["Pos"]));
                Debug.Log(currData.getPos().ToString());

                currData.setArea(int.Parse(xmlReader["Area"]));
                Debug.Log(currData.getArea().ToString());

                Vector3 looking = new Vector3();
                looking.x = (int.Parse(xmlReader["x"]));
                looking.y = (int.Parse(xmlReader["y"]));
                looking.z = (int.Parse(xmlReader["z"]));

                currData.setLooking(looking);


                saves.Add(currData);
            }

        }

        xmlReader.Close();

        return saves;

    }

    public static void SaveToXML(string fileName, SaveData newScore, List<SaveData> saved)
    {
        Debug.Log("Start Save");

        string directory = getDirectory();

        XmlWriterSettings xmlSettings = new XmlWriterSettings();

        xmlSettings.Indent = true;

        Debug.Log("Start ");

        XmlWriter  xmlWriter = XmlWriter.Create(directory + fileName + ".xml", xmlSettings);

        Debug.Log("Created ");

        xmlWriter.WriteStartDocument();

        xmlWriter.WriteStartElement(fileName);

        if (saved != null)
        {
            Debug.Log("Saves");

            for (int i = 0; i < saved.Count; i++)
            {
                xmlWriter.WriteStartElement("UserScore");

                xmlWriter.WriteAttributeString("Dev", saved[i].getDev().ToString());
                xmlWriter.WriteAttributeString("Pos", saved[i].getPos().ToString());
                xmlWriter.WriteAttributeString("Area", saved[i].getArea().ToString());

                xmlWriter.WriteAttributeString("x", saved[i].getLooking().x.ToString());
                xmlWriter.WriteAttributeString("y", saved[i].getLooking().y.ToString());
                xmlWriter.WriteAttributeString("z", saved[i].getLooking().z.ToString());


                xmlWriter.WriteEndElement();

            }
        }

        Debug.Log("Main Save ");

        xmlWriter.WriteStartElement("UserScore");

        xmlWriter.WriteAttributeString("Dev", newScore.getDev().ToString());
        xmlWriter.WriteAttributeString("Pos", newScore.getPos().ToString());
        xmlWriter.WriteAttributeString("Area", newScore.getArea().ToString());

        xmlWriter.WriteAttributeString("x", newScore.getLooking().x.ToString());
        xmlWriter.WriteAttributeString("y", newScore.getLooking().y.ToString());
        xmlWriter.WriteAttributeString("z", newScore.getLooking().z.ToString());

        xmlWriter.WriteEndElement();

        xmlWriter.WriteEndElement();




        // Write the end of the document
        xmlWriter.WriteEndDocument();
        // Close the document to save
        xmlWriter.Close();
        

        Debug.Log("Finished");

        GameManager.Instance.scene.ChangeScene();

    }

    public static string getDirectory()
    {
        string currentDir = "";

        if(Application.platform == RuntimePlatform.WindowsEditor)
        {
            currentDir = Application.dataPath + "/SavedData/";
        }
        else if(Application.platform == RuntimePlatform.Android)
        {
            currentDir = Application.persistentDataPath;
        }

        return currentDir;
    }
}
