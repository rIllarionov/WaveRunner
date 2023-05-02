using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] protected float _movingSpeed =  2f;
    protected float _currentTime;
    protected float _timeOfJorney;
    protected Transform _start;
    protected Transform _finish;


    protected void Start()
    {
        GetStartAndFinish();
        GetTimeJorney();
    }

    protected void Update()
    {
        _currentTime += Time.deltaTime;

        var progress = Mathf.PingPong(_currentTime,_timeOfJorney)/_timeOfJorney;
        var newPossition = 
            Vector3.Lerp(_start.position, 
                _finish.position, progress);
        transform.position = newPossition;
    }

    protected void GetStartAndFinish()
    {
        _start = new GameObject().transform;
        _finish = new GameObject().transform;
 
        var position = transform.position;
        
        _start.position = position - new Vector3(0,Random.Range(3,5),0);
        _finish.position = position + new Vector3(0,Random.Range(5,8),0);
    }
    
    protected void GetTimeJorney() 
    {
        var distance = Vector3.Distance(_start.position, 
            _finish.position);
        _timeOfJorney = distance / _movingSpeed;
    }
}
