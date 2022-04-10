using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Settings : MonoBehaviour
{
    private bool gettingKey = false;
    private static readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));
    [SerializeField] private TextMeshProUGUI jumpKeyText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(gettingKey)
        {
            if(Input.anyKeyDown)
            {
                foreach (KeyCode keyCode in keyCodes)
                {
                    if (Input.GetKey(keyCode)) {
                        gettingKey = false;
                        PlayerPrefs.SetInt("Jump",(int)keyCode);
                        jumpKeyText.text = keyCode.ToString();
                        break;
                    }
                }
            }
        }
    }

    public void EnterKeyMode()
    {
        gettingKey = true;
    }
}
