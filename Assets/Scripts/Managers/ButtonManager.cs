using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonManager : MonoBehaviour 
{

	public void LoadScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
	/*public void LoadScene(string sceneName)
	{
		{
			SceneManager.LoadScene(sceneName);
		}
	}
	void Start()
	{
		StartCoroutine(LoadLevelAfterDelay());
	}
	
	IEnumerator LoadLevelAfterDelay()
	{
		yield return new WaitForSeconds(3);
		SceneManager.LoadScene(sceneName);		
	}*/

	public void Quit() {
		Debug.Log("QUIT!");
		Application.Quit();
	}


	public void ReloadScene() {
		
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
