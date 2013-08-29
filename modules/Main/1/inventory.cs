function Inventory::onAdd(%this)
{
   %this.count = 0;
}

function Inventory::AddItem(%this, %item)
{
   %this.item[%this.count] = %item;
   %this.count++;
   
   echo("New Item" SPC %item.getId());
   
   for (%i = 0; %i < %this.count; %i++)
   {
      echo("Item" SPC %i SPC ":" SPC %this.item[%i].getName());
   }
   
   echo("Inventory Count" SPC %this.count);
}

// Move items into empty array slots
function Inventory::Organize()
{
   for (%i = 0; %i < %this.count; %i++)
   {
      if (%this.item[%i] == 0)
      {
         for (%j = %i++; %j < %this.count; %j++)
            %this.item[%j--] = %this.item[%j];
         
         %this.count--;
      }
   }
}