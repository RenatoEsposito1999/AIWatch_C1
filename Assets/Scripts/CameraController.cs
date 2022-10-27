using UnityEngine;
using System.Collections.Generic;

public static class CameraController
{
    private static Queue<Camera> _myQueue = new Queue<Camera>();
    public static Camera _currentCam = null;

    //init is called by playerMoviment
    public static void init()
    {
        //Find all camera object by tag
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Camera");
        if (_currentCam == null)
        {
            _currentCam = obj[0].GetComponent<Camera>();
            _currentCam.enabled = true;
        }
        foreach (GameObject tmp in obj)
            _myQueue.Enqueue(tmp.GetComponent<Camera>());
    }

    public static void changeCamera()
    {
        if (_currentCam != null)
            _currentCam.enabled = false;
        _currentCam = _myQueue.Dequeue();
        _currentCam.enabled = true;
        _myQueue.Enqueue(_currentCam);
    }

}