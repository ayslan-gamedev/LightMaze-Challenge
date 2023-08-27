using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class testMonoScript : MonoBehaviour
{
    [SerializeField] private UnityEvent @event;

    // Start is called before the first frame update
    void Start()
    {
        @event.Invoke();
    }

}
