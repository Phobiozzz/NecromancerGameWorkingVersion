using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

	private float length;
	private float startPosition;

	[SerializeField]
	private GameObject mainCamera;
	[SerializeField]
	private float parallaxEffect;


    // Start is called before the first frame update
    void Start()
    {
		startPosition = transform.position.x;
		length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		float temp = (mainCamera.transform.position.x * (1 - parallaxEffect));
		float distance =(mainCamera.transform.position.x * parallaxEffect);

		transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);

		if (temp > startPosition + length)
		{
			startPosition += length;
		}
		else if (temp < startPosition - length)
		{
			startPosition -= length;
		}
    }
}
