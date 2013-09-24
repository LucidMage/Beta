function Item::Setup(%this)
{
	error("Item setup");
		
	%this.setBodyType(static);
	%this.createPolygonBoxCollisionShape(%this.collisionSize);
	
	//	Setup Image to appear behind Character torso
	%this.addSprite();
	
	if (%this.animationName !$= "")
		%this.setSpriteAnimation(%this.animationName);
	else if (%this.imageName !$= "")
		%this.setSpriteImage(%this.imageName);
		
	%this.setSpriteLocalPosition(%this.imagePos);
	%this.setSpriteSize(%this.imageSize);
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