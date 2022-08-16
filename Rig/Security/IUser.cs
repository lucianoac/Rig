namespace Rig.Security
{
    public interface IUser
    {
        string Name { get; }
        IEnumerable<string> Roles { get; }
    }
}