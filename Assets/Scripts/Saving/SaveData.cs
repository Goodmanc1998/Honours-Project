using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{


    private int devHazardScore = 0;
    private int posHazardScore = 0;
    private int hazardArea = 0;
    private Vector3 lookingDirs = new Vector3();

    //Setters
    public void setDev(int nScore) { devHazardScore = nScore; }
    public void setPos(int nScore) { posHazardScore = nScore; }
    public void setArea(int nScore) { hazardArea = nScore; }
    public void setLooking(Vector3 nScore) { lookingDirs = nScore; }

    //Getters
    public int getDev() { return devHazardScore; }
    public int getPos() { return posHazardScore; }
    public int getArea() { return hazardArea; }
    public Vector3 getLooking() { return lookingDirs; }


    //Increse
    public void increaseDev(int nScore) { devHazardScore += nScore; }
    public void increasePos(int nScore) { posHazardScore += nScore; }
    public void increaseArea(int nScore) { hazardArea += nScore; }


}
