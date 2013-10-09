//	Scene Setup
function Lesson3A_Forest::Setup(%this)
{
	%this.setName("Lesson3A_Forest");

	//	Add Tiled Map
	%mapSprite = new TmxMapSprite()
	{
		Map = "Year8:lesson3A_map";
	};
	
	%this.add(%mapSprite);

	%this.SetupCharacters();
	%this.SetupObstacles();
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
		dialogueTree = L3A_UnderarmHairDialogueTree;
		
		gender = $SpriteGenderFemale;
		ethnicity = GetRandomEthnicity();//$SpriteEthnicityMaori;
		hairColour = GetRandomHairColour();
		hairStyle = GetRandomHairStyle();
		torso = $SpriteTorsoTShirtF;
		legs = GetRandomLegs();//$SpriteLegsDress;
		accessory = GetRandomAccessory();//$SpriteAccessoryNone;

		Position = L3A_UnderarmHairPos.getPosition();
		SceneLayer = L3A_UnderarmHairPos.getSceneLayer();
	};
	%this.SetupLostPerson(L3A_UnderarmHairPerson);
	//L3A_UnderarmHairPerson.Setup(%this);
	
	//	Girl Developing Breasts
	new CompositeSprite(L3A_DevelopBreastGirl)
	{
		displayName = "Girl Covering Chest";
		class = "Character";
		dialogueTree = L3A_DevelopBreastDialogueTree;
		
		gender = $SpriteGenderFemale;
		ethnicity = GetRandomEthnicity();
		hairColour = GetRandomHairColour();
		hairStyle = GetRandomHairStyle();
		torso = GetRandomTorso();
		legs = GetRandomLegs();
		accessory = GetRandomAccessory();//$SpriteAccessoryNone;

		Position = L3A_DevelopBreastGirlPos.getPosition();
		SceneLayer = L3A_DevelopBreastGirlPos.getSceneLayer();
	};
	%this.SetupLostPerson(L3A_DevelopBreastGirl);
	//L3A_DevelopBreastGirl.Setup(%this);

	//  Sweaty Person
	new CompositeSprite(L3A_SweatyPerson)
	{
		displayName = "Sweaty Boy";
		class = "Character";
		dialogueTree = L3A_SweatyDialogueTree;
		
		gender = $SpriteGenderMale;
		ethnicity = GetRandomEthnicity();
		hairColour = GetRandomHairColour();
		hairStyle = GetRandomHairStyle();
		torso = GetRandomTorso();
		legs = GetRandomLegs();
		accessory = GetRandomAccessory();//$SpriteAccessoryNone;

		Position = L3A_SweatyPersonPos.getPosition();
		SceneLayer = L3A_SweatyPersonPos.getSceneLayer();
	};
	%this.SetupLostPerson(L3A_SweatyPerson);
	//L3A_SweatyPerson.Setup(%this);

	//  Broad Shouldered Person
	new CompositeSprite(L3A_BroadShoulderPerson)
	{
		displayName = "Broad shouldered boy";
		class = "Character";
		dialogueTree = L3A_BroadShoulderDialogueTree;
		
		gender = $SpriteGenderMale;
		ethnicity = GetRandomEthnicity();
		hairColour = GetRandomHairColour();
		hairStyle = GetRandomHairStyle();
		torso = GetRandomTorso();
		legs = GetRandomLegs();
		accessory = GetRandomAccessory();//$SpriteAccessoryNone;

		Position = L3A_BroadShoulderPersonPos.getPosition();
		SceneLayer = L3A_BroadShoulderPersonPos.getSceneLayer();
	};
	%this.SetupLostPerson(L3A_BroadShoulderPerson);
	//L3A_BroadShoulderPerson.Setup(%this);

	//  Pubic Hair Person
	new CompositeSprite(L3A_PubicHairPerson)
	{
		displayName = "Girl looking down";
		class = "Character";
		dialogueTree = L3A_PubicHairDialogueTree;
		
		gender = $SpriteGenderFemale;
		ethnicity = GetRandomEthnicity();
		hairColour = GetRandomHairColour();
		hairStyle = GetRandomHairStyle();
		torso = GetRandomTorso();
		legs = GetRandomLegs();
		accessory = GetRandomAccessory();//$SpriteAccessoryNone;

		Position = L3A_PubicHairPos.getPosition();
		SceneLayer = L3A_PubicHairPos.getSceneLayer();
	};
	%this.SetupLostPerson(L3A_PubicHairPerson);
	//L3A_PubicHairPerson.Setup(%this);
	/*
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
	Lesson3A.totalLost++;*/
}

//	Obstacles
function Lesson3A_Forest::SetupObstacles(%this)
{
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
	L3A_StoneSign.Setup(%this);
	
	//	Exit Obstacle
	new CompositeSprite(L3A_ExitObstacle)
	{
		displayName = "Hedge";
		class = "Static";
		
		collisionSize = "6, 2";
		imageName = "Assets:Hedge";
		imagePos = "0, 0";
		imageSize = "6, 2";

		Position = EndObstaclePos.getPosition();
		SceneLayer = EndObstaclePos.getSceneLayer();
	};
	L3A_ExitObstacle.Setup(%this);
	/*
	// Add to Scene
	%this.add(L3A_StoneSign);
	%this.add(L3A_ExitObstacle);*/
}

// Setup Lost People
function Lesson3A_Forest::SetupLostPerson(%this, %person)
{
   if (Lesson3A.totalLost $= "")
      Lesson3A.totalLost = 0;
   
   %person.helped = false;
   %person.Setup(%this);
	//%this.add(%person);
	%this.helpedPeople[Lesson3A.totalLost] = %person;
	echo(Lesson3A.totalLost @ ":" SPC %this.helpedPeople[Lesson3A.totalLost]);
	Lesson3A.totalLost++;
}

function Lesson3A_Forest::CountHelped(%this)
{
   %count = 0;
   
   for (%i = 0; %i < Lesson3A.totalLost; %i++)
      if (%this.helpedPeople[%i].helped)
         %count++;
   
   return %count;
}

//	Triggers
function L3A_Exit::onEnter(%this, %object)
{
	if (%object.getName() $= Player)
	{
		UpdateHelpBar(%this, "Leaving Mix 'n Match");

		// New scenes cannot be called during onCollision else the game will crash
		%this.schedule(100, EndActivity);
	}
}
function L3A_ExitWarn::onEnter(%this, %object)
{
	UpdateHelpBar(%this, "You are about to leave Mix 'n Match");
}
function L3A_ExitWarn::onLeave(%this, %object)
{
	UpdateHelpBar(%this, 0);
}