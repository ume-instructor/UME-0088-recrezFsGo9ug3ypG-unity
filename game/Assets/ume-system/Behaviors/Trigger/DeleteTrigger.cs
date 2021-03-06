using UnityEngine;
using UnityEngine.UI;
using System.Collections;


namespace UME
{
    [AddComponentMenu("UME/Triggers/DeleteTrigger")]
    public class DeleteTrigger : BaseTrigger {
		[Range(0f,1f)]
		public float delay = .5f;
		private Animator anim;
		private GameObject gobj;
		private Life life;


			
		public override void Activate(Collider2D other)
		{
			anim = other.gameObject.GetComponent<Animator> ();
			if (anim !=null  && anim.GetBool("Death") == false) {
				other.tag = "Ground";
				anim.SetTrigger ("Die");
				anim.SetBool ("Death", true);
				other.gameObject.AddComponent<Life> ();
				other.gameObject.GetComponent<Life> ().LifeSpan = delay;
				foreach(BaseTrigger trigger in other.gameObject.GetComponentsInChildren<BaseTrigger>(true) ){
					trigger.enabled = false;
				}
			} else {
				Destroy (other.gameObject);
			}

		}
	}
}