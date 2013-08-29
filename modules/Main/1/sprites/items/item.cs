function Item::onAdd(%this)
{
   %this.SceneLayer = 14;
   %this.Size = 0.75;
   
   %this.setBodyType(static);
   
   //%this.createCircleCollisionShape(0.25);
   %this.createPolygonBoxCollisionShape(0.5, 0.5);
   
   %this.setCollisionCallback(true);
   //%this.setFixedAngle(true);
}

function Item::Use(%this, %user)
{
   echo("Item made contact with user");
   Inventory.AddItem(%this);
   %this.removeFromScene();
}

function Item::DisplayUse()
{
	return "Pick up" SPC %this @ ".";
}