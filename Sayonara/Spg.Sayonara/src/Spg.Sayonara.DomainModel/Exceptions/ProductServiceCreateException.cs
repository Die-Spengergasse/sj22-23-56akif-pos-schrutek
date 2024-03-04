namespace Spg.Sayonara.DomainModel.Exceptions 
{ 
    public class ProductServiceCreateException : Exception
    {
        public ProductServiceCreateException()
            : base()
        { }

        public ProductServiceCreateException(string message)
            : base(message)
        { }

        public ProductServiceCreateException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
} 
