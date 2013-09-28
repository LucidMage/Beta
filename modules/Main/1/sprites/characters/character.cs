function Character::onRemoveFromScene(%this)
{
	%this.interactionZone.delete();
}

function SetupCharacter(%character)
{
	%character.damping = 20;
	%character.direction = $SpriteDirectionDown;   // The direction they are facing. Used for determining image
	%character.speed = 4;
	%character.state = $SpriteStateIdle;	// What the sprite is doing. Used for determining image
	%character.positionAdjust = "0 -0.5";
	%character.collisionSize = "0.6 0.8";
	%character.useRange = 1.5;	// How close does something have to be for the character to use it

	%character.setBodyType(dynamic);

	// This effects how characters collide
	%character.setDefaultDensity(1000000);   // Made ridiculously high so characters will not budge
	%character.setDefaultRestitution(0);	//	Bounciness
	%character.setDefaultFriction(0);
	%character.setLinearDamping(%character.damping);	//	How quickly it slows down

	// Collision Circle, if size not set = size of image
	// (radius, [relative xPos, relative yPos])
	%character.createPolygonBoxCollisionShape(%character.collisionSize.x, %character.collisionSize.y, %character.positionAdjust.x, %character.positionAdjust.y);

	%character.setCollisionCallback(true);   // So onCollision will be called
	%character.setFixedAngle(true); // Stop from rotating on collision
	
	//	Dialogue Tree
	/*%character.dialogueTree = new ScriptObject()
	{
		class = DialogueTree;
	};*/
	%character.dialogueTree.Setup(%character);
}

function Character::Setup(%this, %scene)
{
	echo("Character Setup");
	SetupCharacter(%this);
	
	// Sprites, or graphics, the character is composed of
	%this.addSprite();
	%this.setSpriteName("legs");
	%this.setSpriteSize(2);
	
	%this.addSprite();
	%this.setSpriteName("torso");
	%this.setSpriteSize(2);
	
	%this.addSprite();
	%this.setSpriteName("head");
	%this.setSpriteSize(2);
	
	%this.addSprite();
	%this.setSpriteName("accessory");
	%this.setSpriteSize(2);
	
	%this.UpdateImages();
	
	%scene.add(%this);
	addInteractionZone(%this, %scene);
	echo("End of Character Setup");
}

// Change the images to match the current state
function Character::UpdateImages(%this)
{
	echo("Gender:" SPC %this.gender);
	echo("Ethnicity:" SPC %this.ethnicity);
	echo("State:" SPC %state);
	echo("Hair Colour:" SPC %this.hairColour);
	echo("Hair Style:" SPC %this.hairStyle);
	echo("Torso:" SPC %this.torso);
	echo("Legs:" SPC %this.legs);
	echo("Accessory:" SPC %this.accessory);
	
	//	Accessory
	%this.selectSpriteName("accessory");
		
	%animation = %this.getSpriteName() @ %this.accessory @ %this.direction;
	%this.setSpriteAnimation("Assets:" @ %animation);
	echo(%animation);
	
	//	Hair
	%this.selectSpriteName("hair");
		
	%animation = %this.getSpriteName() @ %this.hairColour @ %this.hairStyle @ %this.direction;
	%this.setSpriteAnimation("Assets:" @ %animation);
	echo(%animation);
	
	//	Head
	%this.selectSpriteName("head");

	if (%this.state $= $SpriteStateIdle ||
		%this.state $= $SpriteStateWalk)
	{
		%state = "";
	}
	else
	{
		%state = %this.state;
	}
	%animation = %this.getSpriteName() @ %this.gender @ %this.ethnicity @ %state @ %this.direction;
	%this.setSpriteAnimation("Assets:" @ %animation);
	
	//	Torso
	%this.selectSpriteName("torso");

	if (%this.state $= $SpriteStateIdle ||
		%this.state $= $SpriteStateWalk)
	{
		%state = "";
	}
	else
	{
		%state = %this.state;
	}
		
	%animation = %this.getSpriteName() @ %this.torso @ %state @ %this.direction;
	%this.setSpriteAnimation("Assets:" @ %animation);
	
	//	Legs
	%this.selectSpriteName("legs");
	%state = %this.state;
		
	%animation = %this.getSpriteName() @ %this.legs @ %state @ %this.direction;
	%this.setSpriteAnimation("Assets:" @ %animation);
}

//	Default action when Player interacts with Guide
function Character::Use(%this, %user)
{
	%this.dialogueTree.OpenDialogue(%user);
}

//	Set the character to look at the target
function Character::FaceTarget(%this, %target)
{
	//	Find the angle of the two positions
	%angle = Vector2AngleToPoint(%this.getPosition(), %target.getPosition());

	if (%angle < 135 && %angle > 45)
		%this.direction = $SpriteDirectionRight;
	else if (%angle > -135 && %angle < -45)
		%this.direction = $SpriteDirectionLeft;
	else if (%angle <= 45 && %angle >= -45)
		%this.direction = $SpriteDirectionDown;
	else
		%this.direction = $SpriteDirectionUp;
	
	%this.UpdateImages();
}