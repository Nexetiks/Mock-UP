using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GMData {

	
	public List <float> points;


	public GMData (GameManager gm)
	{

		this.points = gm.scoreList;
	}
	
}
