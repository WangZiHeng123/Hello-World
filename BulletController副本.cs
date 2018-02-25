using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
	private GameObject score;
	private Score scoreScript;

	private GameObject tank;
	private TankController tc;

	public bool isEnemy = false;

	//子弹爆炸的预设体:
	public GameObject zidanBaozha;

	// Use this for initialization
	void Start () {
		score = GameObject.Find ("Score");
  		scoreScript = score.GetComponent<Score> ();
		tank = GameObject.Find ("Tank");
		tc  = tank.GetComponent<TankController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		Destroy (this.gameObject);

		if (other.name.Equals ("Tank") && isEnemy) {
			tc.health -=1;
		}
		if (other.name.Equals ("Tank Enemy")&& !isEnemy) {
			scoreScript.score += 1;
			Destroy(other.gameObject);
		}
//		tc.health -=1;
	}

	void OnDestroy()
	{
		//播放特效
		GameObject ZiDanBaoZha = Instantiate (zidanBaozha,gameObject.transform.position,gameObject.transform.rotation);
		ZiDanBaoZha.GetComponent<ParticleSystem> ().Play ();
	}

}
