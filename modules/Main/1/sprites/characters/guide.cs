// The closest thing I can find to a class constructor.
// Anything here will overwrite previously defined fields
function Guide::onAdd(%this)
{
	%this.setup();
}

function Guide::Setup(%this)
{
	SetupCharacter(%this);
/*
	%this.damping = 20;
	%this.direction = $SpriteDirectionRight;   // Used for determining image
	%this.speed = 4;
	%this.state = $SpriteStateWalk;	// Used for determining image
	%this.positionAdjust = "0 -0.5";
	%this.useRange = 1.5;	// How close does something have to be for the character to use it

	%this.setSize(2);
	%this.setBodyType(dynamic);

	// This effects how characters collide
	%this.setDefaultDensity(1000000);   // Made ridiculously high so characters will not budge
	%this.setDefaultRestitution(0);	//	Bounciness
	%this.setDefaultFriction(0);
	%this.setLinearDamping(%this.damping);	//	How quickly it slows down

	// Collision Circle, if size not set = size of image
	// (radius, [relative xPos, relative yPos])
	//%this.createCircleCollisionShape(0.25, 0, -0.25);
	%this.createPolygonBoxCollisionShape(1, 1, %this.positionAdjust.x, %this.positionAdjust.y);

	%this.setCollisionCallback(true);   // So onCollision will be called
	%this.setFixedAngle(true); // Stop from rotating on collision
	*/
	%this.setSize(2);
	%this.UpdateImages();
	/*
	//	Dialogue Tree
	%this.dialogueTree = new ScriptObject()
	{
		class = DialogueTree;
	};
	%this.dialogueTree.setup(%this);*/
}

// Change the images to match the current state
function Guide::UpdateImages(%this)
{
	%image = %this.imageName;
	%animation = %image @ %this.state @ %this.direction;
	%this.playAnimation(%animation);
}

//	Default action when Player interacts with Guide
function Guide::Use(%this, %user)
{
	%this.dialogueTree.OpenDialogue(%user);
}

//	Set the character to look at the target
function Guide::FaceTarget(%this, %target)
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