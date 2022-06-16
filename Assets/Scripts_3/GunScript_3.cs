using System.Collections;
using UnityEngine;


public class GunScript_3 : MonoBehaviour
{
	public enum eSTATE
	{
		Ready,	
		Empty,	
		Reloading
	}
	public eSTATE _eCurState {  get;	private set; }
	AudioSource _gunAudioPlayer;
	public AudioClip _shotClip;
	public AudioClip _reloadClip;
	public float _damage = 25f;
	public int _ammoRemain = 100;
	public int _magCapacity = 25;
	public int _magAmmo;
	public float _fireRate = 0.12f;
	public float _reloadTime = 1.8f;
	float _lastFireTime;
	
	private Vector3 aim;
	public GameObject FirePosition;
	public float _MaxRange = 15f;
	private RaycastHit hit;
	private void Awake()
	{
		_gunAudioPlayer = GetComponent<AudioSource>();
	}
	private void OnEnable()
	{
		_magAmmo = _magCapacity;
		_eCurState = eSTATE.Ready;
		_lastFireTime = 0f;

	}
	public void Fire()
	{
		if( _eCurState == eSTATE.Ready &&  
			Time.time >= _lastFireTime + _fireRate)      
		{
			_lastFireTime = Time.time;
			Shot();
		}
	}
	void Shot()
	{
		Vector3 hitPos = Vector3.zero;
		aim = FirePosition.transform.position;
		//aim.y += aimY;
		Debug.DrawRay(aim, transform.forward * _MaxRange, Color.red, 0.3f);
            
		if (Physics.Raycast(aim, transform.forward, out hit, _MaxRange))
		{
			if (hit.transform.GetComponent<MeshRenderer>() && hit.transform.GetComponent<CapsuleCollider>())
				hit.transform.GetComponent<MeshRenderer>().material.color = Color.red;
		}
		
		StartCoroutine( ShotEffect( hitPos ));
	}
	
	IEnumerator ShotEffect( Vector3 hitPos )
	{
		_gunAudioPlayer.PlayOneShot(_shotClip);

		yield return new WaitForSeconds(0.03f); 
	}

	public bool Reload()
	{
		if( _eCurState == eSTATE.Reloading ||
			_ammoRemain <= 0 ||					
			_magAmmo >= _magCapacity )			
			return false;

		//	재장전 진행..
		StartCoroutine( ReloadRoutine() );
		return true;
	}
	IEnumerator ReloadRoutine()
	{
		_eCurState = eSTATE.Reloading;
		_gunAudioPlayer.PlayOneShot( _reloadClip );
		yield return new WaitForSeconds( _reloadTime );
		int ammoToFill = _magCapacity - _magAmmo;
		if( _ammoRemain < ammoToFill )
			ammoToFill = _ammoRemain;
		_magAmmo += ammoToFill;
		_ammoRemain -= ammoToFill;
		_eCurState = eSTATE.Ready;

	}

}