using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour {
	public float moveSpeed = 1f;
	public float rotateSpeed = 50f;

	public Transform gun;//枪管头的位置
	public GameObject bulletPre;//子弹预设体

	public int health = 5;
	// Use this for initialization
	void Start () {

	}
	void Shoot()
	{
		if (!Input.GetKeyDown (KeyCode.Space))
			return;
		//创建子弹
		GameObject bullet = Instantiate (bulletPre,gun.position,gun.rotation) as GameObject;
		//发射子弹(给子弹施加力的作用)
		bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.TransformDirection(Vector3.forward)*50f,ForceMode.Impulse);

		bullet.GetComponent<BulletController> ().isEnemy = false;
			
	}
	// Update is called once per frame
	void Update () {
		MoveTank ();
		Shoot ();
	}

	void MoveTank()
	{

		float horizont = Input.GetAxis("Horizontal");//水平控制旋转
		float vertical = Input.GetAxis("Vertical");//竖直控制前进后退
		//旋转
		transform.Rotate (horizont*Vector3.up*rotateSpeed*Time.deltaTime,Space.World);
		//前进
		transform.Translate (vertical* Vector3.forward*moveSpeed*Time.deltaTime,Space.Self);
	}


}
