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

   //%this.owner.disableUpdateCallback();

   GlobalActionMap.unbindObj(getWord(%this.useKey, 0), getWord(%this.useKey, 1), %this);
}

//	Run the use function of whatever sprite is within range
function InteractBehaviour::Use(%this, %val)
{
	//echo("Val is " @ %val);
	if (%val > 0)
	{
		echo("Val is greater than 0");
      %direction = %this.owner.direction;
      %range = "0 0";
		
		%startPos = %this.owner.getPosition(); // Starting point of pickRay
		%startPos.x += %this.owner.positionAdjust.x;
		%startPos.y += %this.owner.positionAdjust.y;
		
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
		
		//%startPos = %this.GetUseStartPoint();
		%endPos = (%startPos.x + %range.x) SPC (%startPos.y + %range.y); // Ending point of pickRay
		//%endPos = %this.GetUseEndPoint();//(%startPos.x + %range.x) SPC (%startPos.y + %range.y); // Ending point of pickRay
		
		%scene = GameWindow.getScene();
		// Get sprites within range
		%picked = %scene.pickRay(%startPos, %endPos, "", "", collision);
		
		// Iterate over list of picked objects
		%count = %picked.count;
		
		//if (%count > 0)
		%objectPicked = false;
		for (%i = 0; %i < %count; %i++)
		{
			%object = getWord(%picked, %i);
			echo("Object:" SPC %object);
			echo("Class:" SPC %object.class);
			
			if (%objectPicked == false)
			{
            if (%object.class $= InteractionZone)
            {
               echo("Owner:" SPC %object.owner);
               %object.owner.Use(%this.owner);
               %objectPicked = true;
            }
            else if (%object.class !$= PlayerInteractionZone)
            {
               %object.Use(%this.owner);
               %objectPicked = true;
            }
			}
		}
	}
}
/*
//	Scheduled method to display description of what will happen when they use an object in range
function InteractBehaviour::DisplayUsable()
{
	%direction = %this.owner.direction;
	%range = "0 0";
	%startPos = %this.owner.getPosition(); // Starting point of pickRay
	%startPos.x += %this.owner.positionAdjust.x;
	%startPos.y += %this.owner.positionAdjust.y;
	/*
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
	
	%endPos = %this.GetUseEndPoint(%startPos);//(%startPos.x + %range.x) SPC (%startPos.y + %range.y); // Ending point of pickRay
	
	%scene = GameWindow.getScene();
	// Get sprites within range
	%picked = %scene.pickRay(%startPos, %endPos, "", "", collision);
	
	// Iterate over list of picked objects
	%count = %picked.count;
	
	for (%i = 0; %i < %count; %i++)
	{
		%object = getWord(%picked, %i);
		UpdateHelpBar(%this, %object.DisplayUse());
	}
}
*/
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
	error("Add Interaction Zone");
	%pos = "0 0";
	
	if (%sprite $= Player)
	{
	   %pos = %sprite.positionAdjust;
	   
      %sprite.interactionZone = new SceneObject()
      {
         class = PlayerInteractionZone;
         owner = %sprite;
         BodyType = dynamic;//static;
         Position = %pos;//;//%sprite.getPosition();
         SceneLayer = %sprite.getSceneLayer();
         Size = (%sprite.useRange * 2) SPC (%sprite.useRange * 2);
         //Image = "Assets:highlightBackground";
      };/*
	   %sprite.interactionZone.setPositionY(-(%sprite.useRange));
      %sprite.interactionZone.setSizeX(%sprite.collisionSize.x);
      %sprite.interactionZone.setSizeY(%sprite.useRange);*/
	}
	else
	{
		echo("Zone is trigger");
      %sprite.interactionZone = new Trigger()
      {
         class = InteractionZone;
         owner = %sprite;
         BodyType = dynamic;//static;
         Position = %pos;//%sprite.getPosition();
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
	/*
   //%radius = %sprite.useRange * 2;
   %behvaiour = %sprite.getBehavior("InteractBehaviour");
	if (%behvaiour != 0)//%sprite $= Player)
	{
      echo("Player Interaction Zone");
      
      %startPos = %behvaiour.GetUseStartPoint();
	   %endPos = %behvaiour.GetUseEndPoint();
	   
	   %sprite.interactionZone.setPosition(%startPos.x - %endPos.x, %startPos.y - %endPos.y);
	   
	   switch$(%sprite.direction)
	   {
	      case $SpriteDirectionUp:
	      case $SpriteDirectionDown:
	      default:
	         %sprite.interactionZone.setSize(%sprite.collisionSize.x, %radius, %sprite.interactionZone.getPosition());
	      case $SpriteDirectionLeft:
	      case $SpriteDirectionRight:
	         %sprite.interactionZone.setSize(%radius, %sprite.collisionSize.y, %sprite.interactionZone.getPosition());
	   }
	   
      %sprite.interactionZone.createPolygonBoxCollisionShape(%sprite.interactionZone.getSizeX(), %sprite.interactionZone.getSizeY(),%sprite.interactionZone.getPosition());
   }
   else
	{
      //echo(%sprite.getSize());
      %sprite.interactionZone.createCircleCollisionShape(%sprite.interactionZone.getSizeX());//%radius);
	}*/
	
	if (%sprite $= Player)
	{
	   %top = "0 0";
	   %left = -(%sprite.interactionZone.getSizeX() / 2) SPC -(%sprite.interactionZone.getSizeY());
	   %right = (%sprite.interactionZone.getSizeX() / 2) SPC -(%sprite.interactionZone.getSizeY());
      %sprite.interactionZone.createPolygonCollisionShape(%top SPC %left SPC %right);
      %sprite.interactionZone.setUpdateCallback(true);
      //%sprite.interactionZone.UpdateArea();
	}
	else
	{
      %sprite.interactionZone.createCircleCollisionShape(%sprite.interactionZone.getSizeX());
	}
	//%sprite.interactionZone.setCollisionSuppress(true);
	%sprite.interactionZone.setCollisionShapeIsSensor(0, true);
	
	echo("Scene" SPC %scene);
	%scene.add(%sprite.interactionZone);
	%sprite.interactionJoin = %scene.createRevoluteJoint(%sprite, %sprite.interactionZone, %pos.x, %pos.y);//WeldJoint(%sprite, %sprite.interactionZone, "0 0", "0 0", 0, 0, false);
}

function removeInteractionZone(%sprite)
{
   if (isObject(%sprite.interactionZone))
	   %sprite.interactionZone.delete();
}

function InteractionZone::onEnter(%this, %object)
{
	echo("Zone for" SPC %this.owner);
	echo("Object:" SPC %object);
	if (%object.getName() $= PlayerInteractionZone)
	{
		UpdateHelpBar(%this, %object.DisplayUse());
	}
}

function InteractionZone::onLeave(%this, %object)
{
	echo("Zone for" SPC %this.owner);
	echo("Object:" SPC %object);
	if (%object.getName() $= PlayerInteractionZone)
	{
		UpdateHelpBar(%this, 0);
	}
}

function PlayerInteractionZone::onUpdate(%this)
{
   %this.setAngularVelocity(0);  // So it will stop rotating
   
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

/* Old version
// Used only those that use the behaviour, e.g. the player
function PlayerInteractionZone::UpdateArea(%this)
{
   %this.clearCollisionShapes();
   %owner = %this.owner;
   %pos = "0 0";//%owner.getPosition().x, %owner.getPosition().y);
   %behvaiour = %owner.getBehavior("InteractBehaviour");
   
	if (%behvaiour != 0)//%sprite $= Player)
	{
      echo("Player Interaction Zone");
      
      %startPos = %behvaiour.GetUseStartPoint();
	   %endPos = %behvaiour.GetUseEndPoint();
	   %pos = %startPos;//(%startPos.x + (%endPos.x - %startPos.x)) SPC (%startPos.y + (%endPos.y - %startPos.y));
	   echo("Start:" SPC %startPos);
	   echo("End:" SPC %endPos);
	   echo("Pos:" SPC %pos);
	   
	   //%owner.interactionZone.setPosition(%pos);//%endPos.x - %startPos.x, %endPos.y - %startPos.y);
	   
	   switch$(%owner.direction)
	   {
	      case $SpriteDirectionLeft:
	         %owner.interactionZone.setAngle(90);//%pos.x -= %owner.useRange;
	         /*%owner.interactionZone.setSizeX(%owner.useRange);
	         %owner.interactionZone.setSizeY(%owner.collisionSize.y);
	      case $SpriteDirectionRight:
	         %owner.interactionZone.setAngle(-90);//%pos.x += %owner.useRange;
	         /*%owner.interactionZone.setSizeX(%owner.useRange);
	         %owner.interactionZone.setSizeY(%owner.collisionSize.y);
	      case $SpriteDirectionUp:
	         %owner.interactionZone.setAngle(180);//%pos.y += %owner.useRange;
	         /*%owner.interactionZone.setSizeX(%owner.collisionSize.x);
	         %owner.interactionZone.setSizeY(%owner.useRange);
	      case $SpriteDirectionDown:
	         %owner.interactionZone.setAngle(0);//%pos.y -= %owner.useRange;
	         /*%owner.interactionZone.setSizeX(%owner.collisionSize.x);
	         %owner.interactionZone.setSizeY(%owner.useRange);
	   }
	   
      %owner.interactionZone.createPolygonBoxCollisionShape(%owner.interactionZone.getSizeX(), %owner.interactionZone.getSizeY());
   }
   else
	{
      //echo(%owner.getSize());
      %owner.interactionZone.createCircleCollisionShape(%owner.interactionZone.getSizeX());//%radius);
	}
	//%owner.interactionZone.setPosition(%pos);
   echo("Owner:" SPC %owner.getPosition());
   echo("Interaction Zone:" SPC %owner.interactionZone.getPosition());
}*/