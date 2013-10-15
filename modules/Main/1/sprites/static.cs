function Static::Setup(%this, %scene)
{
	%this.setBodyType(static);
	%this.createPolygonBoxCollisionShape(%this.collisionSize);
	
	if (%this.useRange == 0)
	   %this.useRange = (0.5 * %this.collisionSize.x) SPC (0.5 * %this.collisionSize.y);
	
	//	Setup Image to appear behind Character torso
	%this.addSprite();
	
	if (%this.animationName !$= "")
		%this.setSpriteAnimation(%this.animationName);
	else if (%this.imageName !$= "")
	{
		%this.setSpriteImage(%this.imageName);
		%this.setSpriteImageFrame(%this.imageFrame);
	}
		
	%this.setSpriteLocalPosition(%this.imagePos);
	%this.setSpriteSize(%this.imageSize);
	
	%scene.add(%this);
	addInteractionZone(%this, %scene);
}

function Static::Use(%this, %user)  {	/*echo("Static" SPC %this SPC "being used");*/ }
function Static::DisplayUse(%this)  {	/*return "Use" SPC %this.displayName @ ".";*/  }