namespace CommunereTest.Domain.Common
{
    public interface ILogicalDeletable
    {
        bool IsDeleted { get; set; }
    }
}