using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

    //This is the RTPCOutput script 
    public RTPCOutput RTPCOutput;

    private float lowbandDB_output = 0.0f;
    private float midbandDB_output = 0.0f;
    private float highbandDB_output = 0.0f;
    private float vhighbandDB_output = 0.0f;


    //define a queue which holds the output values for the volume level to use in the trail meters
    //lowband queues
    public Queue<float> lowbandQueue = new Queue<float>();
    public Queue<float> lowbandQueue2 = new Queue<float>();
    public Queue<float> lowbandQueue3 = new Queue<float>();
    public Queue<float> lowbandQueue4 = new Queue<float>();

    //TODO: Make midband queues
    public Queue<float> midbandQueue = new Queue<float>();
    public Queue<float> midbandQueue2 = new Queue<float>();
    public Queue<float> midbandQueue3 = new Queue<float>();
    public Queue<float> midbandQueue4 = new Queue<float>();

    //TODO: Make Highband queues
    public Queue<float> highbandQueue = new Queue<float>();
    public Queue<float> highbandQueue2 = new Queue<float>();
    public Queue<float> highbandQueue3 = new Queue<float>();
    public Queue<float> highbandQueue4 = new Queue<float>();

    //TODO: Make vHighband queues
    public Queue<float> vhighbandQueue = new Queue<float>();
    public Queue<float> vhighbandQueue2 = new Queue<float>();
    public Queue<float> vhighbandQueue3 = new Queue<float>();
    public Queue<float> vhighbandQueue4 = new Queue<float>();

    //base time to offset the trailing meters
    float time = 0.25f;


    //Publically define the rect transforms for our various meters
    //TODO: Create a more elegant system for declaring or controlling the meters
    //lowband
    public RectTransform lowBandMeter_Main;
    public RectTransform lowBandMeter_2;
    public RectTransform lowBandMeter_3;
    public RectTransform lowBandMeter_4;
    public RectTransform lowBandMeter_5;
    public RectTransform lowBandMeter_6;
    public RectTransform lowBandMeter_7;

    //TODO: Make midband rects
    public RectTransform midBandMeter_Main;
    public RectTransform midBandMeter_2;
    public RectTransform midBandMeter_3;
    public RectTransform midBandMeter_4;
    public RectTransform midBandMeter_5;
    public RectTransform midBandMeter_6;
    public RectTransform midBandMeter_7;

    //TODO: Make Highband rects
    public RectTransform highBandMeter_Main;
    public RectTransform highBandMeter_2;
    public RectTransform highBandMeter_3;
    public RectTransform highBandMeter_4;
    public RectTransform highBandMeter_5;
    public RectTransform highBandMeter_6;
    public RectTransform highBandMeter_7;

    //TODO: Make vHighband rects
    public RectTransform vhighBandMeter_Main;
    public RectTransform vhighBandMeter_2;
    public RectTransform vhighBandMeter_3;
    public RectTransform vhighBandMeter_4;
    public RectTransform vhighBandMeter_5;
    public RectTransform vhighBandMeter_6;
    public RectTransform vhighBandMeter_7;

    //set public inspector variables for the UI textboxes we want to update with the volume values from RTPC output
    //this is the text display of the volume values
    public Text lowbandVolumeOutput_db;
    public Text midbandVolumeOutput_db;
    public Text highbandVolumeOutput_db;
    public Text vhighbandVolumeOutput_db;

    //controls for the meter coefficients
    [Range(0.0f, 3.0f)]
    public float powerOf = 1.0f;
    [Range(0.0f, 2.0f)]
    public float multiplier = 1.25f;

    //sliders for outer trailing meters
    [Range(0.0f, 1.0f)]
    public float firstPairCoefficient = 0.75f;
    [Range(0.0f, 1.0f)]
    public float secondPairCoefficient = 0.50f;
    [Range(0.0f, 1.0f)]
    public float thirdPairCoefficient = 0.25f;



    void Start ()
    {
        powerOf = 1.0f;
        multiplier = 1.0f;
    }

    // Update is called once per frame
    void Update () {

        //define a variable to hold the values streaming from the volume of the bands
        lowbandDB_output = Mathf.Round(RTPCOutput.lb_volume_db);
        midbandDB_output = Mathf.Round(RTPCOutput.mb_volume_db);
        highbandDB_output = Mathf.Round(RTPCOutput.hb_volume_db);
        vhighbandDB_output = Mathf.Round(RTPCOutput.hb_volume_db);

        var lowOutPutModified = (Mathf.Pow(lowbandDB_output, powerOf)*multiplier);
        var midOutPutModified = (Mathf.Pow(midbandDB_output, powerOf) * multiplier);
        var highOutPutModified = (Mathf.Pow(highbandDB_output, powerOf) * multiplier);
        var vhighOutPutModified = (Mathf.Pow(vhighbandDB_output, powerOf) * multiplier);

        //This is where the UI text fields are updated in real time with the values from the bands
        lowbandVolumeOutput_db.text = lowbandDB_output.ToString();
        midbandVolumeOutput_db.text = midbandDB_output.ToString();
        highbandVolumeOutput_db.text = highbandDB_output.ToString();
        vhighbandVolumeOutput_db.text = vhighbandDB_output.ToString();


        //load the queues up with the values from the lowband output for outputting later
        lowbandQueue.Enqueue(lowbandDB_output);
        lowbandQueue2.Enqueue(lowbandDB_output);
        lowbandQueue3.Enqueue(lowbandDB_output);
       // lowbandQueue4.Enqueue(lowbandDB_output);

        midbandQueue.Enqueue(midbandDB_output);
        midbandQueue2.Enqueue(midbandDB_output);
        midbandQueue3.Enqueue(midbandDB_output);
       // midbandQueue4.Enqueue(midbandDB_output);

        highbandQueue.Enqueue(highbandDB_output);
        highbandQueue2.Enqueue(highbandDB_output);
        highbandQueue3.Enqueue(highbandDB_output);
      //  highbandQueue4.Enqueue(highbandDB_output);

        highbandQueue.Enqueue(highbandDB_output);
        highbandQueue2.Enqueue(highbandDB_output);
        highbandQueue3.Enqueue(highbandDB_output);
        // highbandQueue4.Enqueue(highbandDB_output);

        vhighbandQueue.Enqueue(vhighbandDB_output);
        vhighbandQueue2.Enqueue(vhighbandDB_output);
        vhighbandQueue3.Enqueue(vhighbandDB_output);
        // vhighbandQueue4.Enqueue(highbandDB_output);


        //metering
        //center meters for all four bands
        lowBandMeter_Main.sizeDelta = new Vector2(lowBandMeter_Main.sizeDelta.x, lowOutPutModified);
        midBandMeter_Main.sizeDelta = new Vector2(midBandMeter_Main.sizeDelta.x, midOutPutModified);
        highBandMeter_Main.sizeDelta = new Vector2(highBandMeter_Main.sizeDelta.x, highOutPutModified);
        vhighBandMeter_Main.sizeDelta = new Vector2(vhighBandMeter_Main.sizeDelta.x, vhighOutPutModified);

        //set up variables to dump the queues into
        var lowQueueMain = 0.0f;
        var lowQueue2 = 0.0f;
        var lowQueue3 = 0.0f;

        var midQueueMain = 0.0f;
        var midQueue2 = 0.0f;
        var midQueue3 = 0.0f;

        var highQueueMain = 0.0f;
        var highQueue2 = 0.0f;
        var highQueue3 = 0.0f;

        var vhighQueueMain = 0.0f;
        var vhighQueue2 = 0.0f;
        var vhighQueue3 = 0.0f;



        // Countdown timers to dequeue the cues to a variable which creates the timing offset
        //TODO: create a more elegant timing system
        if (time >= 0.0f)
        {
            time -= Time.deltaTime;
        }
        else
        {
            lowQueueMain = (lowbandQueue.Dequeue()) * firstPairCoefficient;
            midQueueMain = (midbandQueue.Dequeue()) * firstPairCoefficient;
            highQueueMain = (highbandQueue.Dequeue()) * firstPairCoefficient;
            vhighQueueMain = (vhighbandQueue.Dequeue()) * firstPairCoefficient;
        }

        if ((time +0.25) >= 0.0f)
        {
            time -= Time.deltaTime;
        }
        else
        {
            lowQueue2 = (lowbandQueue2.Dequeue()) * secondPairCoefficient;
            midQueue2 = (midbandQueue2.Dequeue()) * secondPairCoefficient;
            highQueue2 = (highbandQueue2.Dequeue()) * secondPairCoefficient;
            vhighQueue2 = (vhighbandQueue2.Dequeue()) * secondPairCoefficient;
        }

        if ((time + 0.30) >= 0.0f)
        {
            time -= Time.deltaTime;
        }
        else
        {
            lowQueue3 = (lowbandQueue3.Dequeue()) * thirdPairCoefficient;
            midQueue3 = (midbandQueue3.Dequeue()) * thirdPairCoefficient;
            highQueue3 = (highbandQueue3.Dequeue()) * thirdPairCoefficient;
            vhighQueue3 = (vhighbandQueue3.Dequeue()) * thirdPairCoefficient;
        }


        //This is where the actual height of the meters is set to the delayed values stored in the queues

        //lowbands
        lowBandMeter_2.sizeDelta = new Vector2(lowBandMeter_2.sizeDelta.x, lowQueueMain);
        lowBandMeter_5.sizeDelta = new Vector2(lowBandMeter_5.sizeDelta.x, lowQueueMain);

        lowBandMeter_3.sizeDelta = new Vector2(lowBandMeter_3.sizeDelta.x, lowQueue2);
        lowBandMeter_6.sizeDelta = new Vector2(lowBandMeter_6.sizeDelta.x, lowQueue2);

        lowBandMeter_4.sizeDelta = new Vector2(lowBandMeter_4.sizeDelta.x, lowQueue3);
        lowBandMeter_7.sizeDelta = new Vector2(lowBandMeter_7.sizeDelta.x, lowQueue3);

        //midbands
        midBandMeter_2.sizeDelta = new Vector2(midBandMeter_2.sizeDelta.x, midQueueMain);
        midBandMeter_5.sizeDelta = new Vector2(midBandMeter_5.sizeDelta.x, midQueueMain);

        midBandMeter_3.sizeDelta = new Vector2(midBandMeter_3.sizeDelta.x, midQueue2);
        midBandMeter_6.sizeDelta = new Vector2(midBandMeter_6.sizeDelta.x, midQueue2);

        midBandMeter_4.sizeDelta = new Vector2(midBandMeter_4.sizeDelta.x, midQueue3);
        midBandMeter_7.sizeDelta = new Vector2(midBandMeter_7.sizeDelta.x, midQueue3);

        //highbands
        highBandMeter_2.sizeDelta = new Vector2(highBandMeter_2.sizeDelta.x, highQueueMain);
        highBandMeter_5.sizeDelta = new Vector2(highBandMeter_5.sizeDelta.x, highQueueMain);

        highBandMeter_3.sizeDelta = new Vector2(highBandMeter_3.sizeDelta.x, highQueue2);
        highBandMeter_6.sizeDelta = new Vector2(highBandMeter_6.sizeDelta.x, highQueue2);

        highBandMeter_4.sizeDelta = new Vector2(highBandMeter_4.sizeDelta.x, highQueue3);
        highBandMeter_7.sizeDelta = new Vector2(highBandMeter_7.sizeDelta.x, highQueue3);

        //vhighbands
        vhighBandMeter_2.sizeDelta = new Vector2(vhighBandMeter_2.sizeDelta.x, vhighQueueMain);
        vhighBandMeter_5.sizeDelta = new Vector2(vhighBandMeter_5.sizeDelta.x, vhighQueueMain);

        vhighBandMeter_3.sizeDelta = new Vector2(vhighBandMeter_3.sizeDelta.x, vhighQueue2);
        vhighBandMeter_6.sizeDelta = new Vector2(vhighBandMeter_6.sizeDelta.x, vhighQueue2);

        vhighBandMeter_4.sizeDelta = new Vector2(vhighBandMeter_4.sizeDelta.x, vhighQueue3);
        vhighBandMeter_7.sizeDelta = new Vector2(vhighBandMeter_7.sizeDelta.x, vhighQueue3);


    }

}
