using UnityEngine;

namespace OccaSoftware.LCD.Demo
{
	[ExecuteAlways]
	public class AutoPlayVideo : MonoBehaviour
	{
		public UnityEngine.Video.VideoPlayer player;

		private void OnEnable()
		{
			player.Play();
		}
	}
}
