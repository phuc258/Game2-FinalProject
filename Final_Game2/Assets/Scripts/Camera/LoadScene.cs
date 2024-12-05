using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
   [SerializeField] public float loadSceneDelay;
   [SerializeField] public string loadSceneName;

   void onTriggerEnter2D(Collider2D collision)
   {
      if (collision.gameObject.tag == "Player")
      {
         collision.gameObject.SetActive(false);

         ModeSelect();
      }
   }

   public void ModeSelect()
   {
      StartCoroutine(LoadAfterDelay());
   }

   IEnumerator LoadAfterDelay()
   {
      yield return new WaitForSeconds(loadSceneDelay);
      
      SceneManager.LoadScene(loadSceneName);
   }
}
