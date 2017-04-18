<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;
using System.Text;
using System;

public class EventSignaler : MonoBehaviour {
    public int secPerBeat = 1;
    public UnityEvent 
        Event1, //16th note
        Event2, //8th note
        Event3, //qtr note
        Event4, //half note
        Event5, //whole note
        Event6, //dotted 16th note
        Event7, //dotted 8th note
        Event8, //dotted qtr note
        Event9, //dotted half note
        EventA, //dotted whole note
        EventB, //16th rest                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
        EventC, //8th rest
        EventD, //qtr rest
        EventE, //half rest
        EventF, //whole rest
        EventG, //dotted 16th rest
        EventH, //dotted 8th rest
        EventI, //dotted qtr rest
        EventJ, //dotted half rest
        EventK; //dotted whole rest

    public AudioSource loop;

    private int msTillLoopStarts = 0;
    private float bpm = 0;
    private string timeMeasure = "";
    private string notes = "";
    private bool paused = true;
    private int currentNote = 0;
    private float secForNote = 0;

    private float
        length1, //16th note
        length2, //8th note
        length3, //qtr note
        length4, //half note
        length5, //whole note
        length6, //dotted 16th note
        length7, //dotted 8th note
        length8, //dotted qtr note
        length9, //dotted half note
        lengthA, //dotted whole note
        lengthB, //16th rest
        lengthC, //8th rest
        lengthD, //qtr rest
        lengthE, //half rest
        lengthF, //whole rest
        lengthG, //dotted 16th rest
        lengthH, //dotted 8th rest
        lengthI, //dotted qtr rest
        lengthJ, //dotted half rest
        lengthK; //dotted whole rest

    // Use this for initialization
    void Start () {
		readFile("A_Fifth_of_Beethoven_Rhythm_File.txt");
        currentNote = notes.Length - 1;
        Invoke("pause", msTillLoopStarts/1000f);

        float beatDiv = (float)Char.GetNumericValue(timeMeasure[0]);
        float num = 60f/bpm * beatDiv;
        float dnum = 1.5f * num;
        
        length1 = num/16; //16th note
        length2 = num/8; //8th note
        length3 = num/4; //qtr note
        length4 = num/2; //half note
        length5 = num/1; //whole note
        length6 = dnum/16; //dotted 16th note
        length7 = dnum/8; //dotted 8th note
        length8 = dnum/4; //dotted qtr note
        length9 = dnum/2; //dotted half note
        lengthA = dnum/1; //dotted whole note
        lengthB = num/16; //16th rest
        lengthC = num/8; //8th rest
        lengthD = num/4; //qtr rest
        lengthE = num/2; //half rest
        lengthF = num/1; //whole rest
        lengthG = dnum/16; //dotted 16th rest
        lengthH = dnum/8; //dotted 8th rest
        lengthI = dnum/4; //dotted qtr rest
        lengthJ = dnum/2; //dotted half rest
        lengthK = dnum/1; //dotted whole rest

        Debug.Log("16th note (1): " + length1);
        Debug.Log("8th note (2): " + length2);
        Debug.Log("qtr note (3): " + length3);
        Debug.Log("half note (4): " + length4);
        Debug.Log("whole note (5): " + length5);
        Debug.Log("dotted 16th note (6): " + length6);
        Debug.Log("dotted 8th note (7): " + length7);
        Debug.Log("dotted qtr note (8): " + length8);
        Debug.Log("dotted half note (9): " + length9);
        Debug.Log("dotted whole note (A): " + lengthA);
        Debug.Log("16th rest (B): " + lengthB);
        Debug.Log("8th rest (C): " + lengthC);
        Debug.Log("qtr rest (D): " + lengthD);
        Debug.Log("half rest (E): " + lengthE);
        Debug.Log("whole rest (F): " + lengthF);
        Debug.Log("dotted 16th rest (G): " + lengthG);
        Debug.Log("dotted 8th rest (H): " + lengthH);
        Debug.Log("dotted qtr rest (I): " + lengthI);
        Debug.Log("dotted half rest (J): " + lengthJ);
        Debug.Log("dotted whole rest (K): " + lengthK);
	}
	
	// Update is called once per frame
	void Update () {
        if(!paused){
            paused = true;

            signal (notes[currentNote]);
            if(currentNote == notes.Length - 1) currentNote = -1;
            currentNote++;
            if(currentNote == notes.Length - 1) currentNote = 0;
            signal (notes[currentNote]);

            Invoke("pause", secForNote);
        }
    }

    void readFile(string fileName){
        try{
            StreamReader reader = new StreamReader("Assets/Files/" + fileName, Encoding.Default);
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

    void pause(){
        paused = !paused;
        if(!loop.isPlaying) loop.Play();
    }

    void startAudioLoop(){

    }

    void signal(char c){
        switch (char.ToLower(c)){
            case '0':
                break;
            case '1':
                Event1.Invoke();
                secForNote = length1;
                break;
            case '2':
                Event2.Invoke();
                secForNote = length2;
                break;
            case '3':
                Event3.Invoke();
                secForNote = length3;
                break;
            case '4':
                Event4.Invoke();
                secForNote = length4;
                break;
            case '5':
                Event5.Invoke();
                secForNote = length5;
                break;
            case '6':
                Event6.Invoke();
                secForNote = length6;
                break;
            case '7':
                Event7.Invoke();
                secForNote = length7;
                break;
            case '8':
                Event8.Invoke();
                secForNote = length8;
                break;
            case '9':
                Event9.Invoke();
                secForNote = length9;
                break;
            case 'a':
                EventA.Invoke();
                secForNote = lengthA;
                break;
            case 'b':
                EventB.Invoke();
                secForNote = lengthB;
                break;
            case 'c':
                EventC.Invoke();
                secForNote = lengthC;
                break;
            case 'd':
                EventD.Invoke();
                secForNote = lengthD;
                break;
            case 'e':
                EventE.Invoke();
                secForNote = lengthE;
                break;
            case 'f':
                EventF.Invoke();
                secForNote = lengthF;
                break;
            case 'g':
                EventG.Invoke();
                secForNote = lengthG;
                break;
            case 'h':
                EventH.Invoke();
                secForNote = lengthH;
                break;
            case 'i':
                EventI.Invoke();
                secForNote = lengthI;
                break;
            case 'j':
                EventJ.Invoke();
                secForNote = lengthJ;
                break;
            case 'k':
                EventK.Invoke();
                secForNote = lengthK;
                break;
        }
    }
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;
using System.Text;
using System;

public class EventSignaler : MonoBehaviour {
    public int secPerBeat = 1;
    public UnityEvent 
        Event1, //16th note
        Event2, //8th note
        Event3, //qtr note
        Event4, //half note
        Event5, //whole note
        Event6, //dotted 16th note
        Event7, //dotted 8th note
        Event8, //dotted qtr note
        Event9, //dotted half note
        EventA, //dotted whole note
        EventB, //16th rest                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
        EventC, //8th rest
        EventD, //qtr rest
        EventE, //half rest
        EventF, //whole rest
        EventG, //dotted 16th rest
        EventH, //dotted 8th rest
        EventI, //dotted qtr rest
        EventJ, //dotted half rest
        EventK; //dotted whole rest

    public AudioSource loop;

    private int msTillLoopStarts = 0;
    private float bpm = 0;
    private string timeMeasure = "";
    private string notes = "";
    private bool paused = true;
    private int currentNote = 0;
    private float secForNote = 0;

    private float
        length1, //16th note
        length2, //8th note
        length3, //qtr note
        length4, //half note
        length5, //whole note
        length6, //dotted 16th note
        length7, //dotted 8th note
        length8, //dotted qtr note
        length9, //dotted half note
        lengthA, //dotted whole note
        lengthB, //16th rest
        lengthC, //8th rest
        lengthD, //qtr rest
        lengthE, //half rest
        lengthF, //whole rest
        lengthG, //dotted 16th rest
        lengthH, //dotted 8th rest
        lengthI, //dotted qtr rest
        lengthJ, //dotted half rest
        lengthK; //dotted whole rest

    // Use this for initialization
    void Start () {
		readFile("A_Fifth_of_Beethoven_Rhythm_File.txt");
        currentNote = notes.Length - 1;
        Invoke("pause", msTillLoopStarts/1000f);

        float beatDiv = (float)Char.GetNumericValue(timeMeasure[0]);
        float num = 60f/bpm * beatDiv;
        float dnum = 1.5f * num;
        
        length1 = num/16; //16th note
        length2 = num/8; //8th note
        length3 = num/4; //qtr note
        length4 = num/2; //half note
        length5 = num/1; //whole note
        length6 = dnum/16; //dotted 16th note
        length7 = dnum/8; //dotted 8th note
        length8 = dnum/4; //dotted qtr note
        length9 = dnum/2; //dotted half note
        lengthA = dnum/1; //dotted whole note
        lengthB = num/16; //16th rest
        lengthC = num/8; //8th rest
        lengthD = num/4; //qtr rest
        lengthE = num/2; //half rest
        lengthF = num/1; //whole rest
        lengthG = dnum/16; //dotted 16th rest
        lengthH = dnum/8; //dotted 8th rest
        lengthI = dnum/4; //dotted qtr rest
        lengthJ = dnum/2; //dotted half rest
        lengthK = dnum/1; //dotted whole rest

        Debug.Log("16th note (1): " + length1);
        Debug.Log("8th note (2): " + length2);
        Debug.Log("qtr note (3): " + length3);
        Debug.Log("half note (4): " + length4);
        Debug.Log("whole note (5): " + length5);
        Debug.Log("dotted 16th note (6): " + length6);
        Debug.Log("dotted 8th note (7): " + length7);
        Debug.Log("dotted qtr note (8): " + length8);
        Debug.Log("dotted half note (9): " + length9);
        Debug.Log("dotted whole note (A): " + lengthA);
        Debug.Log("16th rest (B): " + lengthB);
        Debug.Log("8th rest (C): " + lengthC);
        Debug.Log("qtr rest (D): " + lengthD);
        Debug.Log("half rest (E): " + lengthE);
        Debug.Log("whole rest (F): " + lengthF);
        Debug.Log("dotted 16th rest (G): " + lengthG);
        Debug.Log("dotted 8th rest (H): " + lengthH);
        Debug.Log("dotted qtr rest (I): " + lengthI);
        Debug.Log("dotted half rest (J): " + lengthJ);
        Debug.Log("dotted whole rest (K): " + lengthK);
	}
	
	// Update is called once per frame
	void Update () {
        if(!paused){
            paused = true;

            signal (notes[currentNote]);
            if(currentNote == notes.Length - 1) currentNote = -1;
            currentNote++;
            if(currentNote == notes.Length - 1) currentNote = 0;
            signal (notes[currentNote]);

            Invoke("pause", secForNote);
        }
    }

    void readFile(string fileName){
        try{
            StreamReader reader = new StreamReader("Assets/Files/" + fileName, Encoding.Default);
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

    void pause(){
        paused = !paused;
        if(!loop.isPlaying) loop.Play();
    }

    void startAudioLoop(){

    }

    void signal(char c){
        switch (char.ToLower(c)){
            case '0':
                break;
            case '1':
                Event1.Invoke();
                secForNote = length1;
                break;
            case '2':
                Event2.Invoke();
                secForNote = length2;
                break;
            case '3':
                Event3.Invoke();
                secForNote = length3;
                break;
            case '4':
                Event4.Invoke();
                secForNote = length4;
                break;
            case '5':
                Event5.Invoke();
                secForNote = length5;
                break;
            case '6':
                Event6.Invoke();
                secForNote = length6;
                break;
            case '7':
                Event7.Invoke();
                secForNote = length7;
                break;
            case '8':
                Event8.Invoke();
                secForNote = length8;
                break;
            case '9':
                Event9.Invoke();
                secForNote = length9;
                break;
            case 'a':
                EventA.Invoke();
                secForNote = lengthA;
                break;
            case 'b':
                EventB.Invoke();
                secForNote = lengthB;
                break;
            case 'c':
                EventC.Invoke();
                secForNote = lengthC;
                break;
            case 'd':
                EventD.Invoke();
                secForNote = lengthD;
                break;
            case 'e':
                EventE.Invoke();
                secForNote = lengthE;
                break;
            case 'f':
                EventF.Invoke();
                secForNote = lengthF;
                break;
            case 'g':
                EventG.Invoke();
                secForNote = lengthG;
                break;
            case 'h':
                EventH.Invoke();
                secForNote = lengthH;
                break;
            case 'i':
                EventI.Invoke();
                secForNote = lengthI;
                break;
            case 'j':
                EventJ.Invoke();
                secForNote = lengthJ;
                break;
            case 'k':
                EventK.Invoke();
                secForNote = lengthK;
                break;
        }
    }
>>>>>>> origin/master
}