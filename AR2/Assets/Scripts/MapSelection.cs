using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSelection : MonoBehaviour
{
    public GameObject display;
    private MeshRenderer meshRenderer;

    public Button bOrto;
    public Button bHipso;
    public Button bRegio;

    public Material orto;
    public Material hipso;
    public Material regio;
    
    private Button bbRegio;
    private LayerSelection layerSelection;

    public Color active;
    public Color inactive;

    void Start ()
    {
        meshRenderer = display.GetComponent<MeshRenderer>();
        meshRenderer.material = orto;
        layerSelection = GetComponent<LayerSelection>();
        bbRegio = layerSelection.bRegio;
        active = Color.green;
        inactive = Color.white;
        bOrto.GetComponent<Image>().color = active;
        bHipso.GetComponent<Image>().color = inactive;
        bRegio.GetComponent<Image>().color = inactive;
    }
	
	void Update () {

        bOrto.onClick.AddListener(SetOrto);
        bHipso.onClick.AddListener(SetHipso);
        bRegio.onClick.AddListener(SetRegio);
    }

    void SetOrto()
    {
        meshRenderer.material = orto;
        bbRegio.gameObject.SetActive(true);
        bOrto.GetComponent<Image>().color = active;
        bHipso.GetComponent<Image>().color = inactive;
        bRegio.GetComponent<Image>().color = inactive;
    }

    void SetHipso()
    {
        meshRenderer.material = hipso;
        bbRegio.gameObject.SetActive(true);
        bOrto.GetComponent<Image>().color = inactive;
        bHipso.GetComponent<Image>().color = active;
        bRegio.GetComponent<Image>().color = inactive;
    }

    void SetRegio()
    {
        meshRenderer.material = regio;
        bbRegio.gameObject.SetActive(false);
        bOrto.GetComponent<Image>().color = inactive;
        bHipso.GetComponent<Image>().color = inactive;
        bRegio.GetComponent<Image>().color = active;
    }
}
