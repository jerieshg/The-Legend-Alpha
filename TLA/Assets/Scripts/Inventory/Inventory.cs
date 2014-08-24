using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	//Holding all of our items
	public Item[] items;

	//Inventory
	public List<Item> mainInventory;

	//Equipment Array 0=helm, 1=armor, 2=boots, 3=sword, 4=shield, 5=ring
	public Item[] equipment;

	//Player Reference
	private PlayerData playerData;

	void Start()
	{
		mainInventory = new List<Item>();
		playerData = GameObject.Find("_PlayerManager").GetComponent<PlayerData>();

		mainInventory.Add (items[0]);
		mainInventory.Add (items[1]);
	}

	void OnGUI()
	{
		for(int x = 0; x < mainInventory.Count; x++)
		{
			if(GUI.Button (new Rect(Screen.width/2,Screen.height/2 + (20 * x), 100, 20), mainInventory[x].name))
			{
				switch(mainInventory[x].type)
				{
				case Type.helmet:
					equipment[0] = mainInventory[x];
					playerData.strenght += equipment[0].defence;
					mainInventory.RemoveAt(x);
					break;
				case Type.armor:
					equipment[1] = mainInventory[x];
					playerData.strenght += equipment[1].defence;
					mainInventory.RemoveAt(x);
					break;
				case Type.boots:
					equipment[2] = mainInventory[x];
					playerData.strenght += equipment[2].defence;
					mainInventory.RemoveAt(x);
					break;
				case Type.sword:
					equipment[3] = mainInventory[x];
					playerData.strenght += equipment[3].str;
					mainInventory.RemoveAt(x);
					break;
				case Type.shield:
					equipment[4] = mainInventory[x];
					playerData.strenght += equipment[4].defence;
					mainInventory.RemoveAt(x);
					break;
				case Type.ring:
					equipment[5] = mainInventory[x];
					playerData.strenght += equipment[5].str;
					mainInventory.RemoveAt(x);
					break;
				}
			}
		}

		for(var y = 0; y < equipment.Length; y++)
		{
			if(equipment[y] != null)
			{
				if(GUI.Button(new Rect(Screen.width/2 - 150, Screen.height/2 + (20 * y), 100, 20), equipment[y].name))
				{
					if(equipment[y].name == "")
					{
						equipment[y] = null;
						Debug.Log("Nothing here");
					}

					//mainInventory.Add(equipment[y]);
					//playerData.strenght -= equipment[y].str;
					//equipment[y] = null;
				}
			}
		}
	}

}
