using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private AnimationCurve transition;
    [SerializeField] private Vector3 destiny;
    [SerializeField] private float speed;
    [SerializeField] private float _distance;
    [SerializeField] private float _size;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Inicio");

        Vector3.MoveTowards(transform.position, destiny, Time.deltaTime * speed);

        _distance = Vector3.Distance(transform.position, destiny);
    }

    // Update is called once per frame
    void Update()
    {
        float normalized = Vector3.Distance(transform.position, destiny) / _distance;
        Debug.Log($"{normalized}:{normalized}");
        transform.position = Vector3.MoveTowards(transform.position, destiny, Time.deltaTime * speed); //posicion actual

        transform.localScale = Vector3.one + Vector3.one * transition.Evaluate(normalized);
    }
}
