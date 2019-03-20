using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LayerSelection : MonoBehaviour
{
    // surfaces displaying given layer
    public GameObject citiesDisplay;
    public GameObject waterDisplay;
    public GameObject regioDisplay;
    public GameObject kommDisplay;
    public GameObject sevDisplay;

    // buttons eabling and disabling given layer
    public Button bCity;
    public Button bWater;
    public Button bRegio;
    public Button bKomm;
    public Button bSev;

    // buttons enabling and disabling names for given layer
    public Button cityName;
    public Button waterName;
    public Button regioName;
    public Button kommName;
    public Button sevName;

    // bools for checking if given layer is active
    private bool cityBool = false;
    private bool waterBool = false;
    public bool regioBool = false;
    private bool kommBool = false;
    private bool sevBool = false;

    // bools for checking if names for given layer are active
    private bool cityNameBool = false;
    private bool waterNameBool = false;
    public bool regioNameBool = false;
    private bool kommNameBool = false;
    private bool sevNameBool = false;

    // colours for buttons
    public Color active;
    public Color inactive;

    void Start()
    {
        // disable all layers
        citiesDisplay.SetActive(false);
        waterDisplay.SetActive(false);
        regioDisplay.SetActive(false);
        kommDisplay.SetActive(false);
        sevDisplay.SetActive(false);
        

        //disable all names buttons
        cityName.gameObject.SetActive(false);
        waterName.gameObject.SetActive(false);
        regioName.gameObject.SetActive(false);
        kommName.gameObject.SetActive(false);
        sevName.gameObject.SetActive(false);

        // disable all names
        DisableCityNames();
        DisableKommNames();
        DisableWaterNames();
        DisableRegioNames();
        DisableSevNames();
        DisableSev();

        // assign colours
        active = Color.green;
        inactive = Color.white;

        // set layers buttons' colours
        bCity.GetComponent<Image>().color = inactive;
        bWater.GetComponent<Image>().color = inactive;
        bRegio.GetComponent<Image>().color = inactive;
        bKomm.GetComponent<Image>().color = inactive;
        bSev.GetComponent<Image>().color = inactive;

        // set name buttons' colours
        cityName.GetComponent<Image>().color = inactive;
        waterName.GetComponent<Image>().color = inactive;
        regioName.GetComponent<Image>().color = inactive;
        kommName.GetComponent<Image>().color = inactive;
        sevName.GetComponent<Image>().color = inactive;
        
    }

    void Update()
    {
        // if given layer is inactive, then turn it on, if is active, turn it off
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

        if (!sevBool)
        {
            bSev.onClick.AddListener(SetSev);
        }

        if(sevBool)
        {
            bSev.onClick.AddListener(DisableSev);
        }

        // if names for given layer are inactive, then turn them on, if they are active, turn them off
        if (!cityNameBool)
        {
            cityName.onClick.AddListener(SetCityNames);
        }

        if (cityNameBool)
        {
            cityName.onClick.AddListener(DisableCityNames);
        }

        if (!waterNameBool)
        {
            waterName.onClick.AddListener(SetWaterNames);
        }

        if (waterNameBool)
        {
            waterName.onClick.AddListener(DisableWaterNames);
        }

        if (!regioNameBool)
        {
            regioName.onClick.AddListener(SetRegioNames);
        }

        if (regioNameBool)
        {
            regioName.onClick.AddListener(DisableRegioNames);
        }

        if (!kommNameBool)
        {
            kommName.onClick.AddListener(SetKommNames);
        }

        if (kommNameBool)
        {
            kommName.onClick.AddListener(DisableKommNames);
        }

        if (!sevNameBool)
        {
            sevName.onClick.AddListener(SetSevNames);
        }

        if (sevNameBool)
        {
            sevName.onClick.AddListener(DisableSevNames);
        }
    }

    // functions for enabling and disabling layers
    void SetCity()
    {
        citiesDisplay.SetActive(true);
        cityBool = true;
        cityName.gameObject.SetActive(true);
        bCity.GetComponent<Image>().color = active;
        DisableCityNames();
    }

    void DisableCity()
    {
        citiesDisplay.SetActive(false);
        cityBool = false;
        cityName.gameObject.SetActive(false);
        DisableCityNames();
        bCity.GetComponent<Image>().color = inactive;
    }

    void SetWater()
    {
        waterDisplay.SetActive(true);
        waterBool = true;
        waterName.gameObject.SetActive(true);
        bWater.GetComponent<Image>().color = active;
        DisableWaterNames();
    }

    void DisableWater()
    {
        waterDisplay.SetActive(false);
        waterBool = false;
        waterName.gameObject.SetActive(false);
        DisableWaterNames();
        bWater.GetComponent<Image>().color = inactive;
    }

    void SetRegio()
    {
        regioDisplay.SetActive(true);
        regioBool = true;
        regioName.gameObject.SetActive(true);
        bRegio.GetComponent<Image>().color = active;
        DisableRegioNames();
    }

    void DisableRegio()
    {
        regioDisplay.SetActive(false);
        regioBool = false;
        regioName.gameObject.SetActive(false);
        DisableRegioNames();
        bRegio.GetComponent<Image>().color = inactive;
    }

    void SetKomm()
    {
        kommDisplay.SetActive(true);
        kommBool = true;
        regioBool = false;
        regioDisplay.SetActive(false);
        regioName.gameObject.SetActive(false);
        DisableRegioNames();
        DisableKommNames();
        bRegio.GetComponent<Image>().color = inactive;
        bRegio.gameObject.SetActive(false);
        kommName.gameObject.SetActive(true);
        bKomm.GetComponent<Image>().color = active;
    }

    void DisableKomm()
    {
        kommDisplay.SetActive(false);
        kommBool = false;
        kommName.gameObject.SetActive(false);
        DisableKommNames();
        bKomm.GetComponent<Image>().color = inactive;
        bRegio.gameObject.SetActive(true);
    }

    void SetSev()
    {
        sevDisplay.gameObject.SetActive(true);
        GameObject[] sevs = new GameObject[50];
        sevs = GameObject.FindGameObjectsWithTag("Seværdigheder");
        foreach (GameObject sev in sevs)
        {
            sev.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }

        sevBool = true;
        bSev.GetComponent<Image>().color = active;
        sevName.gameObject.SetActive(true);
        DisableSevNames();
    }

    void DisableSev()
    {
        sevDisplay.gameObject.SetActive(false);
        GameObject[] sevs = new GameObject[50];
        sevs = GameObject.FindGameObjectsWithTag("Seværdigheder");
        foreach (GameObject sev in sevs)
        {
            sev.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }

        sevBool = false;
        bSev.GetComponent<Image>().color = inactive;
        sevName.gameObject.SetActive(false);
        DisableSevNames();
    }

    // functions for enabling and disabling names for each layer
    void SetCityNames()
    {
        GameObject[] names = new GameObject[50];
        names = GameObject.FindGameObjectsWithTag("Cities");
        foreach (GameObject city in names)
        {
            city.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }

        cityNameBool = true;
        cityName.GetComponent<Image>().color = active;
    }

    void DisableCityNames()
    {
        GameObject[] names = new GameObject[50];
        names = GameObject.FindGameObjectsWithTag("Cities");
        foreach (GameObject city in names)
        {
            city.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }

        cityNameBool = false;
        cityName.GetComponent<Image>().color = inactive;
    }

    void SetWaterNames()
    {
        GameObject[] names = new GameObject[50];
        names = GameObject.FindGameObjectsWithTag("Water");
        foreach (GameObject water in names)
        {
            water.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }

        waterNameBool = true;
        waterName.GetComponent<Image>().color = active;
    }

    void DisableWaterNames()
    {
        GameObject[] names = new GameObject[50];
        names = GameObject.FindGameObjectsWithTag("Water");
        foreach (GameObject water in names)
        {
            water.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }

        waterNameBool = false;
        waterName.GetComponent<Image>().color = inactive;
    }

    void SetRegioNames()
    {
        GameObject[] names = new GameObject[5];
        names = GameObject.FindGameObjectsWithTag("Kommunes");
        foreach (GameObject komm in names)
        {
            komm.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }

        regioNameBool = true;
        regioName.GetComponent<Image>().color = active;
    }

    void DisableRegioNames()
    {
        GameObject[] names = new GameObject[5];
        names = GameObject.FindGameObjectsWithTag("Kommunes");
        foreach (GameObject komm in names)
        {
            komm.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }

        regioNameBool = false;
        regioName.GetComponent<Image>().color = inactive;
    }

    void SetKommNames()
    {
        GameObject[] names = new GameObject[98];
        names = GameObject.FindGameObjectsWithTag("Regions");
        foreach (GameObject reg in names)
        {
            reg.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }

        kommNameBool = true;
        kommName.GetComponent<Image>().color = active;
    }

    void DisableKommNames()
    {
        GameObject[] names = new GameObject[98];
        names = GameObject.FindGameObjectsWithTag("Regions");
        foreach (GameObject reg in names)
        {
            reg.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }

        kommNameBool = false;
        kommName.GetComponent<Image>().color = inactive;
    }

    void SetSevNames()
    {
        GameObject[] sevs = new GameObject[50];
        sevs = GameObject.FindGameObjectsWithTag("Seværdigheder");
        foreach (GameObject sev in sevs)
        {
            sev.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }

        sevNameBool = true;
        sevName.GetComponent<Image>().color = active;
    }

    void DisableSevNames()
    {
        GameObject[] sevs = new GameObject[50];
        sevs = GameObject.FindGameObjectsWithTag("Seværdigheder");
        foreach (GameObject sev in sevs)
        {
            sev.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }

        sevNameBool = false;
        sevName.GetComponent<Image>().color = inactive;
    }
}
