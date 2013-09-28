//	Scene Setup
function Lesson2_Gate::Setup(%this)
{
	echo("Lesson 2 Gate Setup");
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
	echo("Setup Items");
	
	//  Orbs
	//	"Boys usually reach puberty before girls."
	new CompositeSprite(L2_Orb1)
	{
		displayName = "Boys usually reach puberty before girls.";
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
		displayName = "Mood swings are common during puberty.";
		answer = true;
		class = "Item";
		Position = %position;
		SceneLayer = Orb2Pos.getSceneLayer();
	};
	%this.SetupOrb(L2_Orb2);
	
	//	"The physical changes of puberty can affect the emotions."
	new CompositeSprite(L2_Orb3)
	{
		displayName = "The physical changes of puberty can affect the emotions.";
		answer = true;
		class = "Item";
		Position = Orb3Pos.getPosition();
		SceneLayer = Orb3Pos.getSceneLayer();
	};
	%this.SetupOrb(L2_Orb3);
	
	//	"All the changes at puberty are visible."
	new CompositeSprite(L2_Orb4)
	{
		displayName = "All the changes at puberty are visible.";
		answer = false;
		class = "Item";
		Position = Orb4Pos.getPosition();
		SceneLayer = Orb4Pos.getSceneLayer();
	};
	%this.SetupOrb(L2_Orb4);
	
	//	"Only boys' voices get deeper at puberty."
	new CompositeSprite(L2_Orb5)
	{
		displayName = "Only boys' voices get deeper at puberty.";
		class = "Item";
		answer = false;
		Position = Orb5Pos.getPosition();
		SceneLayer = Orb5Pos.getSceneLayer();
	};
	%this.SetupOrb(L2_Orb5);
	
	//	"People develop in different ways and at different ages."
	new CompositeSprite(L2_Orb6)
	{
		displayName = "People develop in different ways and at different ages.";
		class = "Item";
		answer = true;
		Position = Orb6Pos.getPosition();
		SceneLayer = Orb6Pos.getSceneLayer();
	};
	%this.SetupOrb(L2_Orb6);
	
	//	"Young people are sexually mature after puberty."
	new CompositeSprite(L2_Orb7)
	{
		displayName = "Young people are sexually mature after puberty.";
		class = "Item";
		answer = true;
		Position = Orb7Pos.getPosition();
		SceneLayer = Orb7Pos.getSceneLayer();
	};
	%this.SetupOrb(L2_Orb7);
	
	//	"It is normal for boys to develop breasts during puberty."
	new CompositeSprite(L2_Orb8)
	{
		displayName = "It is normal for boys to develop breasts during puberty.";
		class = "Item";
		answer = true;
		Position = Orb8Pos.getPosition();
		SceneLayer = Orb8Pos.getSceneLayer();
	};
	%this.SetupOrb(L2_Orb8);
	
	//	"You sweat and smell more during and after puberty."
	new CompositeSprite(L2_Orb9)
	{
		displayName = "You sweat and smell more during and after puberty.";
		class = "Item";
		answer = true;
		Position = Orb9Pos.getPosition();
		SceneLayer = Orb9Pos.getSceneLayer();
	};
	%this.SetupOrb(L2_Orb9);
	
	//	"Hormones are chemicals created by the body and are responsible for puberty."
	new CompositeSprite(L2_Orb10)
	{
		displayName = "Hormones are chemicals created by the body and are responsible for puberty.";
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
	echo("Setup Obstacles");
	
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
	L2_Rock0West.Setup();
	
	%position = Rock1WestPos.getPosition();
	%position.x += 0.65;
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
	L2_Rock1West.Setup();
	
	%position = Rock2WestPos.getPosition();
	%position.x += 0.5;
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
		SceneLayer = Rock1WestPos.getSceneLayer();
	};
	L2_Rock2West.Setup();
	
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
	L2_Rock1East.Setup();
	
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
	L2_Rock2East.Setup();
	
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
	L2_Log1West.Setup();
	
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
	L2_Log2East.Setup();
	
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
	L2_StoneSign.Setup();
	//L2_StoneSign.dialogueTree = L2_StoneSignDialogueTree;
	
	//	Slot In
	%position = SlotInWestPos.getPosition();
	%position.y += 1;
	new CompositeSprite(L2_SlotInWest)
	{
		class = "Static";
		slot = true;	//	Slot for true statements
		Position = %position;
		SceneLayer = SlotInWestPos.getSceneLayer();
	};
	%this.SetupSlotIn(L2_SlotInWest);
	
	%position = SlotInEastPos.getPosition();
	%position.y += 1;
	new CompositeSprite(L2_SlotInEast)
	{
		class = "Static";
		slot = false;	//	Slot for false statements
		Position = %position;
		SceneLayer = SlotInEastPos.getSceneLayer();
	};
	%this.SetupSlotIn(L2_SlotInEast);
	
	//	Slot Out
	new CompositeSprite(L2_SlotOutWest)
	{
		class = "Static";
		slot = true;	//	Slot for true statements
		Position = SlotOutWestPos.getPosition();
		SceneLayer = SlotOutWestPos.getSceneLayer();
	};
	%this.SetupSlotOut(L2_SlotOutWest);
	
	new CompositeSprite(L2_SlotOutEast)
	{
		class = "Static";
		slot = false;	//	Slot for false statements
		Position = SlotOutEastPos.getPosition();
		SceneLayer = SlotOutEastPos.getSceneLayer();
	};
	%this.SetupSlotOut(L2_SlotOutEast);
	
	// Add to Scene
	%this.add(L2_Rock0West);
	%this.add(L2_Rock1West);
	%this.add(L2_Rock2West);
	%this.add(L2_Log1West);
	%this.add(L2_Rock1East);
	%this.add(L2_Rock2East);
	%this.add(L2_Log2East);
	
	%this.add(L2_StoneSign);
}

//	Setup Orbs
function Lesson2_Gate::SetupOrb(%this, %orb)
{
	Lesson2.totalOrbs++;
	%orb.collisionSize = "0.5, 0.5";
	%orb.animationName = "Assets:OrbFlash";
	%orb.imagePos = "0, 0";
	%orb.imageSize = "1.5, 1.5";
	%orb.Setup(%this);
	
	//%this.add(%orb);
}
function L2_Orb1::onPickUp(%this)	{	Lesson2.PickUpOrb(); return true;	}
function L2_Orb2::onPickUp(%this)	{	Lesson2.PickUpOrb(); return true;	}
function L2_Orb3::onPickUp(%this)	{	Lesson2.PickUpOrb(); return true;	}
function L2_Orb4::onPickUp(%this)	{	Lesson2.PickUpOrb(); return true;	}
function L2_Orb5::onPickUp(%this)	{	Lesson2.PickUpOrb(); return true;	}
function L2_Orb6::onPickUp(%this)	{	Lesson2.PickUpOrb(); return true;	}
function L2_Orb7::onPickUp(%this)	{	Lesson2.PickUpOrb(); return true;	}
function L2_Orb8::onPickUp(%this)	{	Lesson2.PickUpOrb(); return true;	}
function L2_Orb9::onPickUp(%this)	{	Lesson2.PickUpOrb(); return true;	}
function L2_Orb10::onPickUp(%this)	{	Lesson2.PickUpOrb(); return true;	}

//	Setup Slots
function Lesson2_Gate::SetupSlotIn(%this, %slot)
{
	%slot.displayName = "Slot";
	
	%slot.collisionSize = "1.1, 1.5";
	%slot.imageName = "Assets:Slot2";
	%slot.imagePos = "0.1, -0.25";
	%slot.imageSize = "1.25, 2";
	%slot.Setup();
	
	%this.add(%slot);
}
function Lesson2_Gate::SetupSlotOut(%this, %slot)
{
	%slot.displayName = "Slot";
	
	%slot.collisionSize = "1, 1";
	%slot.imageName = "Assets:Slot1";
	%slot.imagePos = "0, 0";
	%slot.imageSize = "1, 1";
	%slot.Setup();
	
	%this.add(%slot);
}

//	Slot Use
function L2_SlotInWest::Use(%this, %user)
{
	echo("Using West Slot");
	echo(L2_SlotInWest SPC L2_SlotInWest.slot);
	
	%item = Inventory.UseSelectedItem();
	warn(%item);
	
	checkOrb(%this, %item);
}
function L2_SlotInEast::Use(%this, %user)
{
	echo("Using East Slot");
	echo(L2_SlotInEast SPC L2_SlotInEast.slot);
	
	%item = Inventory.UseSelectedItem();
	warn(%item);
	
	checkOrb(%this, %item);
}
function Lesson2_Gate::checkOrb(%slot, %item)
{
	switch$(%item)
	{
		case L2_Orb1:
		case L2_Orb2:
		case L2_Orb3:
		case L2_Orb4:
		case L2_Orb5:
		case L2_Orb6:
		case L2_Orb7:
		case L2_Orb8:
		case L2_Orb9:
		case L2_Orb10:
			echo("Is an orb");
			if (%slot.slot == %item.answer)
			{
				echo("Orb is in the correct slot");
			}
			else
			{
				error("Orb is in the wrong slot");
			}
		default:
			echo("Not an orb");
	}
}

//	Triggers
function L2_Exit::onEnter(%this, %object)
{
	if (%object.getName() $= Player)
	{
		UpdateHelpBar(%this, "Leaving Divisions");

		// New scenes cannot be called during onCollision else the game will crash
		%this.schedule(100, EndActivity());
	}
}
function L2_ExitWarn::onEnter(%this, %object)
{
	UpdateHelpBar(%this, "You are about the leave Divisions");
}
function L2_ExitWarn::onLeave(%this, %object)
{
	UpdateHelpBar(%this, 0);
}