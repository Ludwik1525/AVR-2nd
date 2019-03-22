using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizStarter : MonoBehaviour
{

    public Button hideButton;
    public GameObject allSettingButtons;
    public Button quizButton;
    public GameObject quizOptions;
    public Button option1;
    public Button option2;
    public Button option3;
    public Button option4;
    public Text counter;
    public Text value;
    public Text questionText;
    public Text questionValue;
    public Text points;
    public Text pointsValue;

    private bool isQuiz = false;

    private int questionNo;
    private bool end = false;
    private Transform chosenObject;
    private string chosenObjectName;
    private int correctAnswer;
    private int numberCorrect;
    private bool wasCorrect = false;

    public GameObject display;
    private MeshRenderer meshRenderer;
    public Material orto;
    public Material hipso;
    public Material regio;

    public GameObject citiesDisplay;
    public GameObject waterDisplay;
    public GameObject regioDisplay;
    public GameObject sevDisplay;
    
    public Transform[] objects;

    public Transform pointer;
    
    private MapSelection mapSelection;
    private LayerSelection cityLayerSelection;
    private LayerSelection waterLayerSelection;
    private LayerSelection regioLayerSelection;
    private LayerSelection sevLayerSelection;

    public Color active;
    public Color inactive;

    private Button bOrto;
    private Button bHipso;
    private Button bRegio;

    private Button bCity;
    private Button bWater;
    private Button bbRegio;
    private Button bSev;

    private Button cityName;
    private Button waterName;
    private Button regioName;
    private Button sevName;


    void Start ()
    {

        active = Color.green;
        inactive = Color.white;

        quizOptions.gameObject.SetActive(false);
        counter.gameObject.SetActive(false);
        value.gameObject.SetActive(false);
        questionText.gameObject.SetActive(false);
        questionValue.gameObject.SetActive(false);
        points.gameObject.SetActive(false);
        pointsValue.gameObject.SetActive(false);
        pointer.gameObject.SetActive(false);

        mapSelection = GetComponent<MapSelection>();
        meshRenderer = display.GetComponent<MeshRenderer>();
        bOrto = mapSelection.bOrto;
        bHipso = mapSelection.bHipso;
        bRegio = mapSelection.bRegio;

        cityLayerSelection = GetComponent<LayerSelection>();
        bCity = cityLayerSelection.bCity;
        cityName = cityLayerSelection.cityName;
        waterLayerSelection = GetComponent<LayerSelection>();
        bWater = waterLayerSelection.bWater;
        waterName = waterLayerSelection.waterName;
        regioLayerSelection = GetComponent<LayerSelection>();
        bbRegio = regioLayerSelection.bRegio;
        regioName = regioLayerSelection.regioName;
        sevLayerSelection = GetComponent<LayerSelection>();
        bSev = sevLayerSelection.bSev;
        sevName = sevLayerSelection.sevName;


        int i = 0;
        objects = new Transform[137];
        for (i = 0; i < citiesDisplay.transform.childCount; i++)
        {
            objects[i] = citiesDisplay.gameObject.transform.GetChild(i);
        }
        for (i = citiesDisplay.transform.childCount; i < citiesDisplay.transform.childCount + waterDisplay.transform.childCount; i++)
        {
            objects[i] = waterDisplay.gameObject.transform.GetChild(i- citiesDisplay.transform.childCount);
        }
        for (i = citiesDisplay.transform.childCount + waterDisplay.transform.childCount; i < citiesDisplay.transform.childCount + waterDisplay.transform.childCount + regioDisplay.transform.childCount; i++)
        {
            objects[i] = regioDisplay.gameObject.transform.GetChild(i - citiesDisplay.transform.childCount - waterDisplay.transform.childCount);
        }
        for (i = citiesDisplay.transform.childCount + waterDisplay.transform.childCount + regioDisplay.transform.childCount; i < citiesDisplay.transform.childCount + waterDisplay.transform.childCount + regioDisplay.transform.childCount + sevDisplay.transform.childCount; i++)
        {
            objects[i] = sevDisplay.gameObject.transform.GetChild(i - citiesDisplay.transform.childCount - waterDisplay.transform.childCount - regioDisplay.transform.childCount);
        }
    }
	
	void Update () {

        if (!isQuiz)
        {
            quizButton.onClick.AddListener(HideStuff);
        }

        if (isQuiz)
        {
            quizButton.onClick.AddListener(ShowStuff);
        }
        
        if(isQuiz)
        {
            option1.onClick.AddListener(delegate { NextRound(option1); });
            option2.onClick.AddListener(delegate { NextRound(option2); });
            option3.onClick.AddListener(delegate { NextRound(option3); });
            option4.onClick.AddListener(delegate { NextRound(option4); });

            if (questionNo == 21)
            {
                StopAllCoroutines();
                points.color = Color.red;
                pointsValue.color = Color.red;
                questionText.color = Color.red;
                questionValue.color = Color.red;
                quizOptions.gameObject.SetActive(false);
            }

            if (end)
            {
                correctAnswer = Random.Range(1, 5);
                chosenObject = objects[Random.Range(0, objects.Length + 1)];

                GameObject.Instantiate(pointer, chosenObject.position, Quaternion.identity);

                if (chosenObject.gameObject.tag == "Seværdigheder")
                {
                    meshRenderer.material = orto;
                    citiesDisplay.gameObject.SetActive(false);
                    waterDisplay.gameObject.SetActive(false);
                    regioDisplay.gameObject.SetActive(false);
                    sevDisplay.gameObject.SetActive(true);
                    for (int i = 0; i < sevDisplay.transform.childCount; i++)
                    {
                        var grandchild = sevDisplay.transform.GetChild(i).transform.GetChild(1).gameObject;
                        if (grandchild != null)
                            grandchild.SetActive(false);
                    }
                }
                else if (chosenObject.gameObject.tag == "Cities")
                {
                    meshRenderer.material = hipso;
                    citiesDisplay.gameObject.SetActive(true);
                    waterDisplay.gameObject.SetActive(false);
                    regioDisplay.gameObject.SetActive(false);
                    sevDisplay.gameObject.SetActive(false);
                    for (int i = 0; i < citiesDisplay.transform.childCount; i++)
                    {
                        var child = citiesDisplay.transform.GetChild(i).transform.GetChild(0).gameObject;
                        if (child != null)
                            child.SetActive(false);
                    }
                }
                else if (chosenObject.gameObject.tag == "Water")
                {
                    meshRenderer.material = hipso;
                    citiesDisplay.gameObject.SetActive(false);
                    waterDisplay.gameObject.SetActive(true);
                    regioDisplay.gameObject.SetActive(false);
                    sevDisplay.gameObject.SetActive(false);
                    for (int i = 0; i < waterDisplay.transform.childCount; i++)
                    {
                        var child = waterDisplay.transform.GetChild(i).transform.GetChild(0).gameObject;
                        if (child != null)
                            child.SetActive(false);
                    }
                }
                else if (chosenObject.gameObject.tag == "Kommunes")
                {
                    meshRenderer.material = regio;
                    citiesDisplay.gameObject.SetActive(false);
                    waterDisplay.gameObject.SetActive(false);
                    regioDisplay.gameObject.SetActive(false);
                    sevDisplay.gameObject.SetActive(false);
                    for (int i = 0; i < regioDisplay.transform.childCount; i++)
                    {
                        var child = regioDisplay.transform.GetChild(i).transform.GetChild(0).gameObject;
                        if (child != null)
                            child.SetActive(false);
                    }
                }

                chosenObjectName = chosenObject.name;
                if (correctAnswer == 1)
                {
                    option1.GetComponentInChildren<Text>().text = chosenObjectName;
                    option2.GetComponentInChildren<Text>().text = objects[Random.Range(0, objects.Length)].name;
                    option3.GetComponentInChildren<Text>().text = objects[Random.Range(0, objects.Length)].name;
                    option4.GetComponentInChildren<Text>().text = objects[Random.Range(0, objects.Length)].name;
                }
                else if (correctAnswer == 2)
                {
                    option2.GetComponentInChildren<Text>().text = chosenObjectName;
                    option1.GetComponentInChildren<Text>().text = objects[Random.Range(0, objects.Length)].name;
                    option3.GetComponentInChildren<Text>().text = objects[Random.Range(0, objects.Length)].name;
                    option4.GetComponentInChildren<Text>().text = objects[Random.Range(0, objects.Length)].name;
                }
                else if (correctAnswer == 3)
                {
                    option3.GetComponentInChildren<Text>().text = chosenObjectName;
                    option1.GetComponentInChildren<Text>().text = objects[Random.Range(0, objects.Length)].name;
                    option2.GetComponentInChildren<Text>().text = objects[Random.Range(0, objects.Length)].name;
                    option4.GetComponentInChildren<Text>().text = objects[Random.Range(0, objects.Length)].name;
                }
                else if (correctAnswer == 4)
                {
                    option4.GetComponentInChildren<Text>().text = chosenObjectName;
                    option1.GetComponentInChildren<Text>().text = objects[Random.Range(0, objects.Length)].name;
                    option2.GetComponentInChildren<Text>().text = objects[Random.Range(0, objects.Length)].name;
                    option3.GetComponentInChildren<Text>().text = objects[Random.Range(0, objects.Length)].name;
                }

                if (wasCorrect)
                {
                    numberCorrect++;
                    pointsValue.text = "" + numberCorrect;
                    wasCorrect = false;
                }

                value.color = Color.black;
                value.text = "" + (11);
                questionNo++;
                if (questionNo == 21)
                {
                    questionValue.text = "" + 20;
                }
                else
                {
                    questionValue.text = "" + questionNo;
                }
                StopAllCoroutines();
                StartCoroutine(Counter(11, value));
                end = false;
            }
        }
    }

    void HideStuff()
    {
        hideButton.gameObject.SetActive(false);
        allSettingButtons.gameObject.SetActive(false);
        quizOptions.gameObject.SetActive(true);
        counter.gameObject.SetActive(true);
        value.gameObject.SetActive(true);
        questionText.gameObject.SetActive(true);
        questionValue.gameObject.SetActive(true);
        points.gameObject.SetActive(true);
        pointsValue.gameObject.SetActive(true);
        pointer.gameObject.SetActive(true);
        isQuiz = true;
        end = true;
        quizButton.GetComponentInChildren<Text>().text = "Slut Quiz";
        citiesDisplay.gameObject.SetActive(false);
        waterDisplay.gameObject.SetActive(false);
        regioDisplay.gameObject.SetActive(false);
        sevDisplay.gameObject.SetActive(false);
    }

    void ShowStuff()
    {
        hideButton.gameObject.SetActive(true);
        allSettingButtons.gameObject.SetActive(true);
        quizOptions.gameObject.SetActive(false);
        counter.gameObject.SetActive(false);
        value.gameObject.SetActive(false);
        questionText.gameObject.SetActive(false);
        questionValue.gameObject.SetActive(false);
        points.gameObject.SetActive(false);
        pointsValue.gameObject.SetActive(false);
        pointer.gameObject.SetActive(false);
        isQuiz = false;
        quizButton.GetComponentInChildren<Text>().text = "Start Quiz";
        questionNo = 0;
        questionValue.text = "" + 0;
        pointsValue.text = "" + 0;
        numberCorrect = 0;
        points.color = Color.black;
        pointsValue.color = Color.black;
        questionText.color = Color.black;
        questionValue.color = Color.black;
        StopAllCoroutines();

        meshRenderer.material = orto;
        bOrto.GetComponent<Image>().color = active;
        bHipso.GetComponent<Image>().color = inactive;
        bRegio.GetComponent<Image>().color = inactive;

        citiesDisplay.SetActive(false);
        waterDisplay.SetActive(false);
        regioDisplay.SetActive(false);
        sevDisplay.SetActive(false);

        bCity.GetComponent<Image>().color = inactive;
        bWater.GetComponent<Image>().color = inactive;
        bbRegio.GetComponent<Image>().color = inactive;
        bSev.GetComponent<Image>().color = inactive;

        cityName.GetComponent<Image>().color = inactive;
        waterName.GetComponent<Image>().color = inactive;
        regioName.GetComponent<Image>().color = inactive;
        sevName.GetComponent<Image>().color = inactive;

        cityName.gameObject.SetActive(false);
        waterName.gameObject.SetActive(false);
        regioName.gameObject.SetActive(false);
        sevName.gameObject.SetActive(false);

        GameObject[] pointers = new GameObject[GameObject.FindGameObjectsWithTag("Pointer").Length];
        pointers = GameObject.FindGameObjectsWithTag("Pointer");

        foreach (GameObject pointer in pointers)
        {
            Destroy(pointer);
        }
    }

    void NextRound(Button button)
    {
        GameObject[] pointers = new GameObject[GameObject.FindGameObjectsWithTag("Pointer").Length];
        pointers = GameObject.FindGameObjectsWithTag("Pointer");

        foreach(GameObject pointer in pointers)
        {
            Destroy(pointer);
        }

        end = true;
        if (button.gameObject.GetComponentInChildren<Text>().text == chosenObjectName)
        {
            wasCorrect = true;
        }
    }

    public IEnumerator Counter(float t, Text i)
    {
        while (int.Parse(i.text) >= 0)
        {
            i.text = "" + (int.Parse(i.text) - 1);
            if (int.Parse(i.text) < 4)
            {
                i.color = Color.red;
            }
            if (int.Parse(i.text) == 0)
            {
                end = true;
                Destroy(GameObject.FindGameObjectWithTag("Pointer"));
            }
            yield return new WaitForSeconds(1);
        }
    }
}
