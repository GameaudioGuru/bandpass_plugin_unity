using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

    //This is the RTPCOutput script that holds all of our variables
    public RTPCOutput RTPCOutput;
    private float lowbandDB_output = 0.0f;
    private float lowbandAdjusted;

    float time = 0.5f;


    //Publically define the rect transforms for our various meters

    //lowband
    public RectTransform lowBandMeter_Main;
    public RectTransform lowBandMeter_2;
    public RectTransform lowBandMeter_3;
    public RectTransform lowBandMeter_4;

    //set public inspector variables for the UI textboxes we want to update
    public Text lowbandVolumeOutput_db;
    public Text midbandVolumeOutput_db;
    public Text highbandVolumeOutput_db;
    public Text vhighbandVolumeOutput_db;

    //set public inspector variables for the meters
    public GameObject theMeter;


    // Use this for initialization
    void Start () {

       

    }
	
	// Update is called once per frame
	void Update () {

        lowbandDB_output = RTPCOutput.lb_volume_db;
        lowbandAdjusted = (lowbandDB_output * 0.5f);

        //This is where the UI text fields are updated in real time with the values from the bands
        lowbandVolumeOutput_db.text = RTPCOutput.lb_volume_db.ToString();
        midbandVolumeOutput_db.text = RTPCOutput.mb_volume_db.ToString();
        highbandVolumeOutput_db.text = RTPCOutput.hb_volume_db.ToString();
        vhighbandVolumeOutput_db.text = RTPCOutput.vhb_volume_db.ToString();

        //metering
        //lowband metering
        lowBandMeter_Main.sizeDelta = new Vector2(lowBandMeter_Main.sizeDelta.x, lowbandDB_output);

    }

    void LateUpdate()
    {
       
            lowBandMeter_2.sizeDelta = new Vector2(lowBandMeter_2.sizeDelta.x, lowBandMeter_Main.sizeDelta.y);
        

        //lowBandMeter_3.sizeDelta = new Vector2(lowBandMeter_3.sizeDelta.x, lowbandAdjusted);
        // lowBandMeter_4.sizeDelta = new Vector2(lowBandMeter_4.sizeDelta.x, lowbandAdjusted);
    }
}
