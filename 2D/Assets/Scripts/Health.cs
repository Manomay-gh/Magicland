using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Health : MonoBehaviour {
	
	public enum deathAction {loadLevelWhenDead,doNothingWhenDead};

	public static float healthPoints= 100f;
	public float respawnHealthPoints = 1f; //base health points
	
	public int numberOfLives = 1;					//lives and variables for respawning
	public bool isAlive = true;	

	public GameObject explosionPrefab;
	
	public deathAction onLivesGone = deathAction.doNothingWhenDead;
	
	public string LevelToLoad = "";
	
	private Vector3 respawnPosition;
	private Quaternion respawnRotation;
	

	

	
	

	// Use this for initialization
	void Start () 
	{
		
		healthPoints = 100f;


		// store initial position as respawn location
		respawnPosition = transform.position;
		respawnRotation = transform.rotation;
		
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (healthPoints <= 0) {				// if the object is 'dead'
			numberOfLives--;                    // decrement # of lives, update lives GUI

			

			if (numberOfLives > 0) { // respawn
				transform.position = respawnPosition;	// reset the player to respawn position
				transform.rotation = respawnRotation;
				healthPoints = respawnHealthPoints;	// give the player full health again
			} else { // here is where you do stuff once ALL lives are gone)
				isAlive = false;

				Instantiate(explosionPrefab, transform.position, Quaternion.identity);

				Destroy(gameObject);
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


			}

			

		}
	}
	
	public void ApplyDamage(float amount)
	{	
		healthPoints = healthPoints - amount;
		

	}
	
	public void ApplyHeal(float amount)
	{
		healthPoints = healthPoints + amount;
	}

	public void ApplyBonusLife(int amount)
	{
		numberOfLives = numberOfLives + amount;
	}
	
	public void updateRespawn(Vector3 newRespawnPosition, Quaternion newRespawnRotation) {
		respawnPosition = newRespawnPosition;
		respawnRotation = newRespawnRotation;
	}
	
}
