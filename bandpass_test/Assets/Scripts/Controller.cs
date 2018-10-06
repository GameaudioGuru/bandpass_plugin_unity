using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

    //This is the RTPCOutput script that holds all of our variables
    public RTPCOutput RTPCOutput;

    //set public inspector variables for the UI textboxes we want to update
    public Text lowbandVolumeOutput_db;
    public Text midbandVolumeOutput_db;
    public Text highbandVolumeOutput_db;
    public Text vhighbandVolumeOutput_db;





    //private float outputtest = 50.15f;
    private float rtpcoutput;

    // Use this for initialization
    void Start () {

      

    }
	
	// Update is called once per frame
	void Update () {

      
        //This is where the UI text fields are updated in real time with the values from the bands
        lowbandVolumeOutput_db.text = RTPCOutput.lb_volume_db.ToString();
        midbandVolumeOutput_db.text = RTPCOutput.mb_volume_db.ToString();
        highbandVolumeOutput_db.text = RTPCOutput.hb_volume_db.ToString();
        vhighbandVolumeOutput_db.text = RTPCOutput.vhb_volume_db.ToString();

    }
}
