using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class FireProjectile : MonoBehaviour {
	public float speed = 5f;
	public GameObject projectile;
	public Transform spawn;
 
	public static event Action GunFired;

	public void Fire() {
		GetComponent<AudioSource>().Play();
		GameObject spawnedBullet = Instantiate(projectile, spawn.position, spawn.rotation);
		spawnedBullet.GetComponent<Rigidbody>().velocity = speed * spawn.forward;
		Destroy(spawnedBullet, 5f);
		GunFired?.Invoke();
	}
}