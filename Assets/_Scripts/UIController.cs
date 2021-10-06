using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreLabel;

    [SerializeField] private SettingsPopup settingsPopup;


    private void Start()
    {
        settingsPopup.Close();
    }

    private void Update()
    {
        scoreLabel.text = Time.realtimeSinceStartup.ToString();
    }

    public void OnOpenSettings()
    {
        settingsPopup.Open();
    }



    public void OnPointerDown()
    {
        Debug.Log("poiter down.");
    }
}
