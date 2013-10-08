function Static::Setup(%this, %scene)
{
	error("Static setup");
	%this.setBodyType(static);
	%this.createPolygonBoxCollisionShape(%this.collisionSize);
	
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
}

function Static::Use(%this, %user)
{
	echo("Static" SPC %this SPC "being used");
}

function Static::DisplayUse()
{
	return "Use" SPC %this.displayName @ ".";
}