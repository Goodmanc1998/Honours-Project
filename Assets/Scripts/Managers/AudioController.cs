using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    //Storing the Master audio mixer
    public AudioMixer masterMixer;

    //Adjusting the dependant volumes by inputted slider
    public void SetMaster(float sliderValue)
    {
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
    }
}
