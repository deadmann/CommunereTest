namespace CommunereTest.Domain.Models
{
    public class AppFailure
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }

        public AppFailure(string property, string message)
        {
            PropertyName = property;
            ErrorMessage = message;
        }
    }
}
