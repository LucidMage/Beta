function Lesson2_Gate::onAdd(%this)
{
}

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
	%this.SetupTriggers();
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
	%orbSize = "1.5, 1.5";
	//	"Boys usually reach puberty before girls"
	new CompositeSprite(L2_Orb1)
	{
		displayName = "Boys usually reach puberty before girls";
		class = "Item";
		collisionSize = "0.5, 0.5";
		animationName = "Assets:OrbFlash";
		imagePos = "0, 0";
		imageSize = %orbSize;

		Position = Orb1Pos.getPosition();
		SceneLayer = Orb1Pos.getSceneLayer();
	};
	L2_Orb1.Setup();
	
	//	"Mood swings are common during puberty"
	%position = Orb2Pos.getPosition();
	%position.x += 0.5;
	new CompositeSprite(L2_Orb2)
	{
		displayName = "Mood swings are common during puberty";
		class = "Item";
		collisionSize = "0.5, 0.5";
		animationName = "Assets:OrbFlash";
		imagePos = "0, 0";
		imageSize = %orbSize;

		Position = %position;
		SceneLayer = Orb2Pos.getSceneLayer();
	};
	L2_Orb2.Setup();
	
	//	"The physical changes of puberty can affect the emotions"
	%position = Orb3Pos.getPosition();
	%position.x += 0;
	new CompositeSprite(L2_Orb3)
	{
		displayName = "The physical changes of puberty can affect the emotions";
		class = "Item";
		collisionSize = "0.5, 0.5";
		animationName = "Assets:OrbFlash";
		imagePos = "0, 0";
		imageSize = %orbSize;

		Position = %position;
		SceneLayer = Orb3Pos.getSceneLayer();
	};
	L2_Orb3.Setup();
	
	//	"All the changes at puberty are visible"
	%position = Orb4Pos.getPosition();
	%position.x += 0;
	new CompositeSprite(L2_Orb4)
	{
		displayName = "All the changes at puberty are visible";
		class = "Item";
		collisionSize = "0.5, 0.5";
		animationName = "Assets:OrbFlash";
		imagePos = "0, 0";
		imageSize = %orbSize;

		Position = %position;
		SceneLayer = Orb4Pos.getSceneLayer();
	};
	L2_Orb4.Setup();
	
	//	"Only boys' voices get deeper at puberty"
	%position = Orb5Pos.getPosition();
	%position.x += 0;
	new CompositeSprite(L2_Orb5)
	{
		displayName = "Only boys' voices get deeper at puberty";
		class = "Item";
		collisionSize = "0.5, 0.5";
		animationName = "Assets:OrbFlash";
		imagePos = "0, 0";
		imageSize = %orbSize;

		Position = %position;
		SceneLayer = Orb5Pos.getSceneLayer();
	};
	L2_Orb5.Setup();
	
	//	"People develop in different ways and at different ages"
	%position = Orb6Pos.getPosition();
	%position.x += 0;
	new CompositeSprite(L2_Orb6)
	{
		displayName = "People develop in different ways and at different ages";
		class = "Item";
		collisionSize = "0.5, 0.5";
		animationName = "Assets:OrbFlash";
		imagePos = "0, 0";
		imageSize = %orbSize;

		Position = %position;
		SceneLayer = Orb6Pos.getSceneLayer();
	};
	L2_Orb6.Setup();
	
	//	"Young people are sexually mater after puberty"
	%position = Orb7Pos.getPosition();
	%position.x += 0;
	new CompositeSprite(L2_Orb7)
	{
		displayName = "Young people are sexually mater after puberty";
		class = "Item";
		collisionSize = "0.5, 0.5";
		animationName = "Assets:OrbFlash";
		imagePos = "0, 0";
		imageSize = %orbSize;

		Position = %position;
		SceneLayer = Orb7Pos.getSceneLayer();
	};
	L2_Orb7.Setup();
	
	//	"It is normal for boys to develop breasts during puberty"
	%position = Orb8Pos.getPosition();
	%position.x += 0;
	new CompositeSprite(L2_Orb8)
	{
		displayName = "It is normal for boys to develop breasts during puberty";
		class = "Item";
		collisionSize = "0.5, 0.5";
		animationName = "Assets:OrbFlash";
		imagePos = "0, 0";
		imageSize = %orbSize;

		Position = %position;
		SceneLayer = Orb8Pos.getSceneLayer();
	};
	L2_Orb8.Setup();
	
	//	"You sweat and smell more during and after puberty"
	%position = Orb9Pos.getPosition();
	%position.x += 0;
	new CompositeSprite(L2_Orb9)
	{
		displayName = "You sweat and smell more during and after puberty";
		class = "Item";
		collisionSize = "0.5, 0.5";
		animationName = "Assets:OrbFlash";
		imagePos = "0, 0";
		imageSize = %orbSize;

		Position = %position;
		SceneLayer = Orb9Pos.getSceneLayer();
	};
	L2_Orb9.Setup();
	
	//	"Hormones are chemicals created by the body and are responsible for puberty"
	%position = Orb10Pos.getPosition();
	%position.x += 0;
	new CompositeSprite(L2_Orb10)
	{
		displayName = "Hormones are chemicals created by the body and are responsible for puberty";
		class = "Item";
		collisionSize = "0.5, 0.5";
		animationName = "Assets:OrbFlash";
		imagePos = "0, 0";
		imageSize = %orbSize;

		Position = %position;
		SceneLayer = Orb10Pos.getSceneLayer();
	};
	L2_Orb10.Setup();
	
	%this.add(L2_Orb1);
	%this.add(L2_Orb2);
	%this.add(L2_Orb3);
	%this.add(L2_Orb4);
	%this.add(L2_Orb5);
	%this.add(L2_Orb6);
	%this.add(L2_Orb7);
	%this.add(L2_Orb8);
	%this.add(L2_Orb9);
	%this.add(L2_Orb10);
}

//	Obstacles
function Lesson2_Gate::SetupObstacles(%this)
{
	echo("Setup Obstacles");
	
	//	Rocks
	%position = Rock0WestPos.getPosition();
	%position.x += 0.65;
	new CompositeSprite(L2_Rock0West)
	{
		displayName = "Rock";
		class = "Pushable";
		
		collisionSize = "1.8, 1.8";
		density = 75;
		
		imageName = "Assets:Rock1";
		imagePos = "0, 0";
		imageSize = "2, 2";

		Position = %position;
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
	%position.x += 0.65;
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
	
	%position = Rock2EastPos.getPosition();
	%position.y += 0;
	new CompositeSprite(L2_Rock2East)
	{
		displayName = "Rock";
		class = "Pushable";
		
		collisionSize = "2, 1.8";
		density = 75;
		
		imageName = "Assets:Rock1";
		imagePos = "0, 0";
		imageSize = "2.25, 2.25";

		Position = %position;
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

//	Triggers
function Lesson2_Gate::SetupTriggers(%this)
{
	echo("Setup Triggers");
}