using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

	public Button botonB;
	public Button botonBO;
	public InputField inputRoot;
	public Arbol tree;
	public string valorRaiz;
	public Button addBtn;
	public Button removeBtn;

	private bool binaryOnly = false;
	// Update is called once per frame



	public void buttonPressed()
	{
		activateInputRoot ();
		deActivateBoButton ();
		deActivateBButton();

	
	
		Debug.Log (binaryOnly);
	}

	public void activateInputRoot()
	{
		if (inputRoot.gameObject.activeSelf == false) {
			inputRoot.gameObject.SetActive (true);

		}
	}


	public void pressbButton()
	{
		binaryOnly = true;
	}

	public void pressbOButton()
	{
		binaryOnly = false;
	}

	public void crearArbol()
	{
		valorRaiz = inputRoot.GetComponent<InputField> ().text;
	    tree.newArbol (int.Parse(valorRaiz));
		inputRoot.GetComponent<InputField> ().text = "";
		inputRoot.placeholder.GetComponent<Text>().text = "Type value of the node you want to add";
		inputRoot.GetComponent<RectTransform>().Translate (new Vector3 (0, 10, 0));
		triggerRemoveButton ();
		triggerAddButton ();

	}
		

	public void deActivateBoButton()
	{
		botonBO.gameObject.SetActive (false);
	}

	private void deActivateBButton()
	{
		botonB.gameObject.SetActive (false);
	}

	private void triggerAddButton()
	{
		if (addBtn.gameObject.activeSelf == false) 
		{
			addBtn.gameObject.SetActive (true);
		}

		else 
		{
			addBtn.gameObject.SetActive (false);
		}
	}

	private void triggerRemoveButton()
	{
		if (removeBtn.gameObject.activeSelf == false) 
		{
			removeBtn.gameObject.SetActive (true);
		}

		else 
		{
			removeBtn.gameObject.SetActive (false);
		}
	}

	public void addNode(int valorr)
	{
		if (binaryOnly == true) 
		{
			tree.crearNodoIzquierdo ( valorr);
		} 

		else 
		{

		}
	}

}
