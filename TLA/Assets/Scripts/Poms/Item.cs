using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item{

	public string name;
	public string desc;
	public float str;
	public float defence;
	public float magic;
	public float WeaponAR;
	public Rarity rarity;
	public Type type;
	public bool empty = false;
	public Sprite itemModel;
	public Texture2D itemIcon;
}

public enum Rarity
{
	uncommon,
	common,
	rare,
	epic
}

public enum Type
{
	helmet,
	sword,
	armor,
	boots,
	ring,
	shield
}
