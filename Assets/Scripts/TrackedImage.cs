using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;

public class TrackedImage : MonoBehaviour
{
    [SerializeField] private GameObject _spawnableObjectPrefab;
    [SerializeField] private ARTrackedImage _trackedImage;

    private GameObject _spawnedObject;

    void Start()
    {
        Object.FindObjectOfType<ScoreDisplay>().AddPoint();
    }

    void Update()
    {
        Object.FindObjectOfType<ScoreDisplay>().AddPoint($"{_trackedImage.trackingState}");
        if (_spawnedObject != null)
            return;

        if (_trackedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
        {
            _spawnedObject = Instantiate(_spawnableObjectPrefab);
            _spawnedObject.transform.position = this.transform.position;
        }
    }

    private bool WasTapped()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return true;
        }

        if (Input.touchCount == 0)
        {
            return false;
        }

        var touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began)
        {
            return false;
        }

        return true;
    }
}
