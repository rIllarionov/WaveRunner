using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMover : MonoBehaviour
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
            Vector3.Lerp(_start.position, 
                _finish.position, progress);
        transform.position = newPossition;
    }

    private void GetStartAndFinish()
    {
        _start = new GameObject().transform;
        _finish = new GameObject().transform;
 
        var position = transform.position;
        
        _start.position = position - new Vector3(Random.Range(0,5),0,0);
        _finish.position = position + new Vector3(Random.Range(5,8),0,0);
    }
    
    private void GetTimeJorney() 
    {
        var distance = Vector3.Distance(_start.position, 
            _finish.position);
        _timeOfJorney = distance / _movingSpeed;
    }

}
