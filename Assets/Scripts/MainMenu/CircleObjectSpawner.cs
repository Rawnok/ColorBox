﻿using UnityEngine;
using System.Collections;

public class CircleObjectSpawner : MonoBehaviour {

	[SerializeField]
	private CircleBoxPieces circleBoxPiece;
	
	void Start(){
		Explode();
		StopCoroutine("GenerateCircleObjects");
		StartCoroutine("GenerateCircleObjects");
	}//awake
	
	IEnumerator GenerateCircleObjects(){
		yield return new WaitForSeconds(2f);
		if ( Application.loadedLevelName == AllScenes.MAIN_MENU_SCENE ){
			Explode();
			StartCoroutine("GenerateCircleObjects");
		}
	}//generateCircleObjects
	
	void Explode(){
		Box.colorCode = AllColors.GET_RANDOM_COLOR_STRING();
		var trans = gameObject.transform;
		for(int i=0;i<12; i++){
			var temp = trans.position;
			temp.x += (10f * Random.Range(-10,10));
			temp.y += (5f * Random.Range(-10,10));
			CircleBoxPieces clone = Instantiate(circleBoxPiece,temp,Quaternion.identity) as CircleBoxPieces;
			// adding force to sideways
			clone.GetComponent<Rigidbody2D>().AddForce(Vector3.right * Random.Range(-10,10) * 500);
			//adding force to up
			clone.GetComponent<Rigidbody2D>().AddForce(Vector3.up * Random.Range(-10,-1) * 600);
		}//loop of explode
	}//explode
}
