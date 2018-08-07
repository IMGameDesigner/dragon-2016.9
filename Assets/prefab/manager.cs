using UnityEngine;
using System.Collections;

public class manager : MonoBehaviour {
	Transform m_camTransform;
	
	public Transform oo;
	public static manager Instance;
	protected Transform m_transform;
	int tip,direction,direction2,caneating,life;
	int[] ax=new int[1000000];
	int[] ay=new int[1000000];
	int[] az=new int[1000000];
	int timer=0;
	// Use this for initialization
	void Start () {
		// 获取摄像机
		m_camTransform = Camera.main.transform;
		m_transform = this.transform;
		Instance = this;

		Application.targetFrameRate = 200;//Edit/Project Settings/Quality VSync dont越小越慢,必须所有的cs文件这个值相同，或只有一个文件写

	}
	

	void Update () {
		timer++;
		if (timer > 1000000)
						timer = 0;
		//玩家的输入来改变方向
		if(timer%20==0){//20是经过测试的
		if (Input.GetKey (KeyCode.UpArrow)) {tchange ();
			if(direction==1)direction=3;
			else
				if(direction==2)direction=3;
			else
				if(direction==3)direction=3;
			else
				if(direction==4)direction=1;
			else
				if(direction==5)direction=3;
			else
				if(direction==6)direction=3;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {tchange ();
			if(direction==1)direction=4;
			else
				if(direction==2)direction=4;
			else
				if(direction==3)direction=1;
			else
				if(direction==4)direction=4;
			else
				if(direction==5)direction=4;
			else
				if(direction==6)direction=4;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {tchange ();
			if(direction==1)direction=5;
			else
				if(direction==2)direction=6;
			else
				if(direction==3)direction=3;
			else
				if(direction==4)direction=4;
			else
				if(direction==5)direction=2;
			else
				if(direction==6)direction=1;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {tchange ();
			if(direction==1)direction=6;
			else
				if(direction==2)direction=5;
			else
				if(direction==3)direction=3;
			else
				if(direction==4)direction=4;
			else
				if(direction==5)direction=1;
			else
				if(direction==6)direction=2;
		}
		}
		if(timer%100==0)tchange ();
		}
	void tchange(){
		//确定摄像机方向:m_camRot.y = 90;表示y轴指向我，y为轴顺时针旋转90度
		Vector3 m_camRot;
		m_camRot.x = 0;
		m_camRot.y = 0;
		m_camRot.z = 0;
		if (direction == 1)m_camRot.y = 90;
		if (direction == 2)m_camRot.y = -90;
		if (direction == 3)m_camRot.x = -90;
		if (direction == 4)m_camRot.x = 90;
		if (direction == 5)m_camRot.z = 0;
		if (direction == 6)m_camRot.y = 180;

		m_camTransform.eulerAngles = m_camRot;

		//摄像机的位置跟随
		Vector3 pos = m_transform.position;
		pos.y =ay[1];pos.x = ax [1];pos.z = az [1];
		m_camTransform.position = pos;

		int i,j;
		if(life==1){
		//判断是否自己撞自己死亡
			for(i=1;i<=tip-1;i++)
				for(j=i+1;j<=tip;j++)
					if(ax[i]==ax[j]&&ay[i]==ay[j]&&az[i]==az[j])life=0;
		
		
		//把头后的整体更新
		if (caneating == 0)
			for (i=tip-1; i>=1; i--) {
								ax [i + 1] = ax [i];
								ay [i + 1] = ay [i];
								az [i + 1] = az [i];
						}
				else {
			caneating=0;
			tip++;
			for (i=tip-1; i>=1; i--) {
				ax [i + 1] = ax [i];
				ay [i + 1] = ay [i];
				az [i + 1] = az [i];
			}
				}
		//根据方向更新头
		if(direction==1)
		{
			ax[1]=ax[1]+1;
			ay[1]=ay[1];
			az[1]=az[1];
		}
		if(direction==2)
		{
			ax[1]=ax[1]-1;
			ay[1]=ay[1];
			az[1]=az[1];
		}
		if(direction==3)
		{
			ax[1]=ax[1];
			ay[1]=ay[1]+1;
			az[1]=az[1];
		}
		if(direction==4)
		{
			ax[1]=ax[1];
			ay[1]=ay[1]-1;
			az[1]=az[1];
		}
		if(direction==5)
		{
			ax[1]=ax[1];
			ay[1]=ay[1];
			az[1]=az[1]+1;
		}
		if(direction==6)
		{
			ax[1]=ax[1];
			ay[1]=ay[1];
			az[1]=az[1]-1;
		}
		//数据层变成显示层
		for(i=1;i<=tip;i++)Instantiate (oo,new Vector3(ax[i],ay[i],az[i]),m_transform.rotation);
		}
	}

	void OnGUI(){
		if (GUI.Button(new Rect(10,10,100,30),"退出")) {
			Application.Quit ();	
		}
		if (GUI.Button(new Rect(10,50,100,30),"重新开始")) {
			life=1;
			tip = 2;
			direction = 1;direction2=1;
			ax [1] = 1;ay [1] = 50;az [1] = 1;
			ax [2] = 1;ay [2] = 50;az [2] = 2;
			caneating = 0;
		}
		GUI.Label (new Rect (500, 5, 500, 130), "长度" + tip);
		GUI.skin.label.fontSize = 40;

	}
	public void eat(){
		caneating = 1;
	}
	public void dead(){
		life = 0;
	}
	public int gettimer(){
		return timer;
	}
}
