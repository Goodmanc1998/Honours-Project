using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class SavingToXML
{
    //Load data function to return a list of SaveData from a filename 
    public static List<SaveData> LoadData(string fileName)
    {
        Debug.Log("LOADING DATA");

        //Getting the stored direcotry
        string directory = getDirectory();

        //If the File doesnt exist then return null
        if (!System.IO.File.Exists(directory + fileName + ".xml"))
            return null;

        //Creating the xml file Reader
        XmlReader xmlReader = XmlReader.Create(directory + fileName + ".xml");

        //Creating new list of saved Data
        List<SaveData> saves = new List<SaveData>();

        //Creating new individual item
        SaveData currData = null;

        //While Reading
        while (xmlReader.Read())
        {
            //Checking the starting element
            if(xmlReader.IsStartElement("UserScore"))
            {
                //Creating new individual data
                currData = new SaveData();

                //Storing the scores
                currData.setDev(int.Parse(xmlReader["Dev"]));
                currData.setPos(int.Parse(xmlReader["Pos"]));
                currData.setArea(int.Parse(xmlReader["Area"]));

                Vector3 looking = new Vector3();
                looking.x = (int.Parse(xmlReader["x"]));
                looking.y = (int.Parse(xmlReader["y"]));
                looking.z = (int.Parse(xmlReader["z"]));
                currData.setLooking(looking);

                //Adding the individual item to the list
                saves.Add(currData);
            }
        }
        //Closing the reader and returning the saves
        xmlReader.Close();
        return saves;
    }

    //Save data function to save the old data and new data ontop
    public static void SaveToXML(string fileName, SaveData newScore, List<SaveData> saved)
    {
        Debug.Log("SAVING DATA");

        //Getting the Directory
        string directory = getDirectory();
        //Storing the Settings
        XmlWriterSettings xmlSettings = new XmlWriterSettings();
        xmlSettings.Indent = true;

        //Setting up the XML Writer
        XmlWriter  xmlWriter = XmlWriter.Create(directory + fileName + ".xml", xmlSettings);

        //Start writing doc with first start element
        xmlWriter.WriteStartDocument();
        xmlWriter.WriteStartElement(fileName);

        if (saved != null)
        {
            for (int i = 0; i < saved.Count; i++)
            {
                //Storing each individual loaded save
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

        //Storing the new score 
        xmlWriter.WriteStartElement("UserScore");

        xmlWriter.WriteAttributeString("Dev", newScore.getDev().ToString());
        xmlWriter.WriteAttributeString("Pos", newScore.getPos().ToString());
        xmlWriter.WriteAttributeString("Area", newScore.getArea().ToString());

        xmlWriter.WriteAttributeString("x", newScore.getLooking().x.ToString());
        xmlWriter.WriteAttributeString("y", newScore.getLooking().y.ToString());
        xmlWriter.WriteAttributeString("z", newScore.getLooking().z.ToString());
        xmlWriter.WriteEndElement();

        //CLosing first element
        xmlWriter.WriteEndElement();
        // Write the end of the document
        xmlWriter.WriteEndDocument();
        // Close the document to save
        xmlWriter.Close();

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
