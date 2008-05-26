using System;
using System.Collections.Generic;
using System.Text;

namespace AST.Management {

    class ManagementException : Exception {

        public ManagementException() : base() { }
        public ManagementException(String message) : base(message) { }
        public ManagementException(String message, Exception innerException)
            :
            base(message, innerException) { }

    }

    class FileNotExistException : ManagementException {
        public FileNotExistException() : base() { }
        public FileNotExistException(String message) : base(message) { }
        public FileNotExistException(String message, Exception innerException)
            :
            base(message, innerException) { }
    }

    class ExecutionFailedException : ManagementException {
        public ExecutionFailedException() : base() { }
        public ExecutionFailedException(String message) : base(message) { }
        public ExecutionFailedException(String message, Exception innerException)
            :
            base(message, innerException) { }
    }
}
