﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherLSystem : MonoBehaviour
{
    private string axiom = "FX";
    private float angle;
    private string currentString;
    private Dictionary<char, string> rules = new Dictionary<char, string>();
    private Stack<TransformInfo> transformStack = new Stack<TransformInfo>();

    private float length;
    private bool isGenerating = false;

    // Start is called before the first frame update
    void Start()
    {
	rules.Add('X', "X+YF-[XF+Y]");
	rules.Add('Y', "-FX-Y+[YF-X]");
	currentString = axiom;
	angle = 90f;
	length = 30f;
	StartCoroutine (GenerateLSystem ());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GenerateLSystem() {
	int count = 0;
	while (count < 5) {
	    if (!isGenerating) {
		isGenerating = true;
		StartCoroutine(Generate());
	    } else {
		yield return new WaitForSeconds(0.1f);
	    }
	}
    }

    IEnumerator Generate()
    {
	length = length / 2;
	string newString = "";
	char[] stringCharacters = currentString.ToCharArray();

	for (int i = 0; i < stringCharacters.Length; i++) {
	    char currentCharacter = stringCharacters[i];
	    if(rules.ContainsKey(currentCharacter)) {
	    	newString += rules[currentCharacter];
	    } else {
		newString += currentCharacter.ToString();
	    }
	}
	currentString = newString;
	Debug.Log(currentString);
	
	stringCharacters = currentString.ToCharArray();
	for (int i = 0; i < stringCharacters.Length; i++) {
	    char currentCharacter = stringCharacters[i];
	    if (currentCharacter == 'F') {
		Vector3 initialPosition = transform.position;
		transform.Translate(Vector3.up * length);
		Debug.DrawLine(initialPosition, transform.position, Color.white, 10000f, false);
		yield return null;
	    } else if (currentCharacter == '+') {
		transform.Rotate(Vector3.forward * angle);
	    } else if (currentCharacter == '-') {
		transform.Rotate(Vector3.forward * -angle);
	    } else if (currentCharacter == '[') {
		TransformInfo ti = new TransformInfo();
		ti.position = transform.position;
		ti.rotation = transform.rotation;
		transformStack.Push(ti);
	    } else if (currentCharacter == ']') {
		TransformInfo ti = transformStack.Pop();
		transform.position = ti.position;
		transform.rotation = ti.rotation;
	    }
	}
	isGenerating = false;
    }
}
