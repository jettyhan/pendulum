using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumScript : MonoBehaviour
{
    // 单摆的摆幅
    public uint maxdegree = 30;
    public uint step = 5;

    private int degree;
    private int eachstep;

    // Start is called before the first frame update
    void Start()
    {
        eachstep = (int)(step * 1);
    }

    public void Stop()
    {
        CancelInvoke("UpdateVarValue");
    }

    public void Run()
    {
        InvokeRepeating("UpdateVarValue", 0, 0.2f);
    }

    public void NextStep()
    {
        if (Mathf.Abs(degree) == maxdegree)
        {
            Write.Log("到达最高点");
            eachstep *= -1;
        }

        degree += eachstep;

        transform.RotateAround(new Vector3(0, 5, 0), new Vector3(1, 0, 0), eachstep);
    }

    private void UpdateVarValue()
    {
        NextStep();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
