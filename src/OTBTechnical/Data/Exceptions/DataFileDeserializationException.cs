namespace OTBTechnical.Data.Exceptions;

public class DataFileDeserializationException(string message, Exception innerEx) : Exception(message, innerEx);