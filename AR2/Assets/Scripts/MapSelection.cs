﻿using System.Collections;
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

        bOrto.onClick.AddListener(SetOrto);
        bHipso.onClick.AddListener(SetHipso);
        bRegio.onClick.AddListener(SetRegio);
        bKomm.onClick.AddListener(SetKomm);
    }

    void SetOrto()
    {
        meshRenderer.material = orto;
    }

    void SetHipso()
    {
        meshRenderer.material = hipso;
    }

    void SetRegio()
    {
        meshRenderer.material = regio;
    }

    void SetKomm()
    {
        meshRenderer.material = komm;
    }
}
