using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHider : MonoBehaviour
{

    public Button hider;
    public GameObject buttons;
    private bool isHidden = false;

    public Color active;
    public Color inactive;

    void Start () {

        active = Color.green;
        inactive = Color.white;

        hider.GetComponent<Image>().color = inactive;
    }
	
	void Update () {

        if (isHidden)
        {
            hider.onClick.AddListener(ShowButtons);
        }

        if (!isHidden)
        {
            hider.onClick.AddListener(HideButtons);
        }
    }

    void HideButtons()
    {
        buttons.SetActive(false);
        isHidden = true;
        hider.GetComponent<Image>().color = active;
    }

    void ShowButtons()
    {
        buttons.SetActive(true);
        isHidden = false;
        hider.GetComponent<Image>().color = inactive;
    }
}
