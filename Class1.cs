using Verse;

public class FalloutRadioMod : Mod
{
    public FalloutRadioMod(ModContentPack content)
    {
        var mrNewVegasFolderPath = Path.Combine(content.RootDir, "MrNewVegas");
        if (Directory.Exists(mrNewVegasFolderPath))
        {
            mrNewVegasClips = Directory.GetFiles(mrNewVegasFolderPath, "*.ogg")
                .Select(path => new { path, clip = ContentFinder<AudioClip>.Get(path) })
                .ToDictionary(x => x.path, x => x.clip);
        }
    }
}
