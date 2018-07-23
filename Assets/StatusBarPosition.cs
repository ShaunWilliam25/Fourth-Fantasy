using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBarPosition : MonoBehaviour {
    public float yOffset;
    public float xOffset;

	void Start () {
		this.transform.position = new Vector3(this.transform.parent.parent.position.x + xOffset, this.transform.parent.parent.position.y + yOffset, this.transform.parent.parent.position.z);
    }

	void Update () {
        
    }
}
