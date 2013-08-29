// The closest thing I can find to a class constructor.
// Anything here will overwrite previously defined fields
function Character::onAdd(%this)
{
	%this.Setup();
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
	%character.dialogueTree = new ScriptObject()
	{
		class = DialogueTree;
	};
	%character.dialogueTree.Setup(%character);
}

function Character::Setup(%this)
{
	echo("Character Setup");
	SetupCharacter(%this);
/*
	%this.damping = 20;
	%this.direction = $SpriteDirectionDown;   // The direction they are facing. Used for determining image
	%this.speed = 4;
	%this.state = $SpriteStateIdle;	// What the sprite is doing. Used for determining image
	%this.positionAdjust = "0 -0.5";
	%this.useRange = 1.5;	// How close does something have to be for the character to use it

	%this.setBodyType(dynamic);

	// This effects how characters collide
	%this.setDefaultDensity(1000000);   // Made ridiculously high so characters will not budge
	%this.setDefaultRestitution(0);	//	Bounciness
	%this.setDefaultFriction(0);
	%this.setLinearDamping(%this.damping);	//	How quickly it slows down

	// Collision Circle, if size not set = size of image
	// (radius, [relative xPos, relative yPos])
	%this.createPolygonBoxCollisionShape(1, 1, %this.positionAdjust.x, %this.positionAdjust.y);

	%this.setCollisionCallback(true);   // So onCollision will be called
	%this.setFixedAngle(true); // Stop from rotating on collision
*/
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
	
	%this.UpdateImages();
	/*
	//	Dialogue Tree
	%this.dialogueTree = new ScriptObject()
	{
		class = DialogueTree;
	};
	%this.dialogueTree.setup(%this);*/
	echo("End of Character Setup");
}

// Change the images to match the current state
function Character::updateImages(%this)
{
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
	
	echo("Gender:" SPC %this.gender);
	echo("Ethnicity:" SPC %this.ethnicity);
	echo("State:" SPC %state);
	echo("Torso:" SPC %this.torso);
	echo("Legs:" SPC %this.legs);
	%animation = %this.getSpriteName() @ %this.gender @ %this.ethnicity @ %state @ %this.direction;
	echo(%animation);
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