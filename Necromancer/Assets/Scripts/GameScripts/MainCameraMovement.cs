using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMovement : MonoBehaviour
{
	[SerializeField]
	private Transform characterPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.position = new Vector3(
			characterPosition.position.x,
			transform.position.y,
			transform.position.z
			);
    }
}
