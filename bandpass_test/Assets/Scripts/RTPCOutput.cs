using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTPCOutput : MonoBehaviour {

    //game object which is playing the event
    public GameObject RTPCgameObject;
    //public GameObject RTPCgameObject2;

    //turn the unaffected signal on or off
    public int drySignalOnOff = 0;

    //Turn the various filtered bands on or off
    public int lowbandOnOff = 1;
    public int midbandOnOff = 1;
    public int highbandOnOff = 1;
    public int vhighbandOnOff = 1;

    //gain control for the various bands
    [Range(0.0f, 2.0f)]
    public float lowbandGain = 0.5f;
    [Range(0.0f, 2.0f)]
    public float midbandGain = 0.0f;
    [Range(0.0f, 2.0f)]
    public float highbandGain = 0.0f;
    [Range(0.0f, 2.0f)]
    public float vhighbandGain = 0.0f;

    //input for rtpc names
    
    public string rtpcName_lowbandVolumedb = "lowband_volumedb";
    public string rtpcName_lowbandVolumerms = "lowband_volumerms";
    public string rtpcName_midbandVolumedb = "midband_volumedb";
    public string rtpcName_midbandVolumerms = "midband_volumerms";
    public string rtpcName_highbandVolumedb = "highband_volumedb";
    public string rtpcName_highbandVolumerms = "highband_volumerms";
    public string rtpcName_vhighbandVolumedb = "vhighband_volumedb";
    public string rtpcName_vhighbandVolumerms = "vhighband_volumerms";
    

    //declare containers for the rtpc output
    [HideInInspector]
    public float lb_volume_db;
    [HideInInspector]
    public float lb_volume_rms;
    [HideInInspector]
    public float mb_volume_db;
    [HideInInspector]
    public float mb_volume_rms;
    [HideInInspector]
    public float hb_volume_db;
    [HideInInspector]
    public float hb_volume_rms;
    [HideInInspector]
    public float vhb_volume_db;
    [HideInInspector]
    public float vhb_volume_rms;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        int type = 2; //type 2 is a game object rtpc. type 1 is a global rtpc (for example a bus volume)
        



        //Set RTPCs from public variables

        //set on/off switches for different bands
        AkSoundEngine.SetRTPCValue("lowband_onoff", lowbandOnOff);
        AkSoundEngine.SetRTPCValue("midband_onoff", midbandOnOff);
        AkSoundEngine.SetRTPCValue("highband_onoff", highbandOnOff);
        AkSoundEngine.SetRTPCValue("vhighband_onoff", vhighbandOnOff);
        AkSoundEngine.SetRTPCValue("drysignal_onoff", drySignalOnOff);

        //set gain for different bands
        AkSoundEngine.SetRTPCValue("lowband_gain", lowbandGain);
        AkSoundEngine.SetRTPCValue("midband_gain", midbandGain);
        AkSoundEngine.SetRTPCValue("highband_gain", highbandGain);
        AkSoundEngine.SetRTPCValue("vhighband_gain", vhighbandGain);

        //get RTPC output 

        //get lowband volume in db
        AkSoundEngine.GetRTPCValue(rtpcName_lowbandVolumedb, RTPCgameObject, 0, out lb_volume_db, ref type);
        //get lowband volume in rms
      //  AkSoundEngine.GetRTPCValue(rtpcName_lowbandVolumerms, RTPCgameObject, 0, out lb_volume_rms, ref type);

        //get midband volume in db
        AkSoundEngine.GetRTPCValue(rtpcName_midbandVolumedb, RTPCgameObject, 0, out mb_volume_db, ref type);
        //get midband volume in rms
      //  AkSoundEngine.GetRTPCValue(rtpcName_midbandVolumerms, RTPCgameObject, 0, out mb_volume_rms, ref type);

        //get highband volume in db
        AkSoundEngine.GetRTPCValue(rtpcName_lowbandVolumedb, RTPCgameObject, 0, out hb_volume_db, ref type);
        //get highband volume in rms
      //  AkSoundEngine.GetRTPCValue(rtpcName_highbandVolumerms, RTPCgameObject, 0, out hb_volume_rms, ref type);

        //get very highband volume in db
        AkSoundEngine.GetRTPCValue(rtpcName_vhighbandVolumedb, RTPCgameObject, 0, out vhb_volume_db, ref type);
        //get very highband volume in rms
      //  AkSoundEngine.GetRTPCValue(rtpcName_vhighbandVolumerms, RTPCgameObject, 0, out vhb_volume_rms, ref type);

        Debug.Log(lb_volume_db);
    }
}
