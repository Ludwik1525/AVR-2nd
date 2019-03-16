using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LayerSelection : MonoBehaviour {

    public GameObject citiesDisplay;
    public GameObject waterDisplay;
    public GameObject regioDisplay;
    public GameObject kommDisplay;

    public Button bCity;
    public Button bWater;
    public Button bRegio;
    public Button bKomm;

    private bool cityBool = false;
    private bool waterBool = false;
    public bool regioBool = false;
    private bool kommBool = false;

    void Start()
    {
        citiesDisplay.SetActive(false);
        waterDisplay.SetActive(false);
        regioDisplay.SetActive(false);
        kommDisplay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!cityBool)
        {
            bCity.onClick.AddListener(SetCity);
        }

        if (cityBool)
        {
            bCity.onClick.AddListener(DisableCity);
        }

        if (!waterBool)
        {
            bWater.onClick.AddListener(SetWater);
        }

        if (waterBool)
        {
            bWater.onClick.AddListener(DisableWater);
        }

        if (!regioBool)
        {
            bRegio.onClick.AddListener(SetRegio);
        }

        if (regioBool)
        {
            bRegio.onClick.AddListener(DisableRegio);
        }

        if (!kommBool)
        {
            bKomm.onClick.AddListener(SetKomm);
        }

        if (kommBool)
        {
            bKomm.onClick.AddListener(DisableKomm);
        }
    }

    void SetCity()
    {
        citiesDisplay.SetActive(true);
        cityBool = true;
    }

    void DisableCity()
    {
        citiesDisplay.SetActive(false);
        cityBool = false;
    }

    void SetWater()
    {
        waterDisplay.SetActive(true);
        waterBool = true;
    }

    void DisableWater()
    {
        waterDisplay.SetActive(false);
        waterBool = false;
    }

    void SetRegio()
    {
        regioDisplay.SetActive(true);
        regioBool = true;
    }

    void DisableRegio()
    {
        regioDisplay.SetActive(false);
        regioBool = false;
    }

    void SetKomm()
    {
        kommDisplay.SetActive(true);
        kommBool = true;
        regioBool = false;
        regioDisplay.SetActive(false);
        bRegio.gameObject.SetActive(false);
    }

    void DisableKomm()
    {
        kommDisplay.SetActive(false);
        kommBool = false;
        bRegio.gameObject.SetActive(true);
    }
}
