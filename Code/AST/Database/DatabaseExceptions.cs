using System;
using System.Collections.Generic;
using System.Text;

namespace AST.Database {

    class DatabaseException : Exception {

        public DatabaseException() : base() { }
        public DatabaseException(String message) : base(message) { }
        public DatabaseException(String message, Exception innerException): 
            base(message, innerException) { }

    }

    class ConnectionFailedException : DatabaseException {
        public ConnectionFailedException() : base() { }
        public ConnectionFailedException(String message) : base(message) { }
        public ConnectionFailedException(String message, Exception innerException): 
            base(message, innerException) { }
    }

    class QueryFailedException : DatabaseException {
        public QueryFailedException() : base() { }
        public QueryFailedException(String message) : base(message) { }
        public QueryFailedException(String message, Exception innerException)
            :
            base(message, innerException) { }
    }

    class EmptyQueryResultException : DatabaseException {
        public EmptyQueryResultException() : base() { }
        public EmptyQueryResultException(String message) : base(message) { }
        public EmptyQueryResultException(String message, Exception innerException)
            :
            base(message, innerException) { }
    }

    class InvalidTypeException : DatabaseException {
        public InvalidTypeException() : base() { }
        public InvalidTypeException(String message) : base(message) { }
        public InvalidTypeException(String message, Exception innerException)
            :
            base(message, innerException) { }
    }

    class InvalidNameException : DatabaseException {
        public InvalidNameException() : base() { }
        public InvalidNameException(String message) : base(message) { }
        public InvalidNameException(String message, Exception innerException)
            :
            base(message, innerException) { }
    }
}
