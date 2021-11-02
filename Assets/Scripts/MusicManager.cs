using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{

    [SerializeField] Image musicOnIcon;
    [SerializeField] Image musicOffIcon;

    private bool muted = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
        }
        else
        {
            Load();
        }
    }

    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;  
        }

        Save();
        UpdateButtonIcon();
        AudioListener.pause = muted;
    }

    private void UpdateButtonIcon()
    {
        if (muted == false)
        {
            musicOnIcon.enabled = true;
            musicOffIcon.enabled = false;
        }
        else
        {
            musicOnIcon.enabled = false;
            musicOffIcon.enabled = true;
        }
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;   
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
    

}
