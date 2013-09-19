function Item::setup(%this)
{
   %this.setBodyType(static);
   %this.createPolygonBoxCollisionShape(0.5, 0.5);
}

function Item::Use(%this, %user)
{
   echo("Item" SPC %this SPC "is being used");
   Inventory.AddItem(%this);
   %this.removeFromScene();
}

function Item::DisplayUse()
{
	return "Pick up" SPC %this.displayName @ ".";
}