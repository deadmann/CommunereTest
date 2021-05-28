namespace CommunereTest.Domain.Enums
{
    public enum UserActivationStatus
    {
        Inactive = 0, // due to lack of email verification
        Active = 1,
        DeactivatedByUser = 2,
        DeactivatedByAdmin = 3,
    }
}
