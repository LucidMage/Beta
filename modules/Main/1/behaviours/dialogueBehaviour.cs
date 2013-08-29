if (!isObject(DialogueBehaviour))
{
   %template = new BehaviorTemplate(DialogueBehaviour);
   
   %template.friendlyName = "Dialogue";
   %template.description = "Conversation with a sprite";
   
   // addBehaviorField(function name, description of function, keybind, input e.g. "keyboard up" = up arrow key)
   %template.addBehaviorField(selectCurrent, "Key to bind for selecting a dialogue response", keybind, "keyboard space");
   %template.addBehaviorField(select1, "Key to bind for selecting response 1", keybind, "keyboard 1");
   %template.addBehaviorField(select2, "Key to bind for selecting response 2", keybind, "keyboard 2");
   %template.addBehaviorField(select3, "Key to bind for selecting response 3", keybind, "keyboard 3");
   %template.addBehaviorField(select4, "Key to bind for selecting response 4", keybind, "keyboard 4");
   %template.addBehaviorField(select5, "Key to bind for selecting response 5", keybind, "keyboard 5");
   %template.addBehaviorField(select6, "Key to bind for selecting response 6", keybind, "keyboard 6");
   %template.addBehaviorField(select7, "Key to bind for selecting response 7", keybind, "keyboard 7");
   %template.addBehaviorField(select8, "Key to bind for selecting response 8", keybind, "keyboard 8");
   %template.addBehaviorField(select9, "Key to bind for selecting response 9", keybind, "keyboard 9");
   %template.addBehaviorField(select0, "Key to bind for selecting response 0", keybind, "keyboard 0");
}

function DialogueBehaviour::onBehaviorAdd(%this)
{
   if (!isObject(GlobalActionMap))
      return;

   // bindObj(getWord(object.behaviour field, [function parameters excluding %this]), "function name", object)
   GlobalActionMap.bindObj(getWord(%this.selectCurrent, 0), getWord(%this.selectCurrent, 1), "selectResponse", %this);
   GlobalActionMap.bindObj(getWord(%this.select1, 0), getWord(%this.select1, 1), "selectResponse", %this);
}

function DialogueBehaviour::onBehaviorRemove(%this)
{
   if (!isObject(GlobalActionMap))
      return;

   //%this.owner.disableUpdateCallback();

   GlobalActionMap.unbindObj(getWord(%this.selectCurrent, 0), getWord(%this.selectCurrent, 1), %this);
}

function DialogueBehaviour::selectResponse(%this, %i)
{
	switch(%i)
	{
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
		case 9:
		case 0:
			%this.closeDialogue();
	}
}