using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour {

	private float timeBtwAttack;
	public float startTimeBtwAttack;

	public Transform attackPos;
	public LayerMask whatIsEnemies;
	public float attackRadius;
	public int damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if cooldown is done
		if (timeBtwAttack <= 0) {
			if (Input.GetMouseButtonDown (0)) {
				Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll (attackPos.position, attackRadius, whatIsEnemies);
				for (int i = 0; i < enemiesToDamage.Length; i++) {
					enemiesToDamage [i].GetComponent<Enemy> ().TakeDamage (damage);
				}
			}
			timeBtwAttack = startTimeBtwAttack;
		} else {
			timeBtwAttack -= startTimeBtwAttack;
		}
	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (attackPos.position, attackRadius);
	}
}
