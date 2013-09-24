function Lesson3A_Forest::onAdd(%this)
{
	echo("Lesson3A Forest onAdd");
}

//	Scene Setup
function Lesson3A_Forest::Setup(%this)
{
	echo("Lesson3A Forest Setup");
	%this.setName("Lesson3A_Forest");

	//	Add Tiled Map
	%mapSprite = new TmxMapSprite()
	{
		Map = "Year8:lesson3A_map";
	};
	
	%this.add(%mapSprite);

	%this.SetupCharacters();
	%this.SetupObstacles();
	%this.SetupTriggers();
}

//	Characters
function Lesson3A_Forest::SetupCharacters(%this)
{
	//  Create Player
	SetupPlayer(%this, PlayerPos.getPosition(), PlayerPos.getSceneLayer());
	Player.direction = $SpriteDirectionUp;
	Player.UpdateImages();

	//	NPCs
	//  Underarm Hair Person
	new CompositeSprite(L3A_UnderarmHairPerson)
	{
		displayName = "Girl with Raised Arms";
		class = "Character";
		gender = $SpriteGenderFemale;
		ethnicity = $SpriteEthnicityMaori;
		torso = "";
		legs = $SpriteLegsDress;

		Position = L3A_UnderarmHairPos.getPosition();
		SceneLayer = L3A_UnderarmHairPos.getSceneLayer();
		
		helped = false;
	};
	L3A_UnderarmHairPerson.Setup();
	L3A_UnderarmHairPerson.dialogueTree = L3A_UnderarmHairDialogueTree;
	
	//	Girl Developing Breasts
	new CompositeSprite(L3A_DevelopBreastGirl)
	{
		displayName = "Girl Covering Chest";
		class = "Character";
		gender = $SpriteGenderMale;
		ethnicity = $SpriteEthnicityMaori;
		torso = "";
		legs = $SpriteLegsDress;

		Position = L3A_DevelopBreastGirlPos.getPosition();
		SceneLayer = L3A_DevelopBreastGirlPos.getSceneLayer();
		
		helped = false;
	};
	L3A_DevelopBreastGirl.Setup();
	L3A_DevelopBreastGirl.dialogueTree = L3A_DevelopBreastDialogueTree;

	//  Sweaty Person
	new CompositeSprite(L3A_SweatyPerson)
	{
		displayName = "Sweaty Boy";
		class = "Character";
		gender = $SpriteGenderMale;
		ethnicity = $SpriteEthnicityMaori;
		torso = "";
		legs = $SpriteLegsDress;

		Position = L3A_SweatyPersonPos.getPosition();
		SceneLayer = L3A_SweatyPersonPos.getSceneLayer();
		
		helped = false;
	};
	L3A_SweatyPerson.Setup();
	L3A_SweatyPerson.dialogueTree = L3A_SweatyDialogueTree;

	//  Broad Shouldered Person
	new CompositeSprite(L3A_BroadShoulderPerson)
	{
		displayName = "Broad shouldered boy";
		class = "Character";
		gender = $SpriteGenderMale;
		ethnicity = $SpriteEthnicityMaori;
		torso = $SpriteTorsoHoodie;
		legs = $SpriteLegsDress;

		Position = L3A_BroadShoulderPersonPos.getPosition();
		SceneLayer = L3A_BroadShoulderPersonPos.getSceneLayer();
		
		helped = false;
	};
	L3A_BroadShoulderPerson.Setup();
	L3A_BroadShoulderPerson.dialogueTree = L3A_BroadShoulderDialogueTree;

	//  Pubic Hair Person
	new CompositeSprite(L3A_PubicHairPerson)
	{
		displayName = "Girl looking down";
		class = "Character";
		gender = $SpriteGenderFemale;
		ethnicity = $SpriteEthnicityMaori;
		torso = "";
		legs = $SpriteLegsDress;

		Position = L3A_PubicHairPos.getPosition();
		SceneLayer = L3A_PubicHairPos.getSceneLayer();
		
		helped = false;
	};
	L3A_PubicHairPerson.Setup();
	L3A_PubicHairPerson.dialogueTree = L3A_PubicHairDialogueTree;
	
	// Add to Scene
	%this.add(L3A_UnderarmHairPerson);
	Lesson3A.totalLost++;
	
	%this.add(L3A_DevelopBreastGirl);
	Lesson3A.totalLost++;
	
	%this.add(L3A_SweatyPerson);
	Lesson3A.totalLost++;
	
	%this.add(L3A_BroadShoulderPerson);
	Lesson3A.totalLost++;
	
	%this.add(L3A_PubicHairPerson);
	Lesson3A.totalLost++;
}

//	Obstacles
function Lesson3A_Forest::SetupObstacles(%this)
{
	echo("Setup Obstacles");
	
	//	Stone Sign
	new CompositeSprite(L3A_StoneSign)
	{
		displayName = "Stone Sign";
		class = "Readable";
		
		collisionSize = "1.25, 1";
		imageName = "Assets:StoneSign";
		imagePos = "0, 0.2";
		imageSize = "2, 2";
		
		dialogueTree = L3A_StoneSignDialogueTree;

		Position = StoneSignPos.getPosition();
		SceneLayer = StoneSignPos.getSceneLayer();
	};
	L3A_StoneSign.Setup();
	
	// Add to Scene
	%this.add(L3A_StoneSign);
}

//	Triggers
function Lesson3A_Forest::SetupTriggers(%this)
{
	echo("Setup Triggers");
}