using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChanger : MonoBehaviour
{
    [SerializeField] private float _movingSpeed =  2f;
    private float _currentTime;
    private float _timeOfJorney;
    private Transform _start;
    private Transform _finish;


    private void Start()
    {
        GetStartAndFinish();
        GetTimeJorney();
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        var progress = Mathf.PingPong(_currentTime,_timeOfJorney)/_timeOfJorney;
        var newPossition = 
            Vector3.Lerp(_start.localScale, 
                _finish.localScale, progress);
        transform.localScale = newPossition;
    }

    private void GetStartAndFinish()
    {
        _start = new GameObject().transform;
        _finish = new GameObject().transform;

        _start.localScale = new Vector3(0,0,0);
        _finish.localScale = new Vector3(2,2,1);
    }
    
    private void GetTimeJorney() 
    {
        var distance = Vector3.Distance(_start.localScale, 
            _finish.localScale);
        _timeOfJorney = distance / _movingSpeed;
    }
}
