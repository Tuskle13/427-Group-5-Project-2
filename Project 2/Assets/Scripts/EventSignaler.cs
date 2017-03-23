using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;
using System.Text;
using System;

public class EventSignaler : MonoBehaviour {
    public int secPerBeat = 1;
    public UnityEvent Event1, Event2, Event3, Event4, Event5, Event6, Event7, Event8, Event9,
        EventA, EventB, EventC, EventD, EventE, EventF, EventG, EventH, EventI, EventJ, EventK;    //We can use this to signal to all platforms when theres a switch

    // Use this for initialization
    void Start () {
		readFile("myFile");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))    //for testing the event system
            Event1.Invoke();
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Event2.Invoke();
        if (Input.GetKeyDown(KeyCode.Alpha3))
            Event3.Invoke();
        if (Input.GetKeyDown(KeyCode.Alpha4))
            Event4.Invoke();
        if (Input.GetKeyDown(KeyCode.Alpha5))
            Event5.Invoke();
        if (Input.GetKeyDown(KeyCode.Alpha6))
            Event6.Invoke();
        if (Input.GetKeyDown(KeyCode.Alpha7))
            Event7.Invoke();
        if (Input.GetKeyDown(KeyCode.Alpha8))
            Event8.Invoke();
        if (Input.GetKeyDown(KeyCode.Alpha9))
            Event9.Invoke();
        if (Input.GetKeyDown(KeyCode.A))
            EventA.Invoke();
        if (Input.GetKeyDown(KeyCode.B))
            EventB.Invoke();
        if (Input.GetKeyDown(KeyCode.C))
            EventC.Invoke();
        if (Input.GetKeyDown(KeyCode.D))
            EventD.Invoke();
        if (Input.GetKeyDown(KeyCode.E))
            EventE.Invoke();
        if (Input.GetKeyDown(KeyCode.F))
            EventF.Invoke();
        if (Input.GetKeyDown(KeyCode.G))
            EventG.Invoke();
        if (Input.GetKeyDown(KeyCode.H))
            EventH.Invoke();
        if (Input.GetKeyDown(KeyCode.I))
            EventI.Invoke();
        if (Input.GetKeyDown(KeyCode.J))
            EventJ.Invoke();
        if (Input.GetKeyDown(KeyCode.K))
            EventK.Invoke();
    }

    void readFile(string fileName){
        int msTillLoopStarts;
        int bpm;
        string timeMeasure;
        string notes;
        
        try{
            string line;
            StreamReader reader = new StreamReader(fileName, Encoding.Default);
            using (reader){
                
                msTillLoopStarts = int.Parse(reader.ReadLine());
                bpm = int.Parse(reader.ReadLine());
                timeMeasure = reader.ReadLine();
                notes = reader.ReadLine();

                reader.Close();
            }
        } catch(Exception e){
            Debug.Log(e);
        }
    }
}