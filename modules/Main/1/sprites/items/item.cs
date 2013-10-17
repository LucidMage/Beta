function Item::onRemoveFromScene(%this)
{
   removeInteractionZone(%this);
}

function Item::Setup(%this, %scene)
{
	//error("Item setup");
		
	%this.setBodyType(dynamic);
	%this.createPolygonBoxCollisionShape(%this.collisionSize);
	
	%this.setDefaultDensity(1000);   // Made ridiculously high so characters will not budge
	%this.setDefaultRestitution(0.25);	//	Bounciness
	%this.setDefaultFriction(0);
	%this.setLinearDamping(1);	//	How quickly it slows down

	%this.setCollisionCallback(true);   // So onCollision will be called
	%this.setFixedAngle(true); // Stop from rotating on collision
	
	if (%this.useRange == 0)
	   %this.useRange = %this.collisionSize.x;//.5;	// How close does something have to be for the character to use it
	
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
   if (Inventory.AddItem(%this))
      %this.removeFromScene();
   else
      warn("Cannot add item, either because onPickUp returned false or the class != Item");
}

function Item::DisplayUse(%this) {	return "Pick up" SPC %this.displayName @ ".";   }

//	Callback when item is added to inventory. True = item is added as normal
function Item::onPickUp(%this)   {	return true;   }