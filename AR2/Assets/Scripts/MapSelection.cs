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
    public Button bKomm;
    public Material orto;
    public Material hipso;
    public Material regio;
    public Material komm;

    void Start ()
    {
        meshRenderer = display.GetComponent<MeshRenderer>();
        meshRenderer.material = orto;
    }
	
	// Update is called once per frame
	void Update () {

        bOrto.onClick.AddListener(setOrto);
        bHipso.onClick.AddListener(setHipso);
        bRegio.onClick.AddListener(setRegio);
        bKomm.onClick.AddListener(setKomm);
    }

    void setOrto()
    {
        meshRenderer.material = orto;
    }

    void setHipso()
    {
        meshRenderer.material = hipso;
    }

    void setRegio()
    {
        meshRenderer.material = regio;
    }

    void setKomm()
    {
        meshRenderer.material = komm;
    }
}
