/*function Item::onAdd(%this)
{
	echo("Item onAdd");
	
	%this.interactionZone = new Trigger()
	{
		class = InteractionZone;
		Position = %this.getPosition();
		SceneLayer = %this.getSceneLayer();
	};
	echo(%this.collisionSize);
	%radius = %this.collisionSize.x * 2;
	%this.interactionZone.createCircleCollisionShape(%radius);
	
	%scene = %this.getScene();
	%scene.add(%this.interactionZone);
	%this.interactionJoin = %scene.createWeldJoint(%this, %this.interactionZone, "0 0", "0 0", 0, 0, false);
}*/

function Item::onRemoveFromScene(%this)
{
   removeInteractionZone(%this);
}

function Item::Setup(%this, %scene)
{
	error("Item setup");
		
	%this.setBodyType(static);
	%this.createPolygonBoxCollisionShape(%this.collisionSize);
	
	if (%this.useRange == 0)
	   %this.useRange = (0.5 * %this.collisionSize.x);//.5;	// How close does something have to be for the character to use it
	
	//	Setup Image to appear behind Character torso
	%this.addSprite();
	
	if (%this.animationName !$= "")
		%this.setSpriteAnimation(%this.animationName);
	else if (%this.imageName !$= "")
		%this.setSpriteImage(%this.imageName);
		
	%this.setSpriteLocalPosition(%this.imagePos);
	%this.setSpriteSize(%this.imageSize);
	
	%scene.add(%this);
	addInteractionZone(%this, %scene);
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

//	Callback when item is added to inventory. True = item is added as normal
function Item::onPickUp(%this)
{
	return true;
}