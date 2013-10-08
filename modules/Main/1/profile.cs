function CreateProfile()
{
	if (!isObject(Profile))
	{
		new ScriptObject(Profile)
		{
			displayName = "Test";
			//password = "guest";
			year = 8;
			gender = $SpriteGenderFemale;
			ethnicity = $SpriteEthnicityMaori;
			
			hairColour = $SpriteHairColourBlonde;
			hairStyle = $SpriteHairStyleWavy;
			torso = $SpriteTorsoPlaid;
			legs = $SpriteLegsDress;
			accessory = $SpriteAccessoryNone;
		};
	}
}

function OpenProfileGUI()
{
	CreateScene(ProfileScene);
	Canvas.pushDialog(ProfileGUI);
	
	UpdateProfileGUIOptions();
	UpdateProfileGUIPreview();
}

function CloseProfileGUI()
{
	LoadYearGroup(Main.YearGroup);
	//Canvas.popDialog(ProfileGUI);
	OpenSelectActivityGUI();
}

//	Preview of the character they are making
function UpdateProfileGUIPreview()
{
	SetupPlayerPreview();
}

//	Populate options for customizing the character
function UpdateProfileGUIOptions()
{
    //==	Gender    ==//
	GenderList.clear();
	
    //	Populate gender list
    for (%i = 0; %i < $SpriteGenderCount; %i++)
    {
        //	Add to the list.  
        GenderList.add($SpriteGenderArray[%i], %i);
        
        if (%i == 0)
            GenderList.setSelected( %i );
			
        //	Select if it's the default one.
		if (Profile.gender $= $SpriteGenderArray[%i])
            GenderList.setSelected( %i );
    }
    GenderList.sort();
	
    //==	Ethnicity    ==//
	EthnicityList.clear();
	
    //	Populate enthnicity list
    for (%i = 0; %i < $SpriteEthnicityCount; %i++)
    {
		//	Set display name
		%ethnicity = $SpriteEthnicityArray[%i];
		
		//	Pacific Islander
		if ($SpriteEthnicityArray[%i] $= $SpriteEthnicityPI)
			%ethnicity = $SpriteEthnicityPIFull;
		
        //	Add to the list.  
        EthnicityList.add(%ethnicity, %i);
        
        if (%i == 0)
            EthnicityList.setSelected( %i );
			
        //	Select if it's the default one.
		if (Profile.ethnicity $= $SpriteEthnicityArray[%i])
            EthnicityList.setSelected( %i );
    }
    EthnicityList.sort();
	
    //==	Hair    ==//
	HairList.clear();
	
    //	Populate hair list
	%i = 0;	//	List number
    for (%s = 0; %s < $SpriteHairStyleCount; %s++)
    {
		for (%c = 0; %c < $SpriteHairColourCount; %c++)
		{
			//	Assemble option.
			%hair = "";
			
			//	Grey Hair only has one style
			if ($SpriteHairColourArray[%c] $= $SpriteHairColourGrey)
			{
				if ($SpriteHairStyleArray[%s] $= $SpriteHairStyleLongAndro)
				{
					%hair = ($SpriteHairColourArray[%c] SPC $SpriteHairStyleArray[%s]);
				}
			}
			else
			{
				%hair = ($SpriteHairColourArray[%c] SPC $SpriteHairStyleArray[%s]);
			}
			
			warn(%hair);
			
			//	Add to list.
			if (%hair !$= "")
			{
				//	Set display name
				//	Grey Hair
				if ($SpriteHairColourArray[%c] $= $SpriteHairColourGrey && $SpriteHairStyleArray[%s] $= $SpriteHairStyleLongAndro)
					%hair = $SpriteHairColourGreyFull;
				//	Long Femme
				else if ($SpriteHairStyleArray[%s] $= $SpriteHairStyleLongFem)
					%hair = ($SpriteHairColourArray[%c] SPC $SpriteHairStyleLongFemFull);
				//	Long Andro
				else if ($SpriteHairStyleArray[%s] $= $SpriteHairStyleLongAndro)
					%hair = ($SpriteHairColourArray[%c] SPC $SpriteHairStyleLongAndroFull);
				
				HairList.add(%hair, %i);
				
				if (%i == 0)
					HairList.setSelected(%i);
					
				//	Select if it's the default one.
				if (Profile.hair $= ($SpriteHairColourArray[%c] SPC $SpriteHairStyleArray[%s]))
					HairList.setSelected( %i );
					
				%i++;
			}
		}
    }
    HairList.sort();
	
    //==	Torso    ==//
	TorsoList.clear();
	
    //	Populate torso list
	%count = 0;
    for (%i = 0; %i < $SpriteTorsoCount; %i++)
    {
		//	Different t-shirt for different genders
		if (!($SpriteTorsoArray[%i] $= $SpriteTorsoTShirt && Profile.gender $= $SpriteGenderFemale) &&
			!($SpriteTorsoArray[%i] $= $SpriteTorsoTShirtF && Profile.gender $= $SpriteGenderMale))
		{
			//	Set display name
			%torso = $SpriteTorsoArray[%i];
			
			//	T-Shirt
			if (%torso $= $SpriteTorsoTShirt || %torso $= $SpriteTorsoTShirtF)
				%torso = $SpriteTorsoTShirtFull;
			
			//	Add to the list.
			TorsoList.add(%torso, %count);
			
			if (%count == 0)
				TorsoList.setSelected(%count);
				
			//	Select if it's the default one.
			if (Profile.torso $= $SpriteTorsoArray[%i])
				TorsoList.setSelected(%count);
				
			%count++;
		}
    }
    TorsoList.sort();
	
    //==	Legs    ==//
	LegsList.clear();
	
    //	Populate legs list
    for (%i = 0; %i < $SpriteLegsCount; %i++)
    {
        //	Add to the list.  
        LegsList.add($SpriteLegsArray[%i], %i);
        
        if (%i == 0)
            LegsList.setSelected( %i );
			
        //	Select if it's the default one.
		if (Profile.legs $= $SpriteLegsArray[%i])
            LegsList.setSelected( %i );
    }
    LegsList.sort();
	
    //==	Accessory    ==//
	AccessoryList.clear();
	
    //	Populate accessory list
    for (%i = 0; %i < $SpriteAccessoryCount; %i++)
    {
		//	Set display name
		%accessory = $SpriteAccessoryArray[%i];
		
		//	None
		if (%accessory $= $SpriteAccessoryNone)
			%accessory = $SpriteAccessoryNoneFull;
		
        //	Add to the list.  
        AccessoryList.add(%accessory, %i);
        
        if (%i == 0)
            AccessoryList.setSelected( %i );
			
        //	Select if it's the default one.
		if (Profile.accessory $= $SpriteAccessoryArray[%i])
            AccessoryList.setSelected( %i );
    }
    AccessoryList.sort();
}

function ProfileScene::Setup()
{
	SetupPlayerPreview();
	PlayerPreview.setPosition(-5, 0);
	ProfileScene.add(PlayerPreview);
}

function GenderList::onSelect(%this)
{
	Profile.gender = GenderList.getText();
	TorsoList.onSelect();   // Certain torsos apply only to a single gender
	
	//UpdateProfileGUI();
	UpdateProfileGUIPreview();
}

function EthnicityList::onSelect(%this)
{
	Profile.ethnicity = EthnicityList.getText();
		
	//	Pacific Islander
	if (Profile.ethnicity $= $SpriteEthnicityPIFull)
		Profile.ethnicity = $SpriteEthnicityPI;
	
	//UpdateProfileGUI();
	UpdateProfileGUIPreview();
}

function HairList::onSelect(%this)
{
	%text = HairList.getText();
	echo(%text);
	
	// Hair Colour
	Profile.hairColour = getWord(%text, 0);
	echo(Profile.hairColour);
	
	// Hair Style
	Profile.hairStyle = removeWord(%text, 0);
	echo(Profile.hairStyle);
		
	//	Long Hair
	if (Profile.hairStyle $= $SpriteHairStyleLongFemFull)
		Profile.hairStyle = $SpriteHairStyleLongFem;
	if (Profile.hairStyle $= $SpriteHairStyleLongAndroFull)
		Profile.hairStyle = $SpriteHairStyleLongAndro;
	
	//UpdateProfileGUI();
	UpdateProfileGUIPreview();
}

function TorsoList::onSelect(%this)
{
	Profile.torso = TorsoList.getText();
	
   //	T-Shirt
   if (Profile.torso $= $SpriteTorsoTShirtFull)
   {
      if (Profile.gender $= $SpriteGenderFemale)
      {
         Profile.torso = $SpriteTorsoTShirtF;
      }
      else
      {
         Profile.torso = $SpriteTorsoTShirt;
      }
   }
	
	//UpdateProfileGUI();
	UpdateProfileGUIPreview();
}

function LegsList::onSelect(%this)
{
	Profile.legs = LegsList.getText();
	
	//UpdateProfileGUI();
	UpdateProfileGUIPreview();
}

function AccessoryList::onSelect(%this)
{
	Profile.accessory = AccessoryList.getText();
	
	// No accessory
	if (Profile.accessory $= $SpriteAccessoryNoneFull)
	{
	   Profile.accessory = $SpriteAccessoryNone;
	}
	
	//UpdateProfileGUI();
	UpdateProfileGUIPreview();
}