using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSelection : MonoBehaviour
{
    // map displaying surface and its renderer
    public GameObject display;
    private MeshRenderer meshRenderer;

    // buttons for choosing the map
    public Button bOrto;
    public Button bHipso;
    public Button bRegio;

    // materials for each map
    public Material orto;
    public Material hipso;
    public Material regio;

    // colours for buttons
    public Color active;
    public Color inactive;
   

    void OnEnable ()
    {
        print(display);
        meshRenderer = display.GetComponent<MeshRenderer>();
        meshRenderer.material = orto;

        active = Color.green;
        inactive = Color.white;

        bOrto.GetComponent<Image>().color = active;
        bHipso.GetComponent<Image>().color = inactive;
        bRegio.GetComponent<Image>().color = inactive;

        bOrto.onClick.AddListener(SetOrto);
        bHipso.onClick.AddListener(SetHipso);
        bRegio.onClick.AddListener(SetRegio);
    }
	
	void Update () {
        
    }

    void SetOrto()
    {
        meshRenderer.material = orto;
        bOrto.GetComponent<Image>().color = active;
        bHipso.GetComponent<Image>().color = inactive;
        bRegio.GetComponent<Image>().color = inactive;
    }

    void SetHipso()
    {
        meshRenderer.material = hipso;
        bOrto.GetComponent<Image>().color = inactive;
        bHipso.GetComponent<Image>().color = active;
        bRegio.GetComponent<Image>().color = inactive;
    }

    void SetRegio()
    {
        meshRenderer.material = regio;
        bOrto.GetComponent<Image>().color = inactive;
        bHipso.GetComponent<Image>().color = inactive;
        bRegio.GetComponent<Image>().color = active;
    }
}
