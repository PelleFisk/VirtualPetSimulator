namespace VirtualPetSimulator;

public class PetType(string type)
{
    public string type { get; set; } = type;

    public static PetType AddPetType(string type)
    {
        return new PetType(type);
    }

    public static List<PetType> AddDefaultPetTypes()
    {
        return new List<PetType>([
            new PetType("Dog"), new PetType("Cat"), new PetType("Bird"), new PetType("Fish")
        ]);
    }
}