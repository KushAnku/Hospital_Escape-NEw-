using Hospital_Escape;

public class TakeCommand : Command
{
    public TakeCommand() : base()
    {
        this.name = "take";
    }

    public override bool Execute(Nurse player)
    {

        if (this.hasSecondWord())
        {
            player.pickUpItem(SecondWord);
        }
        else
        {
            player.outputMessage("\nEnter Item Name.");
        }
        return false;
    }
}