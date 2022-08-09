namespace EducationalMaterials.API.Exceptions
{
    public class InvalidEmailOrPasswordException : Exception
    {
        public InvalidEmailOrPasswordException(string message) : base(message) { }
    }
}
