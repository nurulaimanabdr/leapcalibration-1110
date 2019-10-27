using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using System;
using Leap;



public class LeapMotionControllerCursorBehaviour : CursorPositioningController
{
    public CursorHandPosition handPosition;

    public LeapServiceProvider leapService;
    public GameObject leapMotionObjects;
    public HandModelManager leapHandModelManager;
    public Transform leapMotionOffset;
    public Hand hand;
    public Hand hand2;
    public LeapProvider provider;
    public delegate void Result(Vector3 Minimums, Vector3 Maximums);

    public float[] currentPosition;
    Controller controller;






    public int frameCount = 0;

    Vector3 lastCursorPosition;

    bool isCalibrating;
    Action finishCalibrationCallback;

    const float offsetPositionCalibrationStep = 0.001f;
    const float offsetAngleCalibrationStep = 0.5f;

    bool isTrackingHand;
    int detectedHandID;

    class SampleListener
    {
        public void OnServiceConnect(object sender, ConnectionEventArgs args)
        {
            UnityEngine.Debug.Log("Service Connected");
        }
        public void OnConnect(object sender, DeviceEventArgs args)
        {
            UnityEngine.Debug.Log("Connected");
        }
        public void OnFrame(object sender, FrameEventArgs args)
        {
            UnityEngine.Debug.Log("Frame Available.");
        }
    }

        public void OnFrame(object sender, FrameEventArgs args)
        {
            // Get the most recent frame and report some basic information
            Frame frame = args.frame;
           // Console.WriteLine(
          //    "Frame id: {0}, timestamp: {1}, hands: {2}",
           //   frame.Id, frame.Timestamp, frame.Hands.Count
          //  );
            //foreach (Hand hand in frame.Hands)
            //{
            //UnityEngine.Debug.Log("  Hand id: {0}, palm position: {1}, fingers: {2}"+
            //      hand.Id+ hand.PalmPosition+ hand.Fingers.Count);
                // Get the hand's normal vector and direction
             //   Vector normal = hand.PalmNormal;
             //   Vector direction = hand.Direction;
            // Calculate the hand's pitch, roll, and yaw angles
            //UnityEngine.Debug.Log(
             //     "  Hand pitch: {0} degrees, roll: {1} degrees, yaw: {2} degrees"+
             //     direction.Pitch * 180.0f / (float)Math.PI+
             //     normal.Roll * 180.0f / (float)Math.PI+
             //     direction.Yaw * 180.0f / (float)Math.PI
             //   );
            //}
        }

    void Start()
    {
        leapMotionOffset.localPosition = SharedData.calibrationData.leapMotionOffset;
        leapMotionOffset.localRotation = SharedData.calibrationData.leapMotionRotation;
    }

    private void Update()
    {
        Controller controller = new Controller();
        //SampleListener listener = new SampleListener();
        //controller.Connect += listener.OnServiceConnect;
        //controller.Device += listener.OnConnect;
        //controller.FrameReady += listener.OnFrame;



        Frame frame2 = controller.Frame();
            Frame previous = controller.Frame(1);
            UnityEngine.Debug.Log("(controller.IsConnected)");

            //Leap.Frame frame2 = leapService.CurrentFrame;
            // Frame frame2 = controller.Frame();
            if (frame2.Hands.Count > 0)
        {
            List<Hand> hand2 = frame2.Hands;
            Hand firstHand2 = hand2[0];
            UnityEngine.Debug.Log("Hand more than 0"+ frame2.Hands.Count);
            
            float handWidth2 = firstHand2.PalmWidth;

            UnityEngine.Debug.Log("Palm Width:" + handWidth2);
        }
        //if (frame2.Hands.Count > 0)
      // {
      //      Hand hand2 = frame2.Hands[1];
      //  }
        
        //UnityEngine.Debug.Log("Palm Width:gjghjgjhg");
        

        //Leap.Frame frame = leapService.CurrentFrame;
       
        //if (frame != null)
        //{
        //    isTrackingHand = frame.Hands.Count > 0;

        //    if (isTrackingHand)
        //    {
        //        if (handPosition == CursorHandPosition.HandTop)
        //        {
        //            lastCursorPosition = frame.Hands[0].GetIndex().TipPosition.ToVector3();
        //        }
        //        else
        //        {
        //            lastCursorPosition = frame.Hands[0].PalmPosition.ToVector3();
        //        }
        //        detectedHandID = frame.Hands[0].Id;
        //        //float handWidth = hand.PalmWidth;
        //        //UnityEngine.Debug.Log("Hand ID:" + detectedHandID + "Palm Width:" + hand.PalmWidth);
        //    }
        //    else
        //    {
        //        detectedHandID = -1;
        //    }
        //}
        //else
        //{
        //    isTrackingHand = false;
        //    detectedHandID = -1;
        //}

        //if (isCalibrating)
        //{
        //    Vector3 pos = leapMotionOffset.localPosition;
        //    Vector3 rotation = leapMotionOffset.localRotation.eulerAngles;
        //    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        //    {
        //        FinishCalibration();
        //    }
        //    else if (Input.GetKey(KeyCode.LeftArrow))
        //    {
        //        pos.x -= offsetPositionCalibrationStep;
        //    }
        //    else if (Input.GetKey(KeyCode.RightArrow))
        //    {
        //        pos.x += offsetPositionCalibrationStep;
        //    }
        //    else if (Input.GetKey(KeyCode.UpArrow))
        //    {
        //        pos.y += offsetPositionCalibrationStep;
        //    }
        //    else if (Input.GetKey(KeyCode.DownArrow))
        //    {
        //        pos.y -= offsetPositionCalibrationStep;
        //    }
        //    else if (Input.GetKey(KeyCode.W))
        //    {
        //        pos.z += offsetPositionCalibrationStep;
        //    }
        //    else if (Input.GetKey(KeyCode.S))
        //    {
        //        pos.z -= offsetPositionCalibrationStep;
        //    }
        //    else if (Input.GetKey(KeyCode.O))
        //    {
        //        leapMotionOffset.localRotation = Quaternion.Euler(new Vector3(rotation.x - offsetAngleCalibrationStep, rotation.y, rotation.z));
        //    }
        //    else if (Input.GetKey(KeyCode.L))
        //    {
        //        leapMotionOffset.localRotation = Quaternion.Euler(new Vector3(rotation.x + offsetAngleCalibrationStep, rotation.y, rotation.z));
        //    }
        //    leapMotionOffset.localPosition = pos;
        //}

        //if (frame.Hands.Count > 0)
        //{
        //    List<Hand> hands = frame.Hands;
        //    Hand firstHand = hands[0];

        //    //Debug.Log("foreach");
        //    //Debug.Break();
            
        //    frameCount = frameCount++;
        //    currentPosition = new float[3]; //create array for x,y,z coordinates
        //    currentPosition = firstHand.PalmPosition.ToFloatArray(); //move coordinates to the current postion

        //    float palmWidth = currentPosition[0]; // get the width, or X for the current position
        //    float palmDepth = currentPosition[2]; // get the depth, or Z for the current postition
        //    //UnityEngine.Debug.Log("Palm Width:" + palmWidth + "| Palm Depth:" + palmDepth);
        //    //float handWidth = hand.PalmWidth;
        //    //UnityEngine.Debug.Log("Hand ID:" + detectedHandID + "Palm Width:" + hand.PalmWidth);

        //}

        

    }

    private void OnEnable()
    {
        // Enable LeapMotion related services
        leapService.enabled = true;
        leapMotionObjects.SetActive(true);
    }

    private void OnDisable()
    {
        // Disable LeapMotion related services
        leapService.enabled = false;
        leapMotionObjects.SetActive(false);
    }

    public override string GetDeviceName()
    {
        return "LeapMotionController";
    }

    public override Vector3 GetCurrentCursorPosition()
    {
        return lastCursorPosition;
    }

    public override int GetTrackedHandId()
    {
        return detectedHandID;
    }

    public void StartLeapMotionCalibration(Action callback)
    {
        Debug.Log("LeapMotionControllerCursorBehaviour: calibrating...");
        isCalibrating = true;
        finishCalibrationCallback = callback;
        leapHandModelManager.EnableGroup("Rigged Hands");
    }

    void FinishCalibration()
    {
        SharedData.calibrationData.leapMotionOffset = leapMotionOffset.localPosition;
        SharedData.calibrationData.leapMotionRotation = leapMotionOffset.localRotation;
        SharedData.calibrationData.SaveToFile();

        isCalibrating = false;

        leapHandModelManager.DisableGroup("Rigged Hands");
        StartCoroutine(ExecuteAfterTime(() => {
            finishCalibrationCallback?.Invoke();
            finishCalibrationCallback = null;
            Debug.Log("LeapMotionControllerCursorBehaviour: finished calibration.");
        }, 1)); // avoid bug when trying to disable hands group in leap motion
    }

    IEnumerator ExecuteAfterTime(System.Action action, float timeInSeconds)
    {
        yield return new WaitForSeconds(timeInSeconds);
        action?.Invoke();
    }
}
