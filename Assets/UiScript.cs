using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiScript : MonoBehaviour
{
    // 单摆
    public GameObject pendulum;

    private Button btnRunStrop;
    private Button btnNextStep;

    // Start is called before the first frame update
    void Start()
    {
        Write.console.LogStart();

        GameObject btnObj = transform.Find("RunStop").gameObject;
        btnRunStrop = btnObj.GetComponent<Button>();
        if (btnRunStrop)
        {
            btnRunStrop.onClick.AddListener(RunStop);
        }

        btnObj = transform.Find("Next").gameObject;
        btnNextStep = btnObj.GetComponent<Button>();
        if (btnNextStep)
        {
            btnNextStep.onClick.AddListener(Next);
        }
    }

    void RunStop()
    {
        PendulumScript pendulumScript = pendulum.GetComponent<PendulumScript>();

        Text text = btnRunStrop.transform.Find("Text").GetComponent<Text>();
        if (text.text == "运行")
        {
            text.text = "停止";
            pendulumScript.Run();
        }
        else
        {
            text.text = "运行";
            pendulumScript.Stop();
        }
    }

    void Next()
    {
        PendulumScript pendulumScript = pendulum.GetComponent<PendulumScript>();

        Text text = btnRunStrop.transform.Find("Text").GetComponent<Text>();
        if (text.text == "运行")
        {
            pendulumScript.NextStep();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
