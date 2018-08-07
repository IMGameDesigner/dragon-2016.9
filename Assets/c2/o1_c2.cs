using UnityEngine;
using System.Collections;

public class o1_c2 : MonoBehaviour {	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(manager.Instance.gettimer()%100==0)Destroy (this.gameObject);
	}

}



