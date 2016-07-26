using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class Arreglo : MonoBehaviour {


    //The array
	public GameObject[] objects ;

	//Reference to the first array position
	private GameObject firstObject; 

	//Reference to the button that adds an element
	public  Button addButton;

	//Reference to the button that removes an element
	public Button deleteButton;

	//Reference to the inputField
	public InputField inputField;

	//Reference to the default color (grey)
	private Color defaultColor; 

	//Reference to the button that initializes a fixed array of size 10
	public Button initialButton;

	//Referece to know the position where the array begins in 3D space
	Transform father;


	//int n =2;

	//Unity's Awake method that initializes references 
	void Awake()
	{
		firstObject = objects [0];
		father = firstObject.transform.parent;
		firstObject.SetActive (false);
	}

	// Unity's Start method
	void Start () 
	{

	}

	// Unity's Update method. Update is called once per frame
	void Update () 
	{

	}

	//Adds an element to the array
	public	void addToArray()
	{
		//Checks if there's an index parameter
		if (verifyInputField ()) 
		{
			indexToAdd ();
		}

		else
		{
			addNoIndex ();
		}
	}

	//Adds element to the index written in the inputField
	public void indexToAdd()
	{
			int number = int.Parse(inputField.textComponent.text);

			if (objects [number].GetComponent<MeshRenderer> ().material.color == Color.magenta) 
			{
				Debug.LogError ("There's already an object in pos: " + number);
			}

			objects [number].GetComponent<MeshRenderer> ().material.color = Color.magenta;
			clearInputField ();	
	}

	//Adds element after the last added object
	public void addNoIndex()
	{
		for (int i = 0; i < objects.Length; i++) 
		{
			bool isEmpty = checkColor (objects [i].GetComponent<MeshRenderer> ().material.color);

			if (isEmpty) 
			{
				objects [i].GetComponent<MeshRenderer> ().material.color = Color.magenta;
				break;
			}

			//Checks if the last element of the array is 'filled' with an object
			if (objects [objects.Length-1].GetComponent<MeshRenderer>().material.color ==Color.magenta ) 
			{
				reSizeArray();
				break;
			}
		}
	}

	//Checks if the current pos in the array is occupied.
	//If it has the default color it means it's not (true).
	public bool checkColor(Color actual)
	{
		if (actual == defaultColor) 
		{
			return true;
		}
		return false;
	}

	//Checks if there's an index value written in the input field 
	public bool verifyInputField()
	{
		if (inputField.textComponent.text.Length > 0) 
		{
			return true;
		}
		return false;
	}

	public void activateButtons()
	{
		createCubes ();
		addButton.gameObject.SetActive (true);
		deleteButton.gameObject.SetActive (true);
		inputField.gameObject.SetActive (true);
		initialButton.gameObject.SetActive (false);
	}

	public void createCubes()
	{
		firstObject.SetActive (true);
		float x = firstObject.transform.position.x;

		for (int i = 1; i < objects.Length; i++) 
		{
			objects [i] = Instantiate (firstObject);
			objects [i].transform.parent = father.transform;
			x++;
			x = x + 0.5f;
			objects [i].transform.position = new Vector3 (0.5f,0,x);

		}
		defaultColor = objects [0].GetComponent<MeshRenderer> ().material.color;
	}

	public void deleteFromArray()
	{
		if (verifyInputField ()) 
		{
			deleteIndex ();
		}

		else 
		{
			deleteNoIndex ();
		}
	}

	//Deletes element in the index written in the inputField
	public void deleteIndex()
	{
		int numero = int.Parse (inputField.textComponent.text);

		if (objects [numero].GetComponent<MeshRenderer> ().material.color == defaultColor) 
		{
			Debug.Log ("There's nothing to delete.");
		}

		objects [numero].GetComponent<MeshRenderer> ().material.color = defaultColor;
		clearInputField ();
	}

	//Deletes last object in the array
	public void deleteNoIndex()
	{
		for (int i = objects.Length - 1; i >= 0; i--) 
		{
			bool estaVacia = checkColor (objects [i].GetComponent<MeshRenderer> ().material.color);
			if (!estaVacia) 
			{
				objects [i].GetComponent<MeshRenderer> ().material.color =	defaultColor;
				break;
			}
		}
	}
		
	// Re-sizes the array to create space for more elements
	public void reSizeArray()
	{
		if (objects [objects.Length - 1].GetComponent<MeshRenderer> ().material.color == Color.magenta) 
		{
			//Temporal array
			GameObject[] temp = new GameObject[(objects.Length * 3) / 2];

			//Reference to the arrays
			int previousSize = objects.Length;

			for (int i = 0; i < objects.Length; i++) 
			{
				temp [i] = objects [i];
			}

			objects = temp;
			reCreateCubes (previousSize - 1);

		}
		
	}

	public void reCreateCubes( int y)
	{
		//Reference to the last (y) pos for z
		firstObject = objects [y];
		float x = firstObject.transform.position.z;
	
		for (int i = y+1; i < objects.Length; i++) 
		{
			objects [i] = Instantiate (firstObject); //
			objects [i].transform.parent = firstObject.transform.parent;
			x++;
			x = x + 0.5f;
			objects [i].transform.position = new Vector3 (0.5f,0,x);
			objects [i].GetComponent<MeshRenderer> ().material.color = Color.white;
		}

		reArrangeCamera();

	}


	//Adjusts camera to the size of the array
	public void reArrangeCamera()
	{
		Camera cam = Camera.main;
		Vector3 tempPos = cam.transform.position;
		tempPos.z = objects[objects.Length/2].transform.position.z;
		tempPos.x =  objects.Length/2 +10f;
		tempPos.y = tempPos.y + 0.35f;
		//n++;
		cam.transform.position = tempPos;
	}
		
	public void clearInputField()
	{
		inputField.GetComponent<InputField> ().text = "";
	}
		
}
