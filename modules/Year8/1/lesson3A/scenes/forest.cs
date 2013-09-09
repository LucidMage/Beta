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

		Position = UnderarmHairPos.getPosition();
		SceneLayer = UnderarmHairPos.getSceneLayer();
		
		helped = false;
	};
	L3A_UnderarmHairPerson.Setup();
	L3A_UnderarmHairPerson.dialogueTree = L3A_UnderarmHairDialogueTree;

	// Add to Scene
	%this.add(L3A_UnderarmHairPerson);
}

//	Triggers
function Lesson3A_Forest::SetupTriggers(%this)
{
	echo("Setup Triggers");
}