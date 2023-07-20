using System.Runtime.Serialization;

namespace HW_2_5.Exceptions;

/// <summary>
/// Custom BusinessException.
/// </summary>
[Serializable]
public sealed class BusinessException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BusinessException"/> class.
    /// </summary>
    /// <param name="message">An error message.</param>
    public BusinessException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BusinessException"/> class.
    /// </summary>
    /// <param name="message">An error message.</param>
    /// <param name="innerException">The instance of the <see cref="Exception"/> class.</param>
    public BusinessException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BusinessException"/> class.
    /// </summary>
    /// <param name="info">The instance of the <see cref="SerializationInfo"/> class.</param>
    /// <param name="context">The instance of the <see cref="StreamingContext"/> struct.</param>
    public BusinessException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}