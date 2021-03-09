using UnityEngine;
using System.Collections;

public class CubeFun : MonoBehaviour {

	private Vector3 _startPosition;
	float y;

	void Start ()
    {
		y = Random.Range(.0f, .04f);
	}
	void Update () 
	{
		var rand = Random.Range(Mathf.Sin(Time.time), Mathf.Sin(Time.time * 5));
		_startPosition = transform.position;
		transform.position = _startPosition + new Vector3(Mathf.Sin(Time.time) * y, rand * y, Mathf.Sin(Time.time) * y);

		transform.Rotate(Vector3.right);
	}
}
