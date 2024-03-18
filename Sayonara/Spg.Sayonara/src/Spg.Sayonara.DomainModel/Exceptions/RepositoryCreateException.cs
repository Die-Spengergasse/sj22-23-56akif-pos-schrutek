namespace Spg.Sayonara.DomainModel.Exceptions
{
    public class RepositoryCreateException : Exception
    {
        public RepositoryCreateException()
            : base()
        { }

        public RepositoryCreateException(string message)
            : base(message)
        { }

        public RepositoryCreateException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public static RepositoryCreateException FromDbError(Exception ex)
        {
            return new RepositoryCreateException("Methode 'int Create(Product entity)' ist fehlgeschlagen!", ex);
        }
    }
}
