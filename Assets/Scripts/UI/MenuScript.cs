using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
	public class MenuScript : MonoBehaviour
	{
		public void triggerMenu(int trigger)
		{
			switch (trigger)
			{
				case (0):
					SceneManager.LoadScene("gameScene");
					break;
				case (1):
					Application.Quit();
					break;
			}
		}
	}
}
