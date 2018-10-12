using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchTracks : MonoBehaviour {

    public int trackNumber;
    public string switchGroup = "Tracks";
    public string switchID;
    public GameObject gameObject;

	public void switchtheTrack (string switchName)
    {
        AkSoundEngine.SetSwitch("Tracks", switchName, gameObject);
    }
}
