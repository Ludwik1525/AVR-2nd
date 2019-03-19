using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private MapSelection mapSelection;

    public GameObject display;
    private MeshRenderer meshRenderer;
    public Material orto;
    public Material hipso;
    public Material regio;

    void Start () {

		quizOptions.gameObject.SetActive(false);
        counter.gameObject.SetActive(false);
        value.gameObject.SetActive(false);
        questionText.gameObject.SetActive(false);
        questionValue.gameObject.SetActive(false);
        points.gameObject.SetActive(false);
        pointsValue.gameObject.SetActive(false);
        mapSelection = GetComponent<MapSelection>();
        meshRenderer = display.GetComponent<MeshRenderer>();
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

        option1.onClick.AddListener(NextRound);
        option2.onClick.AddListener(NextRound);
        option3.onClick.AddListener(NextRound);
        option4.onClick.AddListener(NextRound);

        if (questionNo == 21)
        {
            StopAllCoroutines();
            points.color = Color.red;
            pointsValue.color = Color.red;
            questionText.color = Color.red;
            questionValue.color = Color.red;
        }

        if(end)
        {
            StopAllCoroutines();
            value.color = Color.black;
            value.text = "" + (11);
            StartCoroutine(Counter(11, value));
            questionNo++;
            questionValue.text = "" + questionNo;
            end = false;
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
        isQuiz = true;
        end = true;
        quizButton.GetComponentInChildren<Text>().text = "Slut Quiz";
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
        isQuiz = false;
        quizButton.GetComponentInChildren<Text>().text = "Start Quiz";
        questionNo = 0;
        questionValue.text = "" + 0;
        pointsValue.text = "" + 0;
        points.color = Color.black;
        pointsValue.color = Color.black;
        questionText.color = Color.black;
        questionValue.color = Color.black;
        StopAllCoroutines();
    }

    void NextRound()
    {
        end = true;
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
            }
            yield return new WaitForSeconds(1);
        }
    }
}
