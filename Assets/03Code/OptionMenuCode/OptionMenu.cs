using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public Slider volumeSlider;
    private AudioSource sound;
    public GameObject toggles;
    private int Quality;

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality", 3)); //loading qualilty with a default of 3
        Quality = QualitySettings.GetQualityLevel();
        sound = GetComponent<AudioSource>();
        volumeSlider.value = PlayerPrefs.GetFloat("volume", 1); //loading volume with a default volume at 1

        if (Quality == 0)
        {
            toggles.transform.Find("Low").gameObject.GetComponent<Toggle>().isOn = true;
        }

        else if (Quality == 3)
        {
            toggles.transform.Find("Medium").gameObject.GetComponent<Toggle>().isOn = true;
        }

        else if (Quality == 5)
        {
            toggles.transform.Find("High").gameObject.GetComponent<Toggle>().isOn = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //using a slider to set the volume 
        sound.volume = volumeSlider.value; 
    }

    //low resolution option 
    public void lowRes()
    {
        QualitySettings.SetQualityLevel(0);
    }

    //medium resolution option
    public void mediumRes()
    {
        QualitySettings.SetQualityLevel(3);
    }

    //high resolution option 
    public void highRes()
    {
        QualitySettings.SetQualityLevel(5);
    }

    public void saveButton()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value); //saving volume
        PlayerPrefs.SetInt("Quality", QualitySettings.GetQualityLevel()); //saving quality and resolution 
        Debug.Log("Options Saved");
    }
}
