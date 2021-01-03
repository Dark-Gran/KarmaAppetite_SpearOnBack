using System;
using Partiality.Modloader;

public class KarmaAppetite_SpearOnBack : PartialityMod
{

    public KarmaAppetite_SpearOnBack()
    {
        instance = this;
        this.ModID = "KarmaAppetite_SpearOnBack";
        this.Version = "0.1";
        this.author = "DarkGran";
    }

    public static KarmaAppetite_SpearOnBack instance;

    public override void OnEnable()
    {
        base.OnEnable();
        On.Player.ctor += Player_ctor;
    }

    private void Player_ctor(On.Player.orig_ctor orig, Player self, AbstractCreature abstractCreature, World world)
    {
        orig.Invoke(self, abstractCreature, world);
        if (self.slugcatStats.name != SlugcatStats.Name.Red)
        {
            if (!self.playerState.isGhost)
            {
                self.spearOnBack = new Player.SpearOnBack(self);
            }
        }
    }
}