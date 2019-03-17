using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LayerSelection : MonoBehaviour
{

    public GameObject citiesDisplay;
    public GameObject waterDisplay;
    public GameObject regioDisplay;
    public GameObject kommDisplay;

    public Button bCity;
    public Button bWater;
    public Button bRegio;
    public Button bKomm;

    public Button cityName;
    public Button waterName;
    public Button regioName;
    public Button kommName;

    private bool cityBool = false;
    private bool waterBool = false;
    public bool regioBool = false;
    private bool kommBool = false;

    private bool cityNameBool = false;
    private bool waterNameBool = false;
    public bool regioNameBool = false;
    private bool kommNameBool = false;

    public Color active;
    public Color inactive;

    private MapSelection mapSelection;
    private bool isRegio = false;

    void Start()
    {
        citiesDisplay.SetActive(false);
        waterDisplay.SetActive(false);
        regioDisplay.SetActive(false);
        kommDisplay.SetActive(false);

        cityName.gameObject.SetActive(false);
        waterName.gameObject.SetActive(false);
        regioName.gameObject.SetActive(false);
        kommName.gameObject.SetActive(false);

        DisableCityNames();
        DisableKommNames();
        DisableWaterNames();
        DisableRegioNames();

        active = Color.green;
        inactive = Color.white;

        bCity.GetComponent<Image>().color = inactive;
        bWater.GetComponent<Image>().color = inactive;
        bRegio.GetComponent<Image>().color = inactive;
        bKomm.GetComponent<Image>().color = inactive;


        cityName.GetComponent<Image>().color = inactive;
        waterName.GetComponent<Image>().color = inactive;
        regioName.GetComponent<Image>().color = inactive;
        kommName.GetComponent<Image>().color = inactive;

        mapSelection = GetComponent<MapSelection>();
        isRegio = mapSelection.isRegio;
    }

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

        isRegio = mapSelection.isRegio;
    }

    void SetCity()
    {
        citiesDisplay.SetActive(true);
        cityBool = true;
        cityName.gameObject.SetActive(true);
        bCity.GetComponent<Image>().color = active;
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

        if(!isRegio)
        {
            bRegio.gameObject.SetActive(true);
        }
    }


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
}
