using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleChangeTextColor : MonoBehaviour
{
    public Text label;

    public Toggle toggle;

    public Toggle otherToggle;

    public GameObject myPanel;

    public GameObject otherPanel;
    // Start is called before the first frame update
    void Start()
    {
        toggle.onValueChanged.AddListener(ChangeColor); 
    }

    // Update is called once per frame
    public  void ChangeColor(bool b)
    {
      
        if (b == true)
        {
            label.color = Color.white;
            otherToggle.isOn = false;
            myPanel.SetActive(true);
            otherPanel.SetActive(false);

        }
        else
        {
            label.color = Color.green;
            label.color = new Color(92f/255,134/255f,145f/255f);

        }
        
    }
    
    
}
