﻿namespace RandomUserConsumer.Exceptions.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) { }
}