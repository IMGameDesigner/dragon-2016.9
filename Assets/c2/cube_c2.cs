using UnityEngine;
using System.Collections;

public class cube_c2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		if (other.tag.CompareTo ("o_tag") == 0) {
			manager.Instance.eat();

			int kk= Random.Range(100,1300);
			if(kk<400)this.transform.Translate(new Vector3(2,0,1));
			if(kk>=400&&kk<700)this.transform.Translate(new Vector3(-2,0,-1));
			if(kk>=700&&kk<1000)this.transform.Translate(new Vector3(-1,5,1));
			if(kk>=1000&&kk<1300)this.transform.Translate(new Vector3(1,-5,-1));
		}
	}
}
