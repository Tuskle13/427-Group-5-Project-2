using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlatformController : MonoBehaviour {
    Sprite tangible;
    Sprite intangible;

    new SpriteRenderer renderer;
    new BoxCollider2D collider;
    EventSignaler signaler;

    public bool bool1, bool2, bool3, bool4, bool5, bool6, bool7, bool8, bool9,
        boolA, boolB, boolC, boolD, boolE, boolF, boolG, boolH, boolI, boolJ, boolK;

    float startTime;
    int secPerBeat;

    // Use this for initialization
    void Start () {
        tangible = Resources.Load("Floor_Placeholder", typeof(Sprite)) as Sprite;
        intangible = Resources.Load("Intangible_Floor_Placeholder", typeof(Sprite)) as Sprite;

        renderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();

        signaler = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSignaler>();
        secPerBeat = signaler.secPerBeat;
        signaler.Event1.AddListener(respond1);
        signaler.Event2.AddListener(respond2);
        signaler.Event3.AddListener(respond3);
        signaler.Event4.AddListener(respond4);
        signaler.Event5.AddListener(respond5);
        signaler.Event6.AddListener(respond6);
        signaler.Event7.AddListener(respond7);
        signaler.Event8.AddListener(respond8);
        signaler.Event9.AddListener(respond9);
        signaler.EventA.AddListener(respondA);
        signaler.EventB.AddListener(respondB);
        signaler.EventC.AddListener(respondC);
        signaler.EventD.AddListener(respondD);
        signaler.EventE.AddListener(respondE);
        signaler.EventF.AddListener(respondF);
        signaler.EventG.AddListener(respondG);
        signaler.EventH.AddListener(respondH);
        signaler.EventI.AddListener(respondI);
        signaler.EventJ.AddListener(respondJ);
        signaler.EventK.AddListener(respondK);
    }
	
	// Update is called once per frame
	void Update () {
        if (collider.isTrigger && Time.deltaTime > startTime + secPerBeat)
        {
            switchTangibility();
        }
	}

    public void switchTangibility()
    {
        if (collider.isTrigger) MakeTangible();
        else MakeIntangible();
    }

    void MakeIntangible()
    {
        //Debug.Log("Trying to make intangible");
        renderer.sprite = intangible;
        collider.isTrigger = true;
        startTime = Time.deltaTime;
    }

    void MakeTangible()
    {
        //Debug.Log("Trying to make tangible");
        renderer.sprite = tangible;
        collider.isTrigger = false;
    }

    public void respond1() { if (bool1) { switchTangibility(); } }
    public void respond2() { if (bool2) { switchTangibility(); } }
    public void respond3() { if (bool3) { switchTangibility(); } }
    public void respond4() { if (bool4) { switchTangibility(); } }
    public void respond5() { if (bool5) { switchTangibility(); } }
    public void respond6() { if (bool6) { switchTangibility(); } }
    public void respond7() { if (bool7) { switchTangibility(); } }
    public void respond8() { if (bool8) { switchTangibility(); } }
    public void respond9() { if (bool9) { switchTangibility(); } }
    public void respondA() { if (boolA) { switchTangibility(); } }
    public void respondB() { if (boolB) { switchTangibility(); } }
    public void respondC() { if (boolC) { switchTangibility(); } }
    public void respondD() { if (boolD) { switchTangibility(); } }
    public void respondE() { if (boolE) { switchTangibility(); } }
    public void respondF() { if (boolF) { switchTangibility(); } }
    public void respondG() { if (boolG) { switchTangibility(); } }
    public void respondH() { if (boolH) { switchTangibility(); } }
    public void respondI() { if (boolI) { switchTangibility(); } }
    public void respondJ() { if (boolJ) { switchTangibility(); } }
    public void respondK() { if (boolK) { switchTangibility(); } }
}
