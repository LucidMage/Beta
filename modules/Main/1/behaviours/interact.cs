if (!isObject(InteractBehaviour))
{
   %template = new BehaviorTemplate(InteractBehaviour);
   
   %template.friendlyName = "Interact";
   %template.behaviorType = "Input";
   %template.description = "Interact with sprite";
   
   // addBehaviorField(function name, description of function, keybind, input e.g. "keyboard up" = up arrow key)
   %template.addBehaviorField(useKey, "Key to bind for interacting with a sprite", keybind, "keyboard space");
}

function InteractBehaviour::onBehaviorAdd(%this)
{
   if (!isObject(GlobalActionMap))
      return;

   // bindObj(getWord(object.behaviour field, [function parameters excluding %this]), "function name", object)
   GlobalActionMap.bindObj(getWord(%this.useKey, 0), getWord(%this.useKey, 1), "Use", %this);
}

function InteractBehaviour::onBehaviorRemove(%this)
{
   if (!isObject(GlobalActionMap))
      return;

   GlobalActionMap.unbindObj(getWord(%this.useKey, 0), getWord(%this.useKey, 1), %this);
}

//	Run the use function of whatever sprite is within range
function InteractBehaviour::Use(%this, %val)
{
	if (%val > 0 && %this.owner.inDialogue == false)
	{
	   // Get all objects in the scene
		%scene = GameWindow.getScene();
		%objects = %scene.getSceneObjectList();
		%count = getWordCount(%objects);
		%objectsInRange = "";
		
		// Get objects marked as being in range of interaction
		for (%i = 0; %i < %count; %i++)
		{
			%object = getWord(%objects, %i);
			
			if (%object.inRange == true)
			   %objectsInRange = %objectsInRange SPC %object;
		}
		
		// Use marked objects
		%objectChosen = false;  // So that only one object is used at a time
		%count = getWordCount(%objectsInRange);
		/*error("Using objects:");
		echo(%objectsInRange);
		echo("Count:" SPC %count);*/
		
		// Count backwards so that the object used matches the action text displayed, hopefully
		for (%i = %count - 1; %i >= 0; %i--)
		{
		   if (!%objectChosen)
		   {
            %object = getWord(%objectsInRange, %i);
            if (%object !$= "")
            {
               /*echo("Object:" SPC %object);
               warn("Class:" SPC %object.class);*/
               %object.Use(%this.owner);
               %objectChosen = true;
            }
		   }
		}
	}
}

function InteractBehaviour::GetUseStartPoint(%this)
{
   %startPos = %this.owner.getPosition(); // Starting point of pickRay
   %startPos.x += %this.owner.positionAdjust.x;
   %startPos.y += %this.owner.positionAdjust.y;
}

function InteractBehaviour::GetUseEndPoint(%this)
{
   %startPos = %this.GetUseStartPoint();
   %direction = %this.owner.direction;
   %range = "0 0";
   
   //	First select a sprite
   //	Should be in the direction the character is facing
   switch$(%direction)
   {
      case $SpriteDirectionUp:
         %range.y += %this.owner.useRange;
      case $SpriteDirectionRight:
         %range.x += %this.owner.useRange;
      case $SpriteDirectionDown:
         %range.y -= %this.owner.useRange;
      case $SpriteDirectionLeft:
         %range.x -= %this.owner.useRange;
   }

   return (%startPos.x + %range.x) SPC (%startPos.y + %range.y); // Ending point of pickRay
}

//	Interaction Zone class functions
function addInteractionZone(%sprite, %scene)
{
	%pos = "0 0";
	
	if (%sprite $= Player)
	{
	   %pos = %sprite.positionAdjust;
	   
	   if (%sprite.useRange.y != 0)
	      %size = %sprite.useRange.x SPC %sprite.useRange.y;
      else
	      %size = %sprite.useRange SPC %sprite.useRange;
	   
      %sprite.interactionZone = new SceneObject()
      {
         class = PlayerInteractionZone;
         owner = %sprite;
         BodyType = dynamic;
         Position = %pos;
         SceneLayer = %sprite.getSceneLayer();
         Size = (%size.x * 2) SPC (%size.y * 2);
      };
	}
	else
	{
      %sprite.interactionZone = new Trigger()
      {
         class = InteractionZone;
         owner = %sprite;
         BodyType = dynamic;
         Position = %pos;
         SceneLayer = %sprite.getSceneLayer();
         Size = (%sprite.useRange * 2) SPC (%sprite.useRange * 2);
      };
	  %sprite.interactionZone.setEnterCallback(true);
	  %sprite.interactionZone.setLeaveCallback(true);
	}
   
	%sprite.interactionZone.setDefaultDensity(1);
	/*%sprite.interactionZone.setDefaultRestitution(0);	//	Bounciness
	%sprite.interactionZone.setDefaultFriction(0);
	%sprite.interactionZone.setLinearDamping(0);*/	//	How quickly it slows down
	
	if (%sprite $= Player)
	{
	   %top = "0 0";
	   %left = -(%sprite.interactionZone.getSizeX() / 4) SPC -(%sprite.interactionZone.getSizeY() / 2);
	   %right = (%sprite.interactionZone.getSizeX() / 4) SPC -(%sprite.interactionZone.getSizeY() / 2);
      %sprite.interactionZone.createPolygonCollisionShape(%top SPC %left SPC %right);
      %sprite.interactionZone.setUpdateCallback(true);
	}
	else if (%sprite.class $= "Pushable"/* || %sprite.class $= "Static"*/)
	{
	   %sprite.interactionZone.setSize(%sprite.useRange.x * 2, %sprite.useRange.y * 2);
      %sprite.interactionZone.createPolygonBoxCollisionShape(%sprite.interactionZone.getSizeX(), %sprite.interactionZone.getSizeY());
      %sprite.interactionZone.setAngle(%sprite.angle);
	}
	else
	{
      %sprite.interactionZone.createCircleCollisionShape(%sprite.interactionZone.getSizeX());
	}
	//%sprite.interactionZone.setCollisionSuppress(true);
	%sprite.interactionZone.setCollisionShapeIsSensor(0, true);
	
	%sprite.inRange = false;
	%scene.add(%sprite.interactionZone);
	%sprite.interactionJoin = %scene.createRevoluteJoint(%sprite, %sprite.interactionZone, %pos.x, %pos.y);
}

function removeInteractionZone(%sprite)
{
   if (isObject(%sprite.interactionZone))
	   %sprite.interactionZone.delete();
}

function InteractionZone::onEnter(%this, %object)
{
	if (%object.class $= PlayerInteractionZone)
	{
	   %this.owner.inRange = true;
		UpdateHelpBar(Main.ActiveActivity, %this.owner.DisplayUse());
	}
}

function InteractionZone::onLeave(%this, %object)
{
	if (%object.class $= PlayerInteractionZone)
	{
	   %this.owner.inRange = false;
		UpdateHelpBar(Main.ActiveActivity);
	}
}

function PlayerInteractionZone::onUpdate(%this)
{
   %this.setAngularVelocity(0);  // So it will stop rotating
   
   // Interaction Zone must point to where the player is facing
   switch$(Player.direction)
   {
      case $SpriteDirectionLeft:
         Player.interactionZone.setAngle(-90);
      case $SpriteDirectionRight:
         Player.interactionZone.setAngle(90);
      case $SpriteDirectionUp:
         Player.interactionZone.setAngle(180);
      case $SpriteDirectionDown:
         Player.interactionZone.setAngle(0);
   }
}