//	Scene Setup
function Lesson2_Gate::Setup(%this)
{
	%this.setName("Lesson2_Gate");

	//	Add Tiled Map
	%mapSprite = new TmxMapSprite()
	{
		Map = "Year8:lesson2_map";
	};
	
	%this.add(%mapSprite);

	%this.SetupCharacters();
	%this.SetupItems();
	%this.SetupObstacles();
}

//	Characters
function Lesson2_Gate::SetupCharacters(%this)
{
	//  Create Player
	SetupPlayer(%this, PlayerPos.getPosition(), PlayerPos.getSceneLayer());
	Player.direction = $SpriteDirectionUp;
	Player.UpdateImages();
}

//	Items
function Lesson2_Gate::SetupItems(%this)
{
	//  Orbs
	//	"Boys usually reach puberty before girls."
	new CompositeSprite(L2_Orb1)
	{
		displayName = "Boys usually reach puberty before girls";
		answer = false;
		class = "Item";
		Position = Orb1Pos.getPosition();
		SceneLayer = Orb1Pos.getSceneLayer();
	};
	%this.SetupOrb(L2_Orb1);
	
	//	"Mood swings are common during puberty."
	%position = Orb2Pos.getPosition();
	%position.x += 0.5;
	new CompositeSprite(L2_Orb2)
	{
		displayName = "Mood swings are common during puberty";
		answer = true;
		class = "Item";
		Position = %position;
		SceneLayer = Orb2Pos.getSceneLayer();
	};
	%this.SetupOrb(L2_Orb2);
	
	//	"The physical changes of puberty can affect the emotions."
	new CompositeSprite(L2_Orb3)
	{
		displayName = "The physical changes of puberty can affect the emotions";
		answer = true;
		class = "Item";
		Position = Orb3Pos.getPosition();
		SceneLayer = Orb3Pos.getSceneLayer();
	};
	%this.SetupOrb(L2_Orb3);
	
	//	"All the changes at puberty are visible."
	new CompositeSprite(L2_Orb4)
	{
		displayName = "All the changes at puberty are visible";
		answer = false;
		class = "Item";
		Position = Orb4Pos.getPosition();
		SceneLayer = Orb4Pos.getSceneLayer();
	};
	%this.SetupOrb(L2_Orb4);
	
	//	"Only boys' voices get deeper at puberty."
	new CompositeSprite(L2_Orb5)
	{
		displayName = "Only boys' voices get deeper at puberty";
		class = "Item";
		answer = false;
		Position = Orb5Pos.getPosition();
		SceneLayer = Orb5Pos.getSceneLayer();
	};
	%this.SetupOrb(L2_Orb5);
	
	//	"People develop in different ways and at different ages."
	new CompositeSprite(L2_Orb6)
	{
		displayName = "People develop in different ways and at different ages";
		class = "Item";
		answer = true;
		Position = Orb6Pos.getPosition();
		SceneLayer = Orb6Pos.getSceneLayer();
	};
	%this.SetupOrb(L2_Orb6);
	
	//	"Young people are sexually mature after puberty."
	new CompositeSprite(L2_Orb7)
	{
		displayName = "Young people are sexually mature after puberty";
		class = "Item";
		answer = true;
		Position = Orb7Pos.getPosition();
		SceneLayer = Orb7Pos.getSceneLayer();
	};
	%this.SetupOrb(L2_Orb7);
	
	//	"It is normal for boys to develop breasts during puberty."
	new CompositeSprite(L2_Orb8)
	{
		displayName = "It is normal for boys to develop breasts during puberty";
		class = "Item";
		answer = true;
		Position = Orb8Pos.getPosition();
		SceneLayer = Orb8Pos.getSceneLayer();
	};
	%this.SetupOrb(L2_Orb8);
	
	//	"You sweat and smell more during and after puberty."
	new CompositeSprite(L2_Orb9)
	{
		displayName = "You sweat and smell more during and after puberty";
		class = "Item";
		answer = true;
		Position = Orb9Pos.getPosition();
		SceneLayer = Orb9Pos.getSceneLayer();
	};
	%this.SetupOrb(L2_Orb9);
	
	//	"Hormones are chemicals created by the body and are responsible for puberty."
	new CompositeSprite(L2_Orb10)
	{
		displayName = "Hormones are chemicals created by the body and are responsible for puberty";
		class = "Item";
		answer = true;
		Position = Orb10Pos.getPosition();
		SceneLayer = Orb10Pos.getSceneLayer();
	};
	%this.SetupOrb(L2_Orb10);
}

//	Obstacles
function Lesson2_Gate::SetupObstacles(%this)
{
	//	Rocks
	new CompositeSprite(L2_Rock0West)
	{
		displayName = "Rock";
		class = "Pushable";
		
		collisionSize = "1.8, 1.8";
		density = 75;
		
		imageName = "Assets:Rock1";
		imagePos = "0, 0";
		imageSize = "2, 2";

		Position = Rock0WestPos.getPosition();
		SceneLayer = Rock0WestPos.getSceneLayer();
	};
	L2_Rock0West.Setup(%this);
	
	%position = Rock1WestPos.getPosition();
	%position.x += 0.7;
	%position.y += 0.25;
	new CompositeSprite(L2_Rock1West)
	{
		displayName = "Rock";
		class = "Pushable";
		
		collisionSize = "2.25, 2.25";
		density = 75;
		
		imageName = "Assets:Rock1";
		imagePos = "0, 0";
		imageSize = "2.5, 2.5";

		Position = %position;
		SceneLayer = Rock1WestPos.getSceneLayer();
	};
	L2_Rock1West.Setup(%this);
	
	%position = Rock2WestPos.getPosition();
	%position.x += 0.75;
	new CompositeSprite(L2_Rock2West)
	{
		displayName = "Rock";
		class = "Pushable";
		
		collisionSize = "2.25, 2.25";
		density = 75;
		
		imageName = "Assets:Rock2";
		imagePos = "0, 0";
		imageSize = "2.5, 2.5";

		Position = %position;
		SceneLayer = Rock2WestPos.getSceneLayer();
	};
	L2_Rock2West.Setup(%this);
	
	%position = Rock1EastPos.getPosition();
	%position.y += 0.5;
	new CompositeSprite(L2_Rock1East)
	{
		displayName = "Rock";
		class = "Pushable";
		
		collisionSize = "3.25, 2.75";
		angle = 180;
		density = 90;
		
		imageName = "Assets:Rock2";
		imagePos = "0, 0";
		imageSize = "3.5, 3";

		Position = %position;
		SceneLayer = Rock1EastPos.getSceneLayer();
	};
	// Forseeing this rock will cause more problems than fun
	//L2_Rock1East.Setup(%this);
	
	new CompositeSprite(L2_Rock2East)
	{
		displayName = "Rock";
		class = "Pushable";
		
		collisionSize = "2, 1.8";
		density = 75;
		
		imageName = "Assets:Rock1";
		imagePos = "0, 0";
		imageSize = "2.25, 2.25";

		Position = Rock2EastPos.getPosition();
		SceneLayer = Rock2EastPos.getSceneLayer();
	};
	L2_Rock2East.Setup(%this);
	
	//	Logs
	%position = Log1WestPos.getPosition();
	%position.x -= 0.5;
	new CompositeSprite(L2_Log1West)
	{
		displayName = "Log";
		class = "Pushable";
		
		collisionSize = "3, 1";
		density = 50;
		
		imageName = "Assets:Log1";
		imagePos = "0, 0";
		imageSize = "3, 1";

		Position = %position;
		SceneLayer = Log1WestPos.getSceneLayer();
	};
	L2_Log1West.Setup(%this);
	
	%position = Log2EastPos.getPosition();
	%position.y += 1;
	new CompositeSprite(L2_Log2East)
	{
		displayName = "Log";
		class = "Pushable";
		
		collisionSize = "3.5, 1";
		angle = 90;
		density = 50;
		
		imageName = "Assets:Log1";
		imagePos = "0, 0";
		imageSize = "3.5, 1";

		Position = %position;
		SceneLayer = Log2EastPos.getSceneLayer();
	};
	L2_Log2East.Setup(%this);
	
	//	Stone Sign
	new CompositeSprite(L2_StoneSign)
	{
		displayName = "Stone Sign";
		class = "Readable";
		
		collisionSize = "1.25, 1";
		imageName = "Assets:StoneSign";
		imagePos = "0, 0.2";
		imageSize = "2, 2";
		
		dialogueTree = L2_StoneSignDialogueTree;

		Position = StoneSignPos.getPosition();
		SceneLayer = StoneSignPos.getSceneLayer();
	};
	L2_StoneSign.Setup(%this);
	
	//	Slot In
	%position = SlotInWestPos.getPosition();
	%position.y += 1;
	new CompositeSprite(L2_SlotInWest)
	{
	   displayName = "True Slot";
		class = "Static";
		answer = true;	//	Slot for true statements
		slotOut = L2_SlotOutWest;
		Position = %position;
		SceneLayer = SlotInWestPos.getSceneLayer();
	};
	%this.SetupSlotIn(L2_SlotInWest);
	
	%position = SlotInEastPos.getPosition();
	%position.y += 1;
	new CompositeSprite(L2_SlotInEast)
	{
	   displayName = "False Slot";
		class = "Static";
		answer = false;	//	Slot for false statements
		slotOut = L2_SlotOutEast;
		Position = %position;
		SceneLayer = SlotInEastPos.getSceneLayer();
	};
	%this.SetupSlotIn(L2_SlotInEast);
	
	//	Slot Out
	new CompositeSprite(L2_SlotOutWest)
	{
		class = "Static";
		answer = true;	//	Slot for true statements
		Position = SlotOutWestPos.getPosition();
		SceneLayer = SlotOutWestPos.getSceneLayer();
	};
	%this.SetupSlotOut(L2_SlotOutWest);
	
	new CompositeSprite(L2_SlotOutEast)
	{
		class = "Static";
		answer = false;	//	Slot for false statements
		Position = SlotOutEastPos.getPosition();
		SceneLayer = SlotOutEastPos.getSceneLayer();
	};
	%this.SetupSlotOut(L2_SlotOutEast);
	
	//	Gate Doors
	%layer = GatePos.getSceneLayer();
	%layer += 4;
	%x = 0.9;
	%y = 0.9;
	
	%position = GatePos.getPosition();
	%position.x -= %x;
	%position.y += %y;
	new CompositeSprite(L2_DoorWest)
	{
		displayName = "Gate";
		collisionSize = %size;
		imageFrame = 0;

		Position = %position;
		SceneLayer = %layer;
	};
	%this.SetupGate(L2_DoorWest);
	
	%position = GatePos.getPosition();
	%position.x += %x;
	%position.y += %y;
	new CompositeSprite(L2_DoorEast)
	{
		displayName = "Gate";
		collisionSize = %size;
		imageFrame = 1;

		Position = %position;
		SceneLayer = %layer;
	};
	%this.SetupGate(L2_DoorEast);
}

//	Setup Orbs
function Lesson2_Gate::SetupOrb(%this, %orb)
{
	Lesson2.totalOrbs++;
	%orb.collisionSize = "0.5, 0.5";
	%orb.animationName = "Assets:OrbFlash";
	%orb.imagePos = "0, 0";
	%orb.imageSize = "1.5, 1.5";
	%orb.isFound = false;
	%orb.Setup(%this);
}
function L2_Orb1::onPickUp(%this)	{	Lesson2.PickUpOrb(%this); return true;	}
function L2_Orb2::onPickUp(%this)	{	Lesson2.PickUpOrb(%this); return true;	}
function L2_Orb3::onPickUp(%this)	{	Lesson2.PickUpOrb(%this); return true;	}
function L2_Orb4::onPickUp(%this)	{	Lesson2.PickUpOrb(%this); return true;	}
function L2_Orb5::onPickUp(%this)	{	Lesson2.PickUpOrb(%this); return true;	}
function L2_Orb6::onPickUp(%this)	{	Lesson2.PickUpOrb(%this); return true;	}
function L2_Orb7::onPickUp(%this)	{	Lesson2.PickUpOrb(%this); return true;	}
function L2_Orb8::onPickUp(%this)	{	Lesson2.PickUpOrb(%this); return true;	}
function L2_Orb9::onPickUp(%this)	{	Lesson2.PickUpOrb(%this); return true;	}
function L2_Orb10::onPickUp(%this)	{	Lesson2.PickUpOrb(%this); return true;	}

// Setup Gates
function Lesson2_Gate::SetupGate(%this, %gate)
{
	%size = "1.85, 3.5";
   %gate.speed = 3;
	%gate.setBodyType(dynamic);

	// This effects how characters collide
	%gate.setDefaultDensity(1000000);   // Made ridiculously high so characters will not budge
	%gate.setDefaultRestitution(0);	//	Bounciness
	%gate.setDefaultFriction(0);
	%gate.setLinearDamping(1);	//	How quickly it slows down
	
	// Which objects to collide with
	%gate.setCollisionGroups(none);
	%gate.setCollisionGroups(%gate.getSceneLayer());
	%gate.setCollisionLayers(none);
	%gate.setCollisionLayers(%gate.getSceneLayer());
	
	%gate.addSprite();
	%gate.setSpriteImage("Assets:GateDoor");
	%gate.setSpriteImageFrame(%gate.imageFrame);
	%gate.setSpriteSize(%size);

	%gate.createPolygonBoxCollisionShape(%size.x, %size.y);

	%gate.setCollisionCallback(true);   // So onCollision will be called
	%gate.setFixedAngle(true); // Stop from rotating on collision
	
	%this.add(%gate);
}

//	Setup Slots
function Lesson2_Gate::SetupSlotIn(%this, %slot)
{
	%slot.collisionSize = "1.1, 1.5";
	%slot.imageName = "Assets:Slot2";
	%slot.imagePos = "0, -0.25";
	%slot.imageSize = "2, 2";
	%slot.Setup(%this);
}
function Lesson2_Gate::SetupSlotOut(%this, %slot)
{
	%slot.displayName = "Slot";
	%slot.collisionSize = "1, 1";
	%slot.imageName = "Assets:Slot1";
	%slot.imagePos = "0, 0";
	%slot.imageSize = "1, 1";
	%slot.Setup(%this);
}

//	Slot Use
function L2_SlotInWest::Use(%this, %user) {	Lesson2_Gate.UseOrb(%this);   }
function L2_SlotInEast::Use(%this, %user) {	Lesson2_Gate.UseOrb(%this);   }

function Lesson2_Gate::UseOrb(%this, %slot)
{
   //error("Use Orb");
   
	%item = Inventory.UseSelectedItem();
   /*echo(%slot SPC %slot.getName());
   echo(%item SPC %item.getName());*/
   
   if (%item !$= "")
   {
      if (%item.getName() $= L2_Orb1 ||
         %item.getName() $= L2_Orb2 ||
         %item.getName() $= L2_Orb3 ||
         %item.getName() $= L2_Orb4 ||
         %item.getName() $= L2_Orb5 ||
         %item.getName() $= L2_Orb6 ||
         %item.getName() $= L2_Orb7 ||
         %item.getName() $= L2_Orb8 ||
         %item.getName() $= L2_Orb9 ||
         %item.getName() $= L2_Orb10)
      {
         if (%slot.answer $= %item.answer)
         {
            %item = Inventory.RemoveSelectedItem();
         
			//echo("Right slot");
            Lesson2.orbsInGate++;
			//echo("This orb is in the right slot.");
            UpdateHelpBar(Lesson2, "This orb is in the right slot.");
         }
         else
         {
			//echo("Wrong slot");
			/*echo(%this);
			echo(%item.getName());
            %speed = 10;
            //%item.setBodyType(dynamic);
			%pos = %slot.slotOut.getPosition();
			//%pos.y -= 4;
            %item.setPosition(%pos);
            %item.setLinearVelocityY(-%speed);
            %item.setCollisionShapeIsSensor(0, true);
			echo("New values setup");
			%scene = GameWindow.getScene();
			echo("Add to scene");
            %this.schedule(1000, %item.addToScene);
			echo("Add interaction zone");
            //addInteractionZone(%item, %this);*/
         
			//echo("This orb is in the right slot.");
            UpdateHelpBar(Lesson2, "This orb does not go into the" SPC %slot.displayName @ ".");
         }
      }
      else
      {
         UpdateHelpBar(Lesson2, "You have no orbs to insert.");
      }
   }
   else
   {
      UpdateHelpBar(Lesson2, "You have no orbs to insert.");
   }
   
   %delayTime = 2500;
   if (Lesson2.AllOrbsSlotted())
      %delayTime = 0;
   
   Lesson2.schedule(%delayTime, UpdateStatus);
}

function L2_SlotInWest::DisplayUse(%this)
{
	return "Insert item into" SPC %this.displayName @ ".";
}
function L2_SlotInEast::DisplayUse(%this)
{
	return "Insert item into" SPC %this.displayName @ ".";
}

//	Triggers
function L2_SlotOutStop::onEnter(%this, %object)
{
	if (%object.class $= Item)
	   %object.setCollisionShapeIsSensor(0, false);
}
function L2_Exit::onEnter(%this, %object)
{
	if (%object.getName() $= Player)
	{
		UpdateHelpBar(Lesson2, "Leaving Divisions");

		// New scenes cannot be called during onCollision else the game will crash
		/*%this.schedule(100, */EndActivity(Lesson2);//);
	}
}
function L2_ExitWarn::onEnter(%this, %object)
{
	UpdateHelpBar(Lesson2, "You are about to leave Divisions");
}
function L2_ExitWarn::onLeave(%this, %object)
{
	UpdateHelpBar(Lesson2);
}