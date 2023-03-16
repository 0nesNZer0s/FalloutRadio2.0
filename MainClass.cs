using Verse;

public class FalloutRadioMod : Verse.Mod
{
    public FalloutRadioMod(ModContentPack content) : base(content)
    {
        MrNewVegasAudio.LoadMrNewVegasClips(content);
    }
}