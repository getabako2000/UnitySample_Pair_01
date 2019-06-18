using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviourScript : MonoBehaviour
{

    private bool _move = false;

    public float _R = 2;    // 半径[m]
    public float _T = 5;    // 周期[min]

    // Start is called before the first frame update
    void Start()
    {
        _move = true;

        StartCoroutine(MoveCube());

    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.S))
        {
            if (!_move)
            {
                _move = true;

                StartCoroutine(MoveCube());
            }
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            _move = false;

            StopCoroutine(MoveCube());
        }
    }

    IEnumerator MoveCube()
    {
        Vector3 pos = new Vector3();

        pos.y = this.transform.position.y;

        float t = 0;

        while (_move)
        {

            float w = t * 360 / _T;

            pos.x = _R * Mathf.Cos(w * Mathf.Deg2Rad);
            pos.z = _R * Mathf.Sin(w * Mathf.Deg2Rad);

            this.transform.position = pos;

            t += Time.deltaTime;

            yield return null;
        }
    }
}
