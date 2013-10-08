function Character::onRemoveFromScene(%this)
{
   removeInteractionZone(%this);
}

function SetupCharacter(%character)
{
	%character.damping = 20;
	%character.direction = $SpriteDirectionDown;   // The direction they are facing. Used for determining image
	%character.imageSize = 2;
	%character.speed = 4;
	%character.state = $SpriteStateIdle;	// What the sprite is doing. Used for determining image
	%character.positionAdjust = "0 -0.5";
	%character.collisionSize = "0.6 0.8";
	%character.useRange = 1;//.5;	// How close does something have to be for the character to use it

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
	if (!isObject(%character.dialogueTree))
	{
      %character.dialogueTree = new ScriptObject()
      {
         class = DialogueTree;
      };
	}
	%character.dialogueTree.Setup(%character);
}

function Character::Setup(%this, %scene)
{
	SetupCharacter(%this);
	
	// Sprites, or graphics, the character is composed of
	%this.addSprite();
	%this.setSpriteName("legs");
	%this.setSpriteSize(%this.imageSize);
	
	%this.addSprite();
	%this.setSpriteName("torso");
	%this.setSpriteSize(%this.imageSize);
	
	%this.addSprite();
	%this.setSpriteName("head");
	%this.setSpriteSize(%this.imageSize);
	
	%this.addSprite();
	%this.setSpriteName("hair");
	%this.setSpriteSize(%this.imageSize);
	
	%this.addSprite();
	%this.setSpriteName("accessory");
	%this.setSpriteSize(%this.imageSize);
	
	%this.UpdateImages();
	
	%scene.add(%this);
	addInteractionZone(%this, %scene);
}

// Change the images to match the current state
function Character::UpdateImages(%this)
{
	//	Accessory
	%this.selectSpriteName("accessory");
		
   if (%this.accessory !$= $SpriteAccessoryNone)
   {
      %animation = %this.getSpriteName() @ %this.accessory @ %this.direction;
      %this.setSpriteAnimation("Assets:" @ %animation);
	   echo(%animation);
   }
   else
	   %this.setSpriteAnimation($SpriteAccessoryNone);
	
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

// Randomize Character Functions
function GetRandomGender(%this)
{
   setRandomSeed();  // So it actually is random
   %r = getRandom($SpriteGenderCount - 1);
   return $SpriteGenderArray[%r];
}
function GetRandomEthnicity(%this)
{
   setRandomSeed();  // So it actually is random
   %r = getRandom($SpriteEthnicityCount - 1);
   return $SpriteEthnicityArray[%r];
}
function GetRandomHairColour(%this)
{
   setRandomSeed();  // So it actually is random
   %r = getRandom($SpriteHairColourCount - 1);
   return $SpriteHairColourArray[%r];
}
function GetRandomHairStyle(%this)
{
   setRandomSeed();  // So it actually is random
   %r = getRandom($SpriteHairStyleCount - 1);
   return $SpriteHairStyleArray[%r];
}
function GetRandomTorso(%this)
{
   setRandomSeed();  // So it actually is random
   %r = getRandom($SpriteTorsoCount - 2);
   %torso = $SpriteTorsoArray[%r];
   
   switch$(%torso)
   {
      case 2:
         if (%this.gender $= $SpriteGenderFemale)
         {
            return $SpriteTorsoTShirtF;
         }
         else
         {
            return $SpriteTorsoTShirt;
         }
      default:
         return %torso;//$SpriteTorsoArray[%r];
   }
}
function GetRandomLegs(%this)
{
   setRandomSeed();  // So it actually is random
   %r = getRandom($SpriteLegsCount - 1);
   return $SpriteLegsArray[%r];
}
function GetRandomAccessory(%this)
{
   setRandomSeed();  // So it actually is random
   %r = getRandom($SpriteAccessoryCount - 1);
   return $SpriteAccessoryArray[%r];
}