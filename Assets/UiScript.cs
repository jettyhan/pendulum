using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiScript : MonoBehaviour
{
    // 单摆1
    public GameObject pendulum1;

    // 单摆2
    public GameObject pendulum2;

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
        Text text = btnRunStrop.transform.Find("Text").GetComponent<Text>();
        if (text.text == "运行")
        {
            text.text = "停止";
            DoRun(pendulum1, true);
            DoRun(pendulum2, true);
        }
        else
        {
            text.text = "运行";
            DoRun(pendulum1,false);
            DoRun(pendulum2,false);
        }
    }

    void Next()
    {
        Text text = btnRunStrop.transform.Find("Text").GetComponent<Text>();
        if (text.text == "运行")
        {
            DoNextStep(pendulum1);
            DoNextStep(pendulum2);
        }

    }

    private void DoRun(GameObject pendulum, bool run)
    {
        PendulumScript pendulumScript = pendulum.GetComponent<PendulumScript>();
        if (run)
        {
            pendulumScript.Run();
        }
        else
        {
            pendulumScript.Stop();
        }

    }

    private void DoNextStep(GameObject pendulum)
    {
        PendulumScript pendulumScript = pendulum.GetComponent<PendulumScript>();
        pendulumScript.NextStep();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
